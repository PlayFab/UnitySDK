#if !NET_4_6 && (NET_2_0_SUBSET || NET_2_0)
#define TPL_35
#endif

using System.Threading.Tasks;

namespace PlayFab.Pipeline
{
    public interface IEventPipeline
    {
#if TPL_35
        void StartAsync(); // Start pipeline's worker thread
#else
        Task StartAsync(); // Start pipeline's worker thread
#endif
        bool IntakeEvent(IPlayFabEmitEventRequest request); // Intake an event and return an indicator if it was accepted into pipeline. This method must be thread-safe.
        Task<IPlayFabEmitEventResponse> IntakeEventAsync(IPlayFabEmitEventRequest request); // Intake an event and return a task which completes when an event is completely processed (sent out or error returned). This method must be thread-safe.
    }
}
