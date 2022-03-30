using System.Security;
using LIB_Encrypted_Notebook.DataModels;

namespace LIB_Encrypted_Notebook.UIM
{
    public class UserInfoManager
    {
        public static int UserID;
        public static string UserName;
        public static SecureString UserPassword;
        public static string UserActivNotebook;
        public static byte[] UserSalt;
        public static int UserActivNotebookID;
        public static List<DataModelNotebook> User_DecryptedNotebooks;
        public static List<DataModelNotebook> User_EncryptedNotebooks;
        public static DataModelUser ActivUserDataModel;

        public static void UserLogout()
        {
            UserID = -1;
            UserName = null;
            UserActivNotebook = null;
            UserSalt = null;  
            UserActivNotebookID = -1;
            User_DecryptedNotebooks = null;
            ActivUserDataModel = null;
            UserPassword.Clear();
            GC.Collect();
        }
    }
}
