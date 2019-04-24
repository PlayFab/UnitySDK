#if !NET_4_6 && (NET_2_0_SUBSET || NET_2_0)
#define TPL_35
#endif

using System;
using System.Collections.Generic;
using System.Diagnostics;
using PlayFab.Logger;

namespace PlayFab.Pipeline
{
    /// <summary>
    /// The event batching stage.
    /// </summary>
    internal class EventBatchingStage : PipelineStageBase<IPlayFabEmitEventRequest, TitleEventBatch>
    {
        public const int DefaultBatchSize = 10;
        private const int MaxPayloadSizeBytes = 1024;
        private const int PFGenericErrorCodeOverLimit = 1214;

        public static readonly TimeSpan DefaultBatchFillTimeout = TimeSpan.FromSeconds(5);
        private static readonly int EventAvailabilityCheckTimeoutInMs = 100;

        private int BatchSize { get; set; }
        private TimeSpan BatchFillTimeout { get; set; }

        private Dictionary<string, List<IPlayFabEmitEventRequest>> batches;

        // Stopwatch is used to keep track of how old the current batch is
        private Stopwatch stopwatch;
        private ILogger logger;

        public EventBatchingStage(ILogger logger) : this(DefaultBatchSize, DefaultBatchFillTimeout, logger)
        {
        }

        public EventBatchingStage(int batchSize, TimeSpan batchFillTimeout, ILogger logger)
        {
            this.logger = logger;
            this.BatchSize = batchSize;
            this.BatchFillTimeout = batchFillTimeout;
            this.stopwatch = new Stopwatch();
            this.batches = new Dictionary<string, List<IPlayFabEmitEventRequest>>();
        }

        /// <summary>
        /// This method is called by pipeline for each available input item (an event)
        /// </summary>
        /// <param name="eventPacket">The input item.</param>
        protected override void OnNextInputItem(IPlayFabEmitEventRequest request)
        {
            PlayFabEmitEventRequest eventRequest = (PlayFabEmitEventRequest)request;
            if (ValidationCheck(eventRequest))
            {
                //Determine titleId of event
                string titleId = eventRequest.TitleId;

                if (string.IsNullOrEmpty(titleId.Trim()))
                {
                    logger.Error(string.Format("Event {0} has null or empty title id", eventRequest.Event.Name));
                }
                else
                {
                    this.InitNewBatch(titleId);
                    this.batches[titleId].Add(eventRequest);

                    // Start keeping track of batch's age when it gets
                    // its first element
                    if (this.batches[titleId].Count == 1)
                    {
                        this.stopwatch.Stop();
                        this.stopwatch.Start();
                    }

                    if (this.batches[titleId].Count >= this.BatchSize)
                    {
                        this.StoreBatch(titleId);
                        this.CreateNewBatch(titleId);

                        // Stop keeping track of batch's age when it is complete and stored
                        this.stopwatch.Reset();
                    }
                }
            }
            else
            {
                logger.Error(string.Format("Event {0} failed validation check and was ignored", eventRequest.Event.Name));
            }
        }

        protected override IEnumerable<IPlayFabEmitEventRequest> GetInputConsumingEnumerable()
        {
            IPlayFabEmitEventRequest eventRequest;
            bool isEventObtained;
            while (!this.input.IsCompleted)
            {
                // Attempt to get an event from its buffer, wait no longer than a small amount of time
                isEventObtained = this.input.TryTake(out eventRequest, EventAvailabilityCheckTimeoutInMs, cts.Token);
                if (cts.Token.IsCancellationRequested)
                {
                    // Exit enumerator if cancellation was signaled
                    break;
                }

                if (stopwatch.Elapsed > this.BatchFillTimeout)
                {
                    // It is time to send the batches
                    this.StoreAllBatches();
                }

                if (isEventObtained)
                {
                    yield return eventRequest;
                }
            }

            // Done iterating through input collection
            // but we may have something left in the batch
            if (!cts.Token.IsCancellationRequested)
            {
                this.StoreAllBatches();
            }

            this.stopwatch.Stop();
        }

        private void StoreBatch(string titleId)
        {
            // Store a batch (and create a new one) only if it is not empty
            if (this.batches[titleId].Count > 0)
            {
                this.StoreOutput(new TitleEventBatch(titleId, this.batches[titleId]));
            }
        }

        private void StoreAllBatches()
        {
            foreach (var kvp in this.batches)
            {
                this.StoreBatch(kvp.Key);
            }

            //Clear all the batches that have been sent
            this.batches.Clear();

            // Stop keeping track of batch's age when it is stored
            this.stopwatch.Reset();
        }

        private void CreateNewBatch(string titleId)
        {
            this.batches[titleId] = new List<IPlayFabEmitEventRequest>(this.BatchSize);
        }

        /// <summary>
        /// Attempts to initialize a batch. Will no-op if batch already exists
        /// </summary>
        /// <param name="titleId"></param>
        private void InitNewBatch(string titleId)
        {
            if (!this.batches.ContainsKey(titleId))
            {
                this.CreateNewBatch(titleId);
            }
        }

        private static bool ValidationCheck(IPlayFabEmitEventRequest request)
        {
            // Payload size validation
            // TODO

            return true;
        }
    }
}
