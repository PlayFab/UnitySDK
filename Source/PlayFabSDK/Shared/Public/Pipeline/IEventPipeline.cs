#if NET_4_6
using System.Threading.Tasks;

namespace PlayFab.Pipeline
{
    public interface IEventPipeline
    {
        Task StartAsync(); // Start pipeline's worker thread
        bool IntakeEvent(IPlayFabEmitEventRequest request); // Intake an event and return an indicator if it was accepted into pipeline. This method must be thread-safe.
        Task<IPlayFabEmitEventResponse> IntakeEventAsync(IPlayFabEmitEventRequest request); // Intake an event and return a task which completes when an event is completely processed (sent out or error returned). This method must be thread-safe.
    }
}
#endif