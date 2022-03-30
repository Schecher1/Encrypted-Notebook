using System.Security;
using LIB_Encrypted_Notebook.DataModels;

namespace LIB_Encrypted_Notebook.UIM
{
    public class UserInfoManager
    {
        //User id from the database (PK)
        public static int UserID;
        //User name from the database
        public static string UserName;
        //User password from the database but as SS 
        public static SecureString UserPassword;
        //Activ User Notebook, as String from the listbox
        public static string UserActivNotebook;
        //User Salt as byte Array
        public static byte[] UserSalt;
        //Activ Notebook ID from the Database (PK)
        public static int UserActivNotebookID;
        //users notebooks, but decrypted
        public static List<DataModelNotebook> User_DecryptedNotebooks;
        //users notebooks, but encrypted and linked to the database
        public static List<DataModelNotebook> User_EncryptedNotebooks;
        //the current user linked to the database
        public static DataModelUser ActivUserDataModel;

        public static void UserLogout()
        {
            //override the data (maybe not so safe   (dataleak))
            UserID = -1;
            UserName = null;
            UserActivNotebook = null;
            UserSalt = null;  
            UserActivNotebookID = -1;
            User_DecryptedNotebooks = null;
            ActivUserDataModel = null;
            //securely deletes the password
            UserPassword.Clear();
            //forces the GC to clear the dumb
            GC.Collect();
        }
    }
}
