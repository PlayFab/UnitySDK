#if UNITY_EDITOR

#elif UNITY_ANDROID
#define PLAYFAB_ANDROID_PLUGIN
#elif UNITY_IOS
#define PLAYFAB_IOS_PLUGIN
#endif

using System;
using PlayFab.Internal;
using System.Runtime.InteropServices;

namespace PlayFab
{
	public class PlayFabiOSPlugin
	{
		#if PLAYFAB_IOS_PLUGIN
		[DllImport("__Internal")]
		private static extern void pf_make_http_request(string url, string method, int numHeaders, string[] headers, string[] headerValues, string body, int requestId);

		private static int NextRequestId=1;

		public static bool isAvailable() { return true; }

		#else

		public static bool isAvailable() { return false; }
		#endif




		public static void init()
		{
			PlayFabPluginEventHandler.init ();
		}

		public static void Post(string url, string data, string authType, string authKey, string sdkVersion, Action<string,string> callback)
		{
			#if PLAYFAB_IOS_PLUGIN
			string[] headers = new string[4];
			string[] headerValues = new string[4];

			int h=0;
			headers[h] = "Content-Type"; headerValues[h++] = "application/json";
			if(authType != null)
			{
				headers[h] = authType; headerValues[h++] = authKey;
			}
			headers[h] = "X-ReportErrorAsSuccess"; headerValues[h++] = "true";
			headers[h] = "X-PlayFabSDK"; headerValues[h++] = sdkVersion;

			int reqId = NextRequestId++;
			PlayFabPluginEventHandler.addHttpDelegate(reqId, callback);

			pf_make_http_request(url, "POST", h, headers, headerValues, data, reqId);
			#else
			callback(null, "This method only works on iOS");
			#endif
		}
	}
}

