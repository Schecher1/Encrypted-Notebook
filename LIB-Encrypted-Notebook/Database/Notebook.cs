using LIB_Encrypted_Notebook.DataModels;
using LIB_Encrypted_Notebook.UIM;
using LIB_Encrypted_Notebook.Encryption;
using System.Net;

namespace LIB_Encrypted_Notebook.Database
{
    public class Notebook
    {
        public static void SaveNotebook(string newNotes, int lb_ID)
        {
            DataModelNotebook editNotebook = UserInfoManager.User_EncryptedNotebooks[lb_ID];

            editNotebook.Notebook_Value = EncryptionManager.EncryptAES256Salt(newNotes, new NetworkCredential("", UserInfoManager.UserPassword).Password, UserInfoManager.UserSalt);

            DatabaseIntance.databaseManager.SaveChanges();
        }

        public static List<DataModelNotebook> GetAllDecryptedNotebooks()
        {
            //is must, otherwise I destroy me the linked objects from the db
            List<DataModelNotebook> allNotebooksFromDB = new List<DataModelNotebook>();
            List<DataModelNotebook> allNotebooksLocal = new List<DataModelNotebook>();


            allNotebooksFromDB = DatabaseIntance.databaseManager.Notebook.Where(n => n.Notebook_Owner_ID == UserInfoManager.UserID).ToList();

            //(i got this mf bug finally)   list is copied and decrypted at the same time
            for (int index = 0; index < allNotebooksFromDB.Count; index++)
            {
                allNotebooksLocal.Add(new DataModelNotebook()
                {
                    Notebook_ID = allNotebooksFromDB[index].Notebook_ID,

                    Notebook_Name = EncryptionManager.DecryptAES256Salt
                                                                    (allNotebooksFromDB[index].Notebook_Name,
                                                                    new NetworkCredential("", UserInfoManager.UserPassword).Password,
                                                                    UserInfoManager.UserSalt),

                    Notebook_Value = EncryptionManager.DecryptAES256Salt
                                                                    (allNotebooksFromDB[index].Notebook_Value,
                                                                    new NetworkCredential("", UserInfoManager.UserPassword).Password,
                                                                    UserInfoManager.UserSalt),
                    Notebook_Owner_ID = UserInfoManager.UserID

                });                    
            }

            UserInfoManager.User_DecryptedNotebooks = allNotebooksFromDB;

            return allNotebooksLocal;
        }

        public static List<DataModelNotebook> GetAllEncryptedNotebooks()
        {
            List<DataModelNotebook> allNotebooksFromDB = new List<DataModelNotebook>();

            allNotebooksFromDB = DatabaseIntance.databaseManager.Notebook.Where(n => n.Notebook_Owner_ID == UserInfoManager.UserID).ToList();

            UserInfoManager.User_EncryptedNotebooks = allNotebooksFromDB;

            return allNotebooksFromDB;
        }

        public static string ReadNotesFromNotebook()
        {
            string plainNotes = "";

            string? encryptedNotes = DatabaseIntance.databaseManager.Notebook.SingleOrDefault(n => n.Notebook_ID == UserInfoManager.UserActivNotebookID).Notebook_Value;

            if (encryptedNotes != null)
                plainNotes = EncryptionManager.DecryptAES256Salt(encryptedNotes, new NetworkCredential("", UserInfoManager.UserPassword).Password, UserInfoManager.UserSalt);
            else
                plainNotes = "";

            return plainNotes;
        }

        public static void CreateNotebook(string notebookName)
        {
            DataModelNotebook newNotebook = new DataModelNotebook()
            {
                Notebook_Owner_ID = UserInfoManager.UserID,

                Notebook_Name = 
                            EncryptionManager.EncryptAES256Salt(
                                notebookName, 
                                new NetworkCredential("", UserInfoManager.UserPassword).Password,
                                UserInfoManager.UserSalt)
            };

            DatabaseIntance.databaseManager.Notebook.Add(newNotebook);
            DatabaseIntance.databaseManager.SaveChanges();
        }

        public static void DeleteNotebook(int index)
        {
            DatabaseIntance.databaseManager.Notebook.Remove(UserInfoManager.User_EncryptedNotebooks[index]);
            DatabaseIntance.databaseManager.SaveChanges();
        }
    }
}
