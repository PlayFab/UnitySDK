#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using SignalR.Client._20.Transports;

namespace SignalR.Client._20.Http
{
    public class DefaultHttpClient : IHttpClient
    {
        public EventSignal<IResponse> GetAsync(string url, Action<IRequest> prepareRequest)
        {
            var _returnSignal = new EventSignal<IResponse>();
            var _signal = HttpHelper.GetAsync(url, request => prepareRequest(new HttpWebRequestWrapper(request)));

            _signal.Finished += (sender, e) => _returnSignal.OnFinish(new HttpWebResponseWrapper(e.Result.Result)
            {
                Exception = e.Result.Exception,
                IsFaulted = e.Result.IsFaulted
            });

            return _returnSignal;
        }

        public EventSignal<IResponse> PostAsync(string url, Action<IRequest> prepareRequest, Dictionary<string, string> postData)
        {
            var _returnSignal = new EventSignal<IResponse>();
            var _signal = HttpHelper.PostAsync(url, request =>
                prepareRequest(new HttpWebRequestWrapper(request)), postData);

            _signal.Finished += (sender, e) => _returnSignal.OnFinish(
                new HttpWebResponseWrapper(e.Result.Result)
                {
                    Exception = e.Result.Exception,
                    IsFaulted = e.Result.IsFaulted
                });
            return _returnSignal;
        }
    }
}

#endif