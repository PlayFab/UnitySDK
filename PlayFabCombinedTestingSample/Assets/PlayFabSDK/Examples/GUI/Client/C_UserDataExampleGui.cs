using System.Collections.Generic;
using System.Reflection;

namespace PlayFab.Examples.Client
{
    public class C_UserDataExampleGui : PfExampleGui
    {
        private static readonly MethodInfo UserDataExample_UpdateUserData = typeof(UserDataExample).GetMethod("UpdateUserData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo UserDataExample_UpdatePublisherdata = typeof(UserDataExample).GetMethod("UpdatePublisherdata", BindingFlags.Static | BindingFlags.Public);

        private string _newUserDataKey = "<new key>";
        private string _newUserDataValue = "";
        private string _newUserPubDataKey = "<new key>";
        private string _newUserPubDataValue = "";

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, string> _existingUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingPubValues = new Dictionary<string, string>();

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

            DisplayDataHelper(ref rowIndex, "UserData", PfSharedModelEx.globalClientUser.userData, UserDataExample.GetUserData, UserDataExample_UpdateUserData, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
            DisplayReadOnlyDataHelper(ref rowIndex, "RO-UserData", PfSharedModelEx.globalClientUser.userReadOnlyData, UserDataExample.GetUserReadOnlyData);
            // Client doesn't have access to internal user data
            rowIndex++;

            DisplayDataHelper(ref rowIndex, "UserPubData", PfSharedModelEx.globalClientUser.userPublisherData, UserDataExample.GetUserPublisherData, UserDataExample_UpdatePublisherdata, _existingPubValues, ref _newUserPubDataKey, ref _newUserPubDataValue);
            DisplayReadOnlyDataHelper(ref rowIndex, "RO-UserPubData", PfSharedModelEx.globalClientUser.userPublisherReadOnlyData, UserDataExample.GetUserPublisherReadOnlyData);
            // Client doesn't have access to internal user publisher data
        }
        #endregion Unity GUI
    }
}
