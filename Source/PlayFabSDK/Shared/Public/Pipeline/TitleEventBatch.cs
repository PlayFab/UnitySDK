using System.Collections.Generic;

namespace PlayFab.Pipeline
{
    public class TitleEventBatch
    {
        public string TitleId { get; private set; }
        public List<IPlayFabEmitEventRequest> Events { get; private set; }

        public TitleEventBatch(string titleId, List<IPlayFabEmitEventRequest> events)
        {
            this.TitleId = titleId;
            this.Events = events;
        }
    }
}
