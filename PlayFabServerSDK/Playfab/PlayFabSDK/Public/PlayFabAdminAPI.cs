using System;
using PlayFab.Serialization.JsonFx;
using PlayFab.AdminModels;
using PlayFab.Internal;

namespace PlayFab
{
	
	/// <summary>
	/// APIs for managing title configurations, uploaded Game Server code executables, and user data
	/// </summary>
	public class PlayFabAdminAPI
	{
		public delegate void GetUserAccountInfoCallback(LookupUserAccountInfoResult result);
		public delegate void ResetUsersCallback(BlankResult result);
		public delegate void SendAccountRecoveryEmailCallback(SendAccountRecoveryEmailResult result);
		public delegate void UpdateUserTitleDisplayNameCallback(UpdateUserTitleDisplayNameResult result);
		public delegate void GetDataReportCallback(GetDataReportResult result);
		public delegate void GetUserDataCallback(GetUserDataResult result);
		public delegate void GetUserInternalDataCallback(GetUserDataResult result);
		public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
		public delegate void ResetUserStatisticsCallback(ResetUserStatisticsResult result);
		public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserInternalDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserReadOnlyDataCallback(UpdateUserDataResult result);
		public delegate void AddNewsCallback(AddNewsResult result);
		public delegate void AddVirtualCurrencyTypesCallback(BlankResult result);
		public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
		public delegate void GetRandomResultTablesCallback(GetRandomResultTablesResult result);
		public delegate void GetStoreItemsCallback(GetStoreItemsResult result);
		public delegate void GetTitleDataCallback(GetTitleDataResult result);
		public delegate void ListVirtualCurrencyTypesCallback(ListVirtualCurrencyTypesResult result);
		public delegate void SetCatalogItemsCallback(UpdateCatalogItemsResult result);
		public delegate void SetStoreItemsCallback(UpdateStoreItemsResult result);
		public delegate void SetTitleDataCallback(SetTitleDataResult result);
		public delegate void UpdateCatalogItemsCallback(UpdateCatalogItemsResult result);
		public delegate void UpdateRandomResultTablesCallback(UpdateRandomResultTablesResult result);
		public delegate void UpdateStoreItemsCallback(UpdateStoreItemsResult result);
		public delegate void AddUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
		public delegate void GrantItemsToUsersCallback(GrantItemsToUsersResult result);
		public delegate void RevokeInventoryItemCallback(RevokeInventoryResult result);
		public delegate void SubtractUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void GetMatchmakerGameInfoCallback(GetMatchmakerGameInfoResult result);
		public delegate void GetMatchmakerGameModesCallback(GetMatchmakerGameModesResult result);
		public delegate void ModifyMatchmakerGameModesCallback(ModifyMatchmakerGameModesResult result);
		public delegate void AddServerBuildCallback(AddServerBuildResult result);
		public delegate void GetServerBuildInfoCallback(GetServerBuildInfoResult result);
		public delegate void GetServerBuildUploadUrlCallback(GetServerBuildUploadURLResult result);
		public delegate void ListServerBuildsCallback(ListBuildsResult result);
		public delegate void ModifyServerBuildCallback(ModifyServerBuildResult result);
		public delegate void RemoveServerBuildCallback(RemoveServerBuildResult result);
		
		
		
		
		/// <summary>
		/// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
		/// </summary>
		public static void GetUserAccountInfo(LookupUserAccountInfoRequest request, GetUserAccountInfoCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LookupUserAccountInfoResult result = null;
				PlayFabError error = null;
				ResultContainer<LookupUserAccountInfoResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserAccountInfo", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Resets all title-specific information about a particular account, including user data, virtual currency balances, inventory, purchase history, and statistics
		/// </summary>
		public static void ResetUsers(ResetUsersRequest request, ResetUsersCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				BlankResult result = null;
				PlayFabError error = null;
				ResultContainer<BlankResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ResetUsers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Forces an email to be sent to the registered email address for the specified account, with a link allowing the user to change the password
		/// </summary>
		public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, SendAccountRecoveryEmailCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				SendAccountRecoveryEmailResult result = null;
				PlayFabError error = null;
				ResultContainer<SendAccountRecoveryEmailResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SendAccountRecoveryEmail", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title specific display name for a user
		/// </summary>
		public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, UpdateUserTitleDisplayNameCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserTitleDisplayNameResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserTitleDisplayNameResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserTitleDisplayName", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a download URL for the requested report
		/// </summary>
		public static void GetDataReport(GetDataReportRequest request, GetDataReportCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetDataReportResult result = null;
				PlayFabError error = null;
				ResultContainer<GetDataReportResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetDataReport", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void GetUserData(GetUserDataRequest request, GetUserDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void GetUserInternalData(GetUserDataRequest request, GetUserInternalDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void GetUserReadOnlyData(GetUserDataRequest request, GetUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Completely removes all statistics for the specified user, for the current game
		/// </summary>
		public static void ResetUserStatistics(ResetUserStatisticsRequest request, ResetUserStatisticsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ResetUserStatisticsResult result = null;
				PlayFabError error = null;
				ResultContainer<ResetUserStatisticsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ResetUserStatistics", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void UpdateUserData(UpdateUserDataRequest request, UpdateUserDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, UpdateUserInternalDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, UpdateUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds a new news item to the title's news feed
		/// </summary>
		public static void AddNews(AddNewsRequest request, AddNewsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AddNewsResult result = null;
				PlayFabError error = null;
				ResultContainer<AddNewsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddNews", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds one or more virtual currencies to the set defined for the title
		/// </summary>
		public static void AddVirtualCurrencyTypes(AddVirtualCurrencyTypesRequest request, AddVirtualCurrencyTypesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				BlankResult result = null;
				PlayFabError error = null;
				ResultContainer<BlankResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddVirtualCurrencyTypes", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
		/// </summary>
		public static void GetCatalogItems(GetCatalogItemsRequest request, GetCatalogItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetCatalogItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<GetCatalogItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetCatalogItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the random drop table configuration for the title
		/// </summary>
		public static void GetRandomResultTables(GetRandomResultTablesRequest request, GetRandomResultTablesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetRandomResultTablesResult result = null;
				PlayFabError error = null;
				ResultContainer<GetRandomResultTablesResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetRandomResultTables", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the set of items defined for the specified store, including all prices defined
		/// </summary>
		public static void GetStoreItems(GetStoreItemsRequest request, GetStoreItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetStoreItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<GetStoreItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetStoreItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the key-value store of custom title settings
		/// </summary>
		public static void GetTitleData(GetTitleDataRequest request, GetTitleDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetTitleDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetTitleDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetTitleData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retuns the list of all defined virtual currencies for the title
		/// </summary>
		public static void ListVirtualCurrencyTypes(ListVirtualCurrencyTypesRequest request, ListVirtualCurrencyTypesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ListVirtualCurrencyTypesResult result = null;
				PlayFabError error = null;
				ResultContainer<ListVirtualCurrencyTypesResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ListVirtualCurrencyTypes", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Creates the catalog configuration of all virtual goods for the specified catalog version
		/// </summary>
		public static void SetCatalogItems(UpdateCatalogItemsRequest request, SetCatalogItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateCatalogItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateCatalogItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetCatalogItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Sets all the items in one virtual store
		/// </summary>
		public static void SetStoreItems(UpdateStoreItemsRequest request, SetStoreItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateStoreItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateStoreItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetStoreItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Creates and updates the key-value store of custom title settings
		/// </summary>
		public static void SetTitleData(SetTitleDataRequest request, SetTitleDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				SetTitleDataResult result = null;
				PlayFabError error = null;
				ResultContainer<SetTitleDataResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetTitleData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the catalog configuration for virtual goods in the specified catalog version
		/// </summary>
		public static void UpdateCatalogItems(UpdateCatalogItemsRequest request, UpdateCatalogItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateCatalogItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateCatalogItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateCatalogItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the random drop table configuration for the title
		/// </summary>
		public static void UpdateRandomResultTables(UpdateRandomResultTablesRequest request, UpdateRandomResultTablesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateRandomResultTablesResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateRandomResultTablesResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateRandomResultTables", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates an existing virtual item store with new or modified items
		/// </summary>
		public static void UpdateStoreItems(UpdateStoreItemsRequest request, UpdateStoreItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateStoreItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateStoreItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateStoreItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Increments the specified virtual currency by the stated amount
		/// </summary>
		public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, AddUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ModifyUserVirtualCurrencyResult result = null;
				PlayFabError error = null;
				ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddUserVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified user's current inventory of virtual goods
		/// </summary>
		public static void GetUserInventory(GetUserInventoryRequest request, GetUserInventoryCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserInventoryResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserInventoryResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserInventory", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds the specified items to the specified user inventories
		/// </summary>
		public static void GrantItemsToUsers(GrantItemsToUsersRequest request, GrantItemsToUsersCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GrantItemsToUsersResult result = null;
				PlayFabError error = null;
				ResultContainer<GrantItemsToUsersResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GrantItemsToUsers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Revokes access to an item in a user's inventory
		/// </summary>
		public static void RevokeInventoryItem(RevokeInventoryItemRequest request, RevokeInventoryItemCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RevokeInventoryResult result = null;
				PlayFabError error = null;
				ResultContainer<RevokeInventoryResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/RevokeInventoryItem", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Decrements the specified virtual currency by the stated amount
		/// </summary>
		public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, SubtractUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ModifyUserVirtualCurrencyResult result = null;
				PlayFabError error = null;
				ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SubtractUserVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the details for a specific completed session, including links to standard out and standard error logs
		/// </summary>
		public static void GetMatchmakerGameInfo(GetMatchmakerGameInfoRequest request, GetMatchmakerGameInfoCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetMatchmakerGameInfoResult result = null;
				PlayFabError error = null;
				ResultContainer<GetMatchmakerGameInfoResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetMatchmakerGameInfo", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the details of defined game modes for the specified game server executable
		/// </summary>
		public static void GetMatchmakerGameModes(GetMatchmakerGameModesRequest request, GetMatchmakerGameModesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetMatchmakerGameModesResult result = null;
				PlayFabError error = null;
				ResultContainer<GetMatchmakerGameModesResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetMatchmakerGameModes", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the game server mode details for the specified game server executable
		/// </summary>
		public static void ModifyMatchmakerGameModes(ModifyMatchmakerGameModesRequest request, ModifyMatchmakerGameModesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ModifyMatchmakerGameModesResult result = null;
				PlayFabError error = null;
				ResultContainer<ModifyMatchmakerGameModesResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ModifyMatchmakerGameModes", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds the game server executable specified (previously uploaded - see GetServerBuildUploadUrl) to the set of those a client is permitted to request in a call to StartGame
		/// </summary>
		public static void AddServerBuild(AddServerBuildRequest request, AddServerBuildCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AddServerBuildResult result = null;
				PlayFabError error = null;
				ResultContainer<AddServerBuildResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddServerBuild", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the build details for the specified game server executable
		/// </summary>
		public static void GetServerBuildInfo(GetServerBuildInfoRequest request, GetServerBuildInfoCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetServerBuildInfoResult result = null;
				PlayFabError error = null;
				ResultContainer<GetServerBuildInfoResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetServerBuildInfo", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the pre-authorized URL for uploading a game server package containing a build (does not enable the build for use - see AddServerBuild)
		/// </summary>
		public static void GetServerBuildUploadUrl(GetServerBuildUploadURLRequest request, GetServerBuildUploadUrlCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetServerBuildUploadURLResult result = null;
				PlayFabError error = null;
				ResultContainer<GetServerBuildUploadURLResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetServerBuildUploadUrl", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the build details for all game server executables which are currently defined for the title
		/// </summary>
		public static void ListServerBuilds(ListBuildsRequest request, ListServerBuildsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ListBuildsResult result = null;
				PlayFabError error = null;
				ResultContainer<ListBuildsResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ListServerBuilds", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the build details for the specified game server executable
		/// </summary>
		public static void ModifyServerBuild(ModifyServerBuildRequest request, ModifyServerBuildCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ModifyServerBuildResult result = null;
				PlayFabError error = null;
				ResultContainer<ModifyServerBuildResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ModifyServerBuild", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Removes the game server executable specified from the set of those a client is permitted to request in a call to StartGame
		/// </summary>
		public static void RemoveServerBuild(RemoveServerBuildRequest request, RemoveServerBuildCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RemoveServerBuildResult result = null;
				PlayFabError error = null;
				ResultContainer<RemoveServerBuildResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/RemoveServerBuild", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		
		
	}
}

