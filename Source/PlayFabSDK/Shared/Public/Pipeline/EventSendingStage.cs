using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayFab.EventsModels;
using PlayFab.Logger;
using PlayFab.SharedModels;

namespace PlayFab.Pipeline
{
    /// <summary>
    /// The event sending stage.
    /// </summary>
    internal class EventSendingStage : PipelineStageBase<TitleEventBatch, PlayFabResult<WriteEventsResponse>>
    {
        private OneDSEventsAPI oneDSEventsApi;
        private ILogger logger;

        public EventSendingStage(ILogger logger)
        {
            this.logger = logger;
            this.oneDSEventsApi = new OneDSEventsAPI();
        }

        /// <summary>
        /// This method is called by pipeline for each available input item (a batch of events)
        /// </summary>
        /// <param name="batch">The input item (a batch of events).</param>
        protected override void OnNextInputItem(TitleEventBatch batch)
        {
            // Send a batch and wait for result
            var writeEventsRequest = new WriteEventsRequest
            {
                Events = batch.Events.Cast<PlayFabEmitEventRequest>().Select(x => x.Event.EventContents).ToList()
            };

            if (!oneDSEventsApi.IsOneDSAuthenticated)
            {
                var authResult = OneDSEventsAPI.GetTelemetryIngestionConfigAsync(new TelemetryIngestionConfigRequest());
                try
                {
                    authResult.Wait(cts.Token);
                    var response = authResult.Result.Result;
                    if (response != null)
                    {
                        oneDSEventsApi.SetCredentials("o:" + response.TenantId, response.IngestionKey, response.TelemetryJwtToken, response.TelemetryJwtHeaderKey, response.TelemetryJwtHeaderPrefix);
                    }
                    else
                    {
                        throw new Exception("Failed to get OneDS authentication token from PlayFab service");
                    }
                }
                catch (Exception e)
                {
                    // Cancel result promises that will never be fulfilled
                    // and move on to the next batch.
                    foreach (var request in batch.Events)
                    {
                        PlayFabEmitEventRequest eventRequest = (PlayFabEmitEventRequest)request;
                        if (eventRequest.ResultPromise != null)
                        {
                            eventRequest.ResultPromise.SetCanceled();
                        }
                    }

                    logger.Error(string.Format("Exception in OnNextInputItem {0} with message: {1}.", e.Source, e));
                }
            }

            Task<PlayFabResult<WriteEventsResponse>> apiTask = oneDSEventsApi.WriteTelemetryEventsAsync(writeEventsRequest);
            try
            {
                apiTask.Wait(cts.Token);
                FulfillPromises(batch.Events, apiTask.Result);
            }
            catch (Exception e)
            {
                // Cancel result promises that will never be fulfilled
                // and move on to the next batch.
                foreach (var request in batch.Events)
                {
                    PlayFabEmitEventRequest eventRequest = (PlayFabEmitEventRequest)request;
                    if (eventRequest.ResultPromise != null)
                    {
                        eventRequest.ResultPromise.SetCanceled();
                    }
                }

                logger.Error(string.Format("Exception in OnNextInputItem {0} with message: {1}. This was an unhandled exception, please contact the dev team.", e.Source, e));
            }
        }

        private void FulfillPromises(List<IPlayFabEmitEventRequest> batch, PlayFabResult<WriteEventsResponse> playFabResult)
        {
            PlayFabEmitEventRequest eventRequest;
            for (int i = 0; i < batch.Count; i++)
            {
                // only fulfill given promises
                eventRequest = (PlayFabEmitEventRequest)batch[i];
                if (eventRequest.ResultPromise != null)
                {
                    var result = new PlayFabEmitEventResponse
                    {
                        Event = eventRequest.Event,
                        EmitEventResult = EmitEventResult.Success,
                        WriteEventsResponse = playFabResult.Result,
                        PlayFabError = playFabResult.Error,
                        Batch = batch
                    };

                    eventRequest.ResultPromise.SetResult(result);
                }
            }
        }
    }
}
