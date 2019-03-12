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

    public class PlayFabResult<TResult> where TResult : PlayFabResultCommon
    {
        public TResult Result;
        public object CustomData;
        public PlayFabError Error;
    }
}
