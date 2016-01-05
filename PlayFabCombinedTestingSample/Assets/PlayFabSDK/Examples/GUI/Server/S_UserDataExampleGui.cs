using System.Collections.Generic;
using System.Reflection;

namespace PlayFab.Examples.Server
{
    public class S_UserDataExampleGui : PfExampleGui
    {
        private static readonly MethodInfo UserDataExample_GetUserData = typeof(UserDataExample).GetMethod("GetUserData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_UpdateUserData = typeof(UserDataExample).GetMethod("UpdateUserData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_GetUserReadOnlyData = typeof(UserDataExample).GetMethod("GetUserReadOnlyData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_UpdateReadOnlyUserData = typeof(UserDataExample).GetMethod("UpdateReadOnlyUserData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_GetUserInternalData = typeof(UserDataExample).GetMethod("GetUserInternalData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_UpdateInternalUserData = typeof(UserDataExample).GetMethod("UpdateInternalUserData", BindingFlags.Static | BindingFlags.Public);

        private static readonly MethodInfo UserDataExample_GetUserPublisherData = typeof(UserDataExample).GetMethod("GetUserPublisherData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_UpdateUserPublisherData = typeof(UserDataExample).GetMethod("UpdateUserPublisherData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_GetUserPublisherReadOnlyData = typeof(UserDataExample).GetMethod("GetUserPublisherReadOnlyData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_UpdateReadOnlyUserPublisherData = typeof(UserDataExample).GetMethod("UpdateReadOnlyUserPublisherData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_GetUserPublisherInternalData = typeof(UserDataExample).GetMethod("GetUserPublisherInternalData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_UpdateInternalUserPublisherData = typeof(UserDataExample).GetMethod("UpdateInternalUserPublisherData", BindingFlags.Static | BindingFlags.Public);

        private string _newUserDataKey = "<new key>";
        private string _newUserDataValue = "";
        private string _newUserReadOnlyDataKey = "<new key>";
        private string _newUserReadOnlyDataValue = "";
        private string _newUserInternalDataKey = "<new key>";
        private string _newUserInternalDataValue = "";
        private string _newUserPubDataKey = "<new key>";
        private string _newUserPubDataValue = "";
        private string _newUserReadOnlyPubDataKey = "<new key>";
        private string _newUserReadOnlyPubDataValue = "";
        private string _newUserInternalPubDataKey = "<new key>";
        private string _newUserInternalPubDataValue = "";

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, string> _existingUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingReadOnlyUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingInternalUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingPubValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingReadOnlyPubValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingInternalPubValues = new Dictionary<string, string>();

        public void Awake()
        {
            UserDataExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            if (!isLoggedIn)
                return;

            foreach (var serverUserPair in PfSharedModelEx.serverUsers)
            {
                string playFabId = serverUserPair.Key;
                var eachUser = serverUserPair.Value;

                TextField(true, rowIndex, 0, "PlayerId:");
                TextField(true, rowIndex, 1, playFabId);
                rowIndex++;
                rowIndex++;

                DisplayDataHelper(ref rowIndex, "UserData", playFabId, null, eachUser.userData, UserDataExample_GetUserData, UserDataExample_UpdateUserData, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
                DisplayDataHelper(ref rowIndex, "RO-UserData", playFabId, null, eachUser.userReadOnlyData, UserDataExample_GetUserReadOnlyData, UserDataExample_UpdateReadOnlyUserData, _existingReadOnlyUserValues, ref _newUserReadOnlyDataKey, ref _newUserReadOnlyDataValue);
                DisplayDataHelper(ref rowIndex, "InternalData", playFabId, null, eachUser.userInternalData, UserDataExample_GetUserInternalData, UserDataExample_UpdateInternalUserData, _existingInternalUserValues, ref _newUserInternalDataKey, ref _newUserInternalDataValue);
                rowIndex++;

                DisplayDataHelper(ref rowIndex, "UserPubData", playFabId, null, eachUser.userPublisherData, UserDataExample_GetUserPublisherData, UserDataExample_UpdateUserPublisherData, _existingPubValues, ref _newUserPubDataKey, ref _newUserPubDataValue);
                DisplayDataHelper(ref rowIndex, "RO-UserPubData", playFabId, null, eachUser.userPublisherReadOnlyData, UserDataExample_GetUserPublisherReadOnlyData, UserDataExample_UpdateReadOnlyUserPublisherData, _existingReadOnlyPubValues, ref _newUserReadOnlyPubDataKey, ref _newUserReadOnlyPubDataValue);
                DisplayDataHelper(ref rowIndex, "InternalPubData", playFabId, null, eachUser.userPublisherInternalData, UserDataExample_GetUserPublisherInternalData, UserDataExample_UpdateInternalUserPublisherData, _existingInternalPubValues, ref _newUserInternalPubDataKey, ref _newUserInternalPubDataValue);
            }
        }
        #endregion Unity GUI
    }
}
