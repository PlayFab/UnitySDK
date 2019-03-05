namespace PlayFab.SharedModels
{
    public class HttpResponseObject
    {
        public int code;
        public string status;
        public object data;
    }

    public class PlayFabRequestCommon
    {
        public PlayFabAuthenticationContext AuthenticationContext;
    }

    public class PlayFabResultCommon
    {
        public PlayFabRequestCommon Request;
        public object CustomData;
    }
    
    public class PlayFabLoginResultCommon : PlayFabResultCommon
    {
        public PlayFabAuthenticationContext AuthenticationContext;
    }
}
