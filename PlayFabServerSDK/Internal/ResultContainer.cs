using System.Collections.Generic;
using Newtonsoft.Json;
using PlayFab;
using System;

namespace PlayFab.Internal
{
	public class ResultContainer<ResultType> where ResultType : class, new()
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

			ResultContainer<ResultType> resultEnvelope = new ResultContainer<ResultType>();
			try
			{
				JsonConvert.PopulateObject(responseStr, resultEnvelope, Util.JsonSettings);
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

			if (resultEnvelope.errorCode.HasValue)
			{
				PlayFabErrorCode errorEnum;
				try
				{
					errorEnum = (PlayFabErrorCode)resultEnvelope.errorCode.Value;
				}
				catch
				{
					errorEnum = PlayFabErrorCode.Unknown;
				}

				error = new PlayFabError
				{
					HttpCode = resultEnvelope.code,
					HttpStatus = resultEnvelope.status,
					Error = errorEnum,
					ErrorMessage = resultEnvelope.errorMessage,
					ErrorDetails = resultEnvelope.errorDetails
				};
				if(PlayFabSettings.GlobalErrorHandler != null)
					PlayFabSettings.GlobalErrorHandler(error);

				return;
			}
			
			result = resultEnvelope.data;
		}
	}
}
