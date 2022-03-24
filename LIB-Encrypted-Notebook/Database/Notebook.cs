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
        static DatabaseManager db = DatabaseIntance.databaseManager;

        public static void SaveNotebook(string newNotes)
        {
            DataModelNotebook editNotebook = UserInfoManager.User_Notebooks[UserInfoManager.UserActivNotebookID];

            editNotebook.Notebook_Value = EncryptionManager.EncryptAES256Salt(newNotes, new NetworkCredential("", UserInfoManager.UserPassword).Password, UserInfoManager.UserSalt);

            db.SaveChanges();
        }

        public static List<DataModelNotebook> GetAllNotebooks()
        {
            List<DataModelNotebook> allNotebooks = new List<DataModelNotebook>();

            allNotebooks = db.Notebook.Where(n => n.Notebook_Owner_ID == UserInfoManager.UserID).ToList();

            UserInfoManager.User_Notebooks = allNotebooks;

            return allNotebooks;
        }

        public static string ReadNotesFromNotebook()
        {
            string plainNotes = "";

            string encryptedNotes = db.Notebook.SingleOrDefault(n => n.Notebook_ID == UserInfoManager.UserActivNotebookID).Notebook_Value;

            plainNotes = EncryptionManager.DecryptAES256Salt(encryptedNotes, new NetworkCredential("", UserInfoManager.UserPassword).Password, UserInfoManager.UserSalt);
            
            return plainNotes;
        }

        public static void CreateNotebook(string notebookName)
        {
            DataModelNotebook newNotebook = new DataModelNotebook()
            {
                Notebook_Name = notebookName,
                Notebook_Owner_ID = UserInfoManager.UserID,
                Notebook_Salt = new DataModelSalt()
                {
                    Salt_Value = SplitSystem.SaltSplitSystem.SplitByteArrayIntoString(EncryptionManager.GetNewSalt())
                }
            };

            db.Notebook.Add(newNotebook);
            db.SaveChanges();   
        }

        public static void DeleteNotebook()
        {
            db.Notebook.Remove(UserInfoManager.User_Notebooks[UserInfoManager.UserActivNotebookID]);
            db.SaveChanges();
        }
    }
}
