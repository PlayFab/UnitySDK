using System.Collections.Generic;
using PlayFab.Json;
using PlayFab;
using System;
using System.Net;

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
		
		public static void HandleResults(string responseStr, ref PlayFabError pfError, out ResultType result)
		{
			result = null;

			if(pfError != null)
			{
                if (PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(pfError);
				return;
			}

			ResultContainer<ResultType> resultEnvelope = new ResultContainer<ResultType>();
			try
			{
				JsonConvert.PopulateObject(responseStr, resultEnvelope, Util.JsonSettings);
			}
			catch(Exception e)
			{
                pfError = new PlayFabError();
                pfError.HttpCode = (int)HttpStatusCode.OK; // Technically we did get a result from the server
                pfError.HttpStatus = "Client failed to parse response from server";
                pfError.Error = PlayFabErrorCode.Unknown;
                pfError.ErrorMessage = e.ToString();
                pfError.ErrorDetails = null;
				if(PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(pfError);
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

                pfError = new PlayFabError
				{
					HttpCode = resultEnvelope.code,
					HttpStatus = resultEnvelope.status,
					Error = errorEnum,
					ErrorMessage = resultEnvelope.errorMessage,
					ErrorDetails = resultEnvelope.errorDetails
				};
				if(PlayFabSettings.GlobalErrorHandler != null)
                    PlayFabSettings.GlobalErrorHandler(pfError);

				return;
			}
			
			result = resultEnvelope.data;
		}
	}
}
