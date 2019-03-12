#if NET_4_6   
using System;

namespace PlayFab.Pipeline
{
    public class OneDSEventPipelineSettings
    {
        // The size of the event buffer (contains event objects) by default
        public const int DefaultEventBufferSize = 100;

        // The size of the batch buffer (contains batch objects) by default
        public const int DefaultBatchBufferSize = 20;

        public const int MinBatchSize = 1;
        public const int MaxBatchSize = 25;

        // The size of an event batch (i.e. maximum number of events it may reference) by default
        public const int DefaultBatchSize = 25;

        public const int DefaultMaxHttpAttempts = 3;
        
        public static readonly TimeSpan MinBatchFillTimeout = TimeSpan.FromMilliseconds(100);
        public static readonly TimeSpan MaxBatchFillTimeout = TimeSpan.FromHours(1);

        // The maximum duration of time a batch can be held around before it is forced to send out
        // even if it is not full yet
        public static readonly TimeSpan DefaultBatchFillTimeout = TimeSpan.FromSeconds(5);

        private int batchSize = DefaultBatchSize;
        private TimeSpan batchFillTimeout = DefaultBatchFillTimeout;

        /// <summary>
        /// The size of the event buffer.
        /// </summary>
        public int EventBufferSize { get; set; } = DefaultEventBufferSize;

        /// <summary>
        /// The size of the batch buffer.
        /// </summary>
        public int BatchBufferSize { get; set; } = DefaultBatchBufferSize;

        /// <summary>
        /// The size of a batch.
        /// It cannot be less than 1 or greater than 25.
        /// </summary>
        public int BatchSize
        {
            get
            {
                return this.batchSize;
            }

            set
            {
                if (value < MinBatchSize)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.BatchSize), $"The batch size setting cannot be less than {MinBatchSize}");
                }

                if (value > MaxBatchSize)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.BatchSize), $"The batch size setting cannot be greater than {MaxBatchSize}");
                }

                this.batchSize = value;
            }
        }

        /// <summary>
        /// The maximum wait time before a batch is sent out, even if it is incomplete.
        /// Complete batches are sent out immediately.
        /// Minimum wait time is 100 ms, maximum is one hour.
        /// </summary>
        public TimeSpan BatchFillTimeout
        {
            get
            {
                return this.batchFillTimeout;
            }

            set
            {
                if (value < MinBatchFillTimeout)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.BatchFillTimeout), $"The batch fill timeout setting cannot be less than {MinBatchFillTimeout}");
                }

                if (value > MaxBatchFillTimeout)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.BatchFillTimeout), $"The batch fill timeout setting cannot be greater than {MaxBatchFillTimeout}");
                }

                this.batchFillTimeout = value;
            }
        }

        public int MaxHttpAttempts { get; set; } = DefaultMaxHttpAttempts;
    }
}
#endif