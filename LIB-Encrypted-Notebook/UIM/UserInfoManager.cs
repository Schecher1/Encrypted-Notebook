using System.Security;
using LIB_Encrypted_Notebook.DataModels;

namespace LIB_Encrypted_Notebook.UIM
{
    public class UserInfoManager
    {
        public static string UserName;
        public static SecureString UserPassword;
        public static int UserID;
        public static string UserActivNotebook;
        public static byte[] UserSalt;
        public static int UserActivNotebookID;
        public static List<DataModelNotebook> User_Notebooks;
        public static DataModelUser ActivUserDataModel;

        public static void UserLogout()
        {
            UserName = null;
            UserActivNotebook = null;
            UserID = -1;
            UserSalt = new byte[] { 0 };
            ActivUserDataModel = null;
            UserPassword.Clear();
            GC.Collect();
        }
    }
}
