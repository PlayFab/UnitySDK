#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20.Transports
{
    public class SseEvent
    {
        public EventType Type { get; private set; }
        public string Data { get; private set; }

        public SseEvent(EventType type, string data)
        {
            Type = type;
            Data = data;
        }

        public static bool TryParse(string line, out SseEvent sseEvent)
        {
            sseEvent = null;

            if (line.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            {
                string data = line.Substring("data:".Length).Trim();
                sseEvent = new SseEvent(EventType.Data, data);
                return true;
            }
            else if (line.StartsWith("id:", StringComparison.OrdinalIgnoreCase))
            {
                string data = line.Substring("id:".Length).Trim();
                sseEvent = new SseEvent(EventType.Id, data);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("Type: [{0}] Data: [{1}]", Type, Data);
        }
    }

    public enum EventType
    {
        Id,
        Data
    }
}

#endif