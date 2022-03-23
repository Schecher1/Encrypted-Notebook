using System.Security;

namespace LIB_Encrypted_Notebook.UIM
{
    public class UserInfoManager
    {
        public static string userName;
        public static SecureString userPassword;
        public static int userID;
        public static string userActivNotebook;
        public static byte[] userSalt;

        public static void UserLogout()
        {
            userName = null;
            userActivNotebook = null;
            userID = -1;
            userSalt = new byte[] { 0 };
            userPassword.Clear();
            GC.Collect();
        }
    }
}
