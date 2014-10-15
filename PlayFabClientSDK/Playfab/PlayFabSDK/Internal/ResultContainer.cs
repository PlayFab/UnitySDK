using System.Collections.Generic;
using PlayFab.Serialization.JsonFx;
using PlayFab;
using System;

namespace PlayFab.Internal
{
	public class ResultContainer<ResultType> where ResultType : PlayFabModelBase, new()
	{
		public int code;
		public string status;
		public string error;
		public int? errorCode;
		public string errorMessage;
		public Dictionary<string, List<string> > errorDetails;
		public ResultType data;
		
		public static void HandleResults(string responseStr, string errorStr, out ResultType result, out PlayFabError error)
		{
			result = null;
			error = null;

			if(errorStr != null)
			{
				error = new PlayFabError();
				if(PlayFabSettings.GlobalErrorHandler != null)
					PlayFabSettings.GlobalErrorHandler(error);
				return;
			}

			ResultType parsedResult = null;
			Dictionary<String, object> rawResultEnvelope = null;
			try
			{
				rawResultEnvelope = (Dictionary<String, object>)JsonReader.Deserialize(responseStr, Util.GlobalJsonReaderSettings);
				if(rawResultEnvelope.ContainsKey("data"))
				{
					Dictionary<String, object> rawResult = (Dictionary<String, object>)rawResultEnvelope["data"];
					parsedResult = new ResultType();
					parsedResult.Deserialize(rawResult);
				}
			}
			catch(Exception e)
			{
				error = new PlayFabError();
				error.Error = PlayFabErrorCode.Unknown;
				error.ErrorMessage = e.ToString();
				if(PlayFabSettings.GlobalErrorHandler != null)
					PlayFabSettings.GlobalErrorHandler(error);
				return;
			}

			if (rawResultEnvelope.ContainsKey("errorCode"))
			{
				PlayFabErrorCode errorEnum;
				try
				{
					errorEnum = (PlayFabErrorCode)(int)(double)rawResultEnvelope["errorCode"];
				}
				catch
				{
					errorEnum = PlayFabErrorCode.Unknown;
				}

				Dictionary<string, List<string>> errorDetails = null;
				if(rawResultEnvelope.ContainsKey("errorDetails"))
				{
					Dictionary<string,object> rawErrorDetails = (Dictionary<string,object>)rawResultEnvelope["errorDetails"];
					errorDetails = new Dictionary<string, List<string>> ();
					foreach(string key in rawErrorDetails.Keys)
					{
						object[] keyErrors = (object[])rawErrorDetails[key];
						List<string> errorList = new List<string>();
						for(int i=0; i<keyErrors.Length; i++)
						{
							errorList.Add ((string)keyErrors[i]);
						}
						errorDetails.Add (key, errorList);
					}
				}

				error = new PlayFabError
				{
					HttpCode = (int)(double)rawResultEnvelope["code"],
					HttpStatus = (string)rawResultEnvelope["status"],
					Error = errorEnum,
					ErrorMessage = (string)rawResultEnvelope["errorMessage"],
					ErrorDetails = errorDetails
				};
				if(PlayFabSettings.GlobalErrorHandler != null)
					PlayFabSettings.GlobalErrorHandler(error);

				return;
			}
			
			result = parsedResult;
		}
	}
}

