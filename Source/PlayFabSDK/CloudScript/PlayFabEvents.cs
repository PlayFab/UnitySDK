#if !DISABLE_PLAYFABENTITY_API
using PlayFab.CloudScriptModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<ExecuteEntityCloudScriptRequest> OnCloudScriptExecuteEntityCloudScriptRequestEvent;
        public event PlayFabResultEvent<ExecuteCloudScriptResult> OnCloudScriptExecuteEntityCloudScriptResultEvent;
    }
}
#endif
