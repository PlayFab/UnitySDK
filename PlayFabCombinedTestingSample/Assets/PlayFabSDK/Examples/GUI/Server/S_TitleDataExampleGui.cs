using System.Collections.Generic;
using System.Reflection;

namespace PlayFab.Examples.Server
{
    public class S_TitleDataExampleGui : PfExampleGui
    {
        private static readonly MethodInfo TitleDataExample_SetTitleData = typeof(TitleDataExample).GetMethod("SetTitleData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo TitleDataExample_SetTitleInternalData = typeof(TitleDataExample).GetMethod("SetTitleInternalData", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo TitleDataExample_SetPublisherData = typeof(TitleDataExample).GetMethod("SetPublisherData", BindingFlags.Static | BindingFlags.Public);

        private string _newTitleDataKey = "<new key>";
        private string _newTitleDataValue = "";
        private string _newTitleInternalDataKey = "<new key>";
        private string _newTitleInternalDataValue = "";
        private string _newPubDataKey = "<new key>";
        private string _newPubDataValue = "";

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, string> _existingTitleValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingInternalValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingPublisherValues = new Dictionary<string, string>();

        public void Awake()
        {
            TitleDataExample.SetUp();
        }


        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            if (!isLoggedIn)
                return;

            DisplayDataHelper(ref rowIndex, "TitleData", PfSharedModelEx.titleData, TitleDataExample.GetTitleData, TitleDataExample_SetTitleData, _existingTitleValues, ref _newTitleDataKey, ref _newTitleDataValue);
            DisplayDataHelper(ref rowIndex, "InternalTitleData", PfSharedModelEx.titleInternalData, TitleDataExample.GetTitleInternalData, TitleDataExample_SetTitleInternalData, _existingInternalValues, ref _newTitleInternalDataKey, ref _newTitleInternalDataValue);
            DisplayDataHelper(ref rowIndex, "PublisherData", PfSharedModelEx.publisherData, TitleDataExample.GetPublisherData, TitleDataExample_SetPublisherData, _existingPublisherValues, ref _newPubDataKey, ref _newPubDataValue);
        }
        #endregion Unity GUI
    }
}
