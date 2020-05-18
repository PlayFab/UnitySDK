#if !DISABLE_PLAYFABENTITY_API
using PlayFab.DataModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<AbortFileUploadsRequest> OnDataAbortFileUploadsRequestEvent;
        public event PlayFabResultEvent<AbortFileUploadsResponse> OnDataAbortFileUploadsResultEvent;
        public event PlayFabRequestEvent<DeleteFilesRequest> OnDataDeleteFilesRequestEvent;
        public event PlayFabResultEvent<DeleteFilesResponse> OnDataDeleteFilesResultEvent;
        public event PlayFabRequestEvent<FinalizeFileUploadsRequest> OnDataFinalizeFileUploadsRequestEvent;
        public event PlayFabResultEvent<FinalizeFileUploadsResponse> OnDataFinalizeFileUploadsResultEvent;
        public event PlayFabRequestEvent<GetFilesRequest> OnDataGetFilesRequestEvent;
        public event PlayFabResultEvent<GetFilesResponse> OnDataGetFilesResultEvent;
        public event PlayFabRequestEvent<GetObjectsRequest> OnDataGetObjectsRequestEvent;
        public event PlayFabResultEvent<GetObjectsResponse> OnDataGetObjectsResultEvent;
        public event PlayFabRequestEvent<InitiateFileUploadsRequest> OnDataInitiateFileUploadsRequestEvent;
        public event PlayFabResultEvent<InitiateFileUploadsResponse> OnDataInitiateFileUploadsResultEvent;
        public event PlayFabRequestEvent<SetObjectsRequest> OnDataSetObjectsRequestEvent;
        public event PlayFabResultEvent<SetObjectsResponse> OnDataSetObjectsResultEvent;
    }
}
#endif
