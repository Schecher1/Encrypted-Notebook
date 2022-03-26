using LIB_Encrypted_Notebook.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB_Encrypted_Notebook.UIM;
using LIB_Encrypted_Notebook.Encryption;
using System.Net;

namespace LIB_Encrypted_Notebook.Database
{
    public class Notebook
    {
        public static void SaveNotebook(string newNotes)
        {
            DataModelNotebook editNotebook = UserInfoManager.User_Notebooks[UserInfoManager.UserActivNotebookID];

            editNotebook.Notebook_Value = EncryptionManager.EncryptAES256Salt(newNotes, new NetworkCredential("", UserInfoManager.UserPassword).Password, UserInfoManager.UserSalt);

            DatabaseIntance.databaseManager.SaveChanges();
        }

        public static List<DataModelNotebook> GetAllNotebooks()
        {
            List<DataModelNotebook> allNotebooks = new List<DataModelNotebook>();

            allNotebooks = DatabaseIntance.databaseManager.Notebook.Where(n => n.Notebook_Owner_ID == UserInfoManager.UserID).ToList();

            UserInfoManager.User_Notebooks = allNotebooks;

            return allNotebooks;
        }

        public static string ReadNotesFromNotebook()
        {
            string plainNotes = "";

            string encryptedNotes = DatabaseIntance.databaseManager.Notebook.SingleOrDefault(n => n.Notebook_ID == UserInfoManager.UserActivNotebookID).Notebook_Value;

            plainNotes = EncryptionManager.DecryptAES256Salt(encryptedNotes, new NetworkCredential("", UserInfoManager.UserPassword).Password, UserInfoManager.UserSalt);
            
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

        public static void DeleteNotebook()
        {
            DatabaseIntance.databaseManager.Notebook.Remove(UserInfoManager.User_Notebooks[UserInfoManager.UserActivNotebookID]);
            DatabaseIntance.databaseManager.SaveChanges();
        }
    }
}
