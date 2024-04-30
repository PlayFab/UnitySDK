#if !DISABLE_PLAYFABENTITY_API
using PlayFab.CloudScriptModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<ExecuteEntityCloudScriptRequest> OnCloudScriptExecuteEntityCloudScriptRequestEvent;
        public event PlayFabResultEvent<ExecuteCloudScriptResult> OnCloudScriptExecuteEntityCloudScriptResultEvent;
        public event PlayFabRequestEvent<ExecuteFunctionRequest> OnCloudScriptExecuteFunctionRequestEvent;
        public event PlayFabResultEvent<ExecuteFunctionResult> OnCloudScriptExecuteFunctionResultEvent;
        public event PlayFabRequestEvent<GetFunctionRequest> OnCloudScriptGetFunctionRequestEvent;
        public event PlayFabResultEvent<GetFunctionResult> OnCloudScriptGetFunctionResultEvent;
        public event PlayFabRequestEvent<ListFunctionsRequest> OnCloudScriptListEventHubFunctionsRequestEvent;
        public event PlayFabResultEvent<ListEventHubFunctionsResult> OnCloudScriptListEventHubFunctionsResultEvent;
        public event PlayFabRequestEvent<ListFunctionsRequest> OnCloudScriptListFunctionsRequestEvent;
        public event PlayFabResultEvent<ListFunctionsResult> OnCloudScriptListFunctionsResultEvent;
        public event PlayFabRequestEvent<ListFunctionsRequest> OnCloudScriptListHttpFunctionsRequestEvent;
        public event PlayFabResultEvent<ListHttpFunctionsResult> OnCloudScriptListHttpFunctionsResultEvent;
        public event PlayFabRequestEvent<ListFunctionsRequest> OnCloudScriptListQueuedFunctionsRequestEvent;
        public event PlayFabResultEvent<ListQueuedFunctionsResult> OnCloudScriptListQueuedFunctionsResultEvent;
        public event PlayFabRequestEvent<PostFunctionResultForEntityTriggeredActionRequest> OnCloudScriptPostFunctionResultForEntityTriggeredActionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptPostFunctionResultForEntityTriggeredActionResultEvent;
        public event PlayFabRequestEvent<PostFunctionResultForFunctionExecutionRequest> OnCloudScriptPostFunctionResultForFunctionExecutionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptPostFunctionResultForFunctionExecutionResultEvent;
        public event PlayFabRequestEvent<PostFunctionResultForPlayerTriggeredActionRequest> OnCloudScriptPostFunctionResultForPlayerTriggeredActionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptPostFunctionResultForPlayerTriggeredActionResultEvent;
        public event PlayFabRequestEvent<PostFunctionResultForScheduledTaskRequest> OnCloudScriptPostFunctionResultForScheduledTaskRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptPostFunctionResultForScheduledTaskResultEvent;
        public event PlayFabRequestEvent<RegisterEventHubFunctionRequest> OnCloudScriptRegisterEventHubFunctionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptRegisterEventHubFunctionResultEvent;
        public event PlayFabRequestEvent<RegisterHttpFunctionRequest> OnCloudScriptRegisterHttpFunctionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptRegisterHttpFunctionResultEvent;
        public event PlayFabRequestEvent<RegisterQueuedFunctionRequest> OnCloudScriptRegisterQueuedFunctionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptRegisterQueuedFunctionResultEvent;
        public event PlayFabRequestEvent<UnregisterFunctionRequest> OnCloudScriptUnregisterFunctionRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnCloudScriptUnregisterFunctionResultEvent;
    }
}
#endif
