using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.EventsModels;
using PlayFab.Internal;

// Data types compliant with OneDS Common Schema 3.0:
using OneDSEventData = Microsoft.Applications.Events.DataModels.Data;
using OneDSValue = Microsoft.Applications.Events.DataModels.Value;
using OneDSValueKind = Microsoft.Applications.Events.DataModels.ValueKind;

// This file contains declaration of base interfaces for any custom playstream events
// as well as PlayFab-specific implementations

namespace PlayFab
{
    /// <summary>
    /// The enumeration of all possible "types" of events
    /// </summary>
    public enum PlayFabEventType
    {
        Default, // Default type (e.g. the one set by global configuration)
        Lightweight, // Event is meant to bypass processing on the PlayFab server side and be sent instead directly to One Collector (1DS).
        Heavyweight // Event is meant to be sent to the PlayFab server.
    }

    /// <summary>
    /// Possible outcomes of "emit event" operations
    /// </summary>
    public enum EmitEventResult
    {
        Success, // An event was successfully emitted
        Overflow, // An event wasn't emitted because the emitter capacity is full
        Disabled, // An event wasn't emitted because the emitter is disabled (its functionality is "turned off")
        NotSupported // An event wasn't emitted because the emitter doesn't support the operation
    }

    /// <summary>
    /// Interface for any event
    /// </summary>
    public interface IPlayFabEvent
    {
    }

    /// <summary>
    /// Interface for any emit event request
    /// </summary>
    public interface IPlayFabEmitEventRequest
    {
    }

    /// <summary>
    /// Interface for any emit event response
    /// </summary>
    public interface IPlayFabEmitEventResponse
    {
    }

    /// <summary>
    // A callback that can be used in asynchronous emit event operations that take IPlayFabEvent as a parameter
    // and return back an IPlayFabEmitEventResponse. The callback procedure must be thread-safe.
    /// </summary>
    /// <param name="playFabEvent">The event</param>
    /// <param name="emitEventResponse">The response of emit event operation</param>
    public delegate void PlayFabEmitEventCallback(IPlayFabEvent playFabEvent, IPlayFabEmitEventResponse emitEventResponse);

    /// <summary>
    /// PlayFab-specific implementation of an event
    /// </summary>
    public class PlayFabEvent : IPlayFabEvent
    {
        /// <summary>
        /// Gets or sets the event "type" (Lightweight|Heavyweight)
        /// </summary>
        public PlayFabEventType EventType { get; set; }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        public string Name
        {
            get { return this.EventContents.Name; }
            set { this.EventContents.Name = value; }
        }

        internal EventContents EventContents { get; private set; }

        /// <summary>
        /// Creates a default instance of an event.
        /// </summary>
        public PlayFabEvent()
        {
            this.EventType = PlayFabEventType.Default;
            this.EventContents = new EventContents
            {
                EventNamespace = "com.playfab.events.default",
                Payload = new OneDSEventData()
            };
        }

        public void SetProperty(string name, string value)
        {
            OneDSValue oneDSValue = new OneDSValue
            {
                type = OneDSValueKind.ValueString,
                stringValue = value
            };

            ((OneDSEventData)this.EventContents.Payload).properties[name] = oneDSValue;
        }

        public void SetProperty(string name, bool value)
        {
            OneDSValue oneDSValue = new OneDSValue
            {
                type = OneDSValueKind.ValueBool,
                longValue = value ? 1 : 0
            };

            ((OneDSEventData)this.EventContents.Payload).properties[name] = oneDSValue;
        }

        public void SetProperty(string name, DateTime value)
        {
            OneDSValue oneDSValue = new OneDSValue
            {
                type = OneDSValueKind.ValueDateTime,
                longValue = value.ToUniversalTime().Ticks
            };

            ((OneDSEventData)this.EventContents.Payload).properties[name] = oneDSValue;
        }

        public void SetProperty(string name, long value)
        {
            OneDSValue oneDSValue = new OneDSValue
            {
                type = OneDSValueKind.ValueInt64,
                longValue = value
            };

            ((OneDSEventData)this.EventContents.Payload).properties[name] = oneDSValue;
        }

        public void SetProperty(string name, double value)
        {
            OneDSValue oneDSValue = new OneDSValue
            {
                type = OneDSValueKind.ValueDouble,
                doubleValue = value
            };

            ((OneDSEventData)this.EventContents.Payload).properties[name] = oneDSValue;
        }

        public void SetProperty(string name, Guid value)
        {
            OneDSValue oneDSValue = new OneDSValue
            {
                type = OneDSValueKind.ValueGuid,
                guidValue = new List<List<byte>> { new List<byte>(value.ToByteArray()) }
            };

            ((OneDSEventData)this.EventContents.Payload).properties[name] = oneDSValue;
        }
    }

    /// <summary>
    /// PlayFab-specific implementation of an emit event request
    /// </summary>
    public class PlayFabEmitEventRequest : IPlayFabEmitEventRequest
    {
        /// <summary>
        /// Gets or sets a pointer to the user's event object itself
        /// </summary>
        public PlayFabEvent Event { get; set; }

        /// <summary>
        /// The title id is used to batch and send the events to a particular destination (e.g. can be used in the DNS name of the PlayFab endpoints)
        /// </summary>
        public string TitleId = "default";

        /// <summary>
        /// A promise to return IPlayFabEmitEventResponse when event is processed by pipeline.
        /// This can be set optionally.
        /// </summary>
        public TaskCompletionSource<IPlayFabEmitEventResponse> ResultPromise { get; set; }
    }

    public class PlayFabEmitEventResponse : IPlayFabEmitEventResponse
    {
        /// <summary>
        /// Gets or sets a pointer to the user's event object itself
        /// </summary>
        public PlayFabEvent Event { get; set; }

        /// <summary>
        /// Gets or sets the result of immediate "emit event" operation
        /// </summary>
        public EmitEventResult EmitEventResult { get; set; }

        /// <summary>
        /// Gets or sets the error information and/or operation result
        /// </summary>
        public OneDsError PlayFabError { get; set; }

        /// <summary>
        /// Gets or sets the additional data with the outcome of the operation
        /// </summary>
        public WriteEventsResponse WriteEventsResponse { get; set; }

        /// <summary>
        /// Gets or sets the batch this event was part of
        /// </summary>
        public IList<IPlayFabEmitEventRequest> Batch { get; set; }

        /// <summary>
        /// Gets or sets the incremental batch number
        /// </summary>
        ulong BatchNumber { get; set; }
    }
}
