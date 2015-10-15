
namespace PlayFab.Examples.Client
{
    public class C_LoginExampleGui : PfExampleGui
    {
        public string titleId = "Set your titleId here";
        public string devSecretKey = "Set your title secret key here";

        public string userName = "test username"; // Pick an existing valid username for this title
        public string email = "test@email.com"; // The email assigned to the user above
        public string password = "test password"; // The password for the user above

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();

            // Login
            Button(!isLoggedIn, rowIndex, 0, "Login", () => { LoginExample.LoginWithEmail(titleId, devSecretKey, email, password); });
        }
        #endregion Unity GUI
    }
}
