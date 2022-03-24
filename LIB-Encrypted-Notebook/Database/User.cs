using LIB_Encrypted_Notebook.DataModels;
using LIB_Encrypted_Notebook.UIM;

namespace LIB_Encrypted_Notebook.Database
{
    public class User
    {
        static DatabaseManager db = DatabaseIntance.databaseManager;

        public static void CreateUser(string username, string password)
        {
            DataModelUser newUser = new DataModelUser()
            {
                User_Name = Encryption.EncryptionManager.GetHash_SHA512(username.ToLower()),
                User_Password = Encryption.EncryptionManager.GetHash_SHA512(password.ToLower())
            };

            db.User.Add(newUser);
            db.SaveChanges();
        }

        public static void DeleteUser()
        {
            db.Remove(UserInfoManager.ActivUserDataModel);
            db.SaveChanges();
        }

        public static bool CheckIfUserExist(string username)
        {
            bool res;

            if (db.User.FirstOrDefault(u => u.User_Name == Encryption.EncryptionManager.GetHash_SHA512(username.ToLower())) == null)
                res = false;
            else 
                res = true;

            return res;
        }

        public static bool LoginUser(string username, string password)
        {
            bool res;

            DataModelUser? user = db.User.FirstOrDefault(u =>
                                                                 u.User_Name == Encryption.EncryptionManager.GetHash_SHA512(username.ToLower()) &&
                                                                 u.User_Password == Encryption.EncryptionManager.GetHash_SHA512(password.ToLower()));

            if (user != null)
            {
                res = true;
                UserInfoManager.ActivUserDataModel = user;
            }
            else
                res = false;

            return res;
        }
    }
}
