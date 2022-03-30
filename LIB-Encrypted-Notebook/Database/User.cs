using LIB_Encrypted_Notebook.DataModels;
using LIB_Encrypted_Notebook.Encryption;
using LIB_Encrypted_Notebook.UIM;

namespace LIB_Encrypted_Notebook.Database
{
    public class User
    {
        public static void CreateUser(string username, string password)
        {
            DataModelUser newUser = new DataModelUser()
            {
                User_Name = Encryption.EncryptionManager.GetHash_SHA512(username.ToLower()),
                User_Password = Encryption.EncryptionManager.GetHash_SHA512(password.ToLower()),
                User_Salt = new DataModelSalt()
                {
                    Salt_Value = SplitSystem.SaltSplitSystem.SplitByteArrayIntoString(EncryptionManager.GetNewSalt())
                }
            };

            DatabaseIntance.databaseManager.User.Add(newUser);
            DatabaseIntance.databaseManager.SaveChanges();
        }

        public static void DeleteUser()
        {
            DatabaseIntance.databaseManager.Salt.Remove(UserInfoManager.ActivUserDataModel.User_Salt);
            DatabaseIntance.databaseManager.User.Remove(UserInfoManager.ActivUserDataModel);
            foreach (DataModelNotebook notebook in UserInfoManager.User_EncryptedNotebooks)
                DatabaseIntance.databaseManager.Notebook.Remove(notebook);
            DatabaseIntance.databaseManager.SaveChanges();
        }

        public static bool CheckIfUserExist(string username)
        {
            bool res;

            if (DatabaseIntance.databaseManager.User.FirstOrDefault(u => u.User_Name == Encryption.EncryptionManager.GetHash_SHA512(username.ToLower())) == null)
                res = true;
            else 
                res = false;

            return res;
        }

        public static bool LoginUser(string username, string password)
        {
            bool res;

            DataModelUser? user = DatabaseIntance.databaseManager.User.FirstOrDefault(u =>
                                                                 u.User_Name == Encryption.EncryptionManager.GetHash_SHA512(username.ToLower()) &&
                                                                 u.User_Password == Encryption.EncryptionManager.GetHash_SHA512(password.ToLower()));

            if (user != null)
            {
                //TODO: Make it better, this is crappy af     
                //reason why i did it this way: this about me, sometimes gives me the salt and sometimes a NULL
                user.User_Salt = DatabaseIntance.databaseManager.Salt.First(s => s.Salt_ID == user.User_ID);

                res = true;

                UserInfoManager.ActivUserDataModel = user;
            }
            else
                res = false;

            return res;
        }
    }
}
