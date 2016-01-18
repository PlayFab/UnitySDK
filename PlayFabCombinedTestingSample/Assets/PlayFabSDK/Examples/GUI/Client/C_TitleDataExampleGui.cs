
namespace PlayFab.Examples.Client
{
    public class C_TitleDataExampleGui : PfExampleGui
    {
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

            DisplayReadOnlyDataHelper(ref rowIndex, "TitleData", PfSharedModelEx.titleData, TitleDataExample.GetTitleData);
            DisplayReadOnlyDataHelper(ref rowIndex, "PublisherData", PfSharedModelEx.publisherData, TitleDataExample.GetPublisherData);
        }
        #endregion Unity GUI
    }
}
