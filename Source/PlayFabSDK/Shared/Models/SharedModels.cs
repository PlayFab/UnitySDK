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
    }

    public class PlayFabResultCommon
    {
        public PlayFabRequestCommon Request;
        public object CustomData;
    }
}
