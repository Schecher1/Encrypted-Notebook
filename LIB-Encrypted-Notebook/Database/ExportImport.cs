using LIB_Encrypted_Notebook.DataModels;
using LIB_Encrypted_Notebook.Encryption;
using LIB_Encrypted_Notebook.SplitSystem;
using LIB_Encrypted_Notebook.UIM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LIB_Encrypted_Notebook.Database
{
    public class ExportImport
    {
        public static List<string> ExportAllNotebooks(string exportPassword)
        {
            List<string> exportData = new List<string>();
            byte[] salt = EncryptionManager.GetNewSalt();
            exportData.Add(SaltSplitSystem.SplitByteArrayIntoString(salt));
            string new_EncryptedNotebookValue, new_EncryptedNotebookName;

            List<DataModelNotebook> allNotebooks = Notebook.GetAllEncryptedNotebooks();

            foreach (DataModelNotebook notebook in allNotebooks)
            {
                new_EncryptedNotebookName =
                    EncryptionManager.EncryptAES256Salt(
                        EncryptionManager.DecryptAES256Salt(
                            notebook.Notebook_Name,
                            new NetworkCredential("", UserInfoManager.UserPassword).Password,
                            UserInfoManager.UserSalt),
                        exportPassword,
                        salt);

                new_EncryptedNotebookValue =
                        EncryptionManager.EncryptAES256Salt(
                            EncryptionManager.DecryptAES256Salt(
                                notebook.Notebook_Value,
                                new NetworkCredential("", UserInfoManager.UserPassword).Password,
                                UserInfoManager.UserSalt),
                        exportPassword,
                        salt);


                exportData.Add($"{new_EncryptedNotebookName}:{new_EncryptedNotebookValue}");
            }

            return exportData;
        }

        public static List<string> ExportCustomNotebooks(string exportPassword, List<string> listOfNotebooks)
        {
            List<string> exportData = new List<string>();
            byte[] salt = EncryptionManager.GetNewSalt();
            exportData.Add(SaltSplitSystem.SplitByteArrayIntoString(salt));
            string new_EncryptedNotebookValue, new_EncryptedNotebookName;

            List<DataModelNotebook> allNotebooks = Notebook.GetAllEncryptedNotebooks();
            List<DataModelNotebook> customNotebooks = new List<DataModelNotebook>();

            //get each notebook, from all
            foreach (string notebookName in listOfNotebooks)
            {
                string encryptedName = EncryptionManager.EncryptAES256Salt(
                                                                    notebookName,
                                                                    new NetworkCredential("", UserInfoManager.UserPassword).Password,
                                                                    UserInfoManager.UserSalt);

                customNotebooks.Add(allNotebooks.First(n => n.Notebook_Name == encryptedName));
            }

            foreach (DataModelNotebook notebook in customNotebooks)
            {
                new_EncryptedNotebookName =
                    EncryptionManager.EncryptAES256Salt(
                        EncryptionManager.DecryptAES256Salt(
                            notebook.Notebook_Name,
                            new NetworkCredential("", UserInfoManager.UserPassword).Password,
                            UserInfoManager.UserSalt),
                        exportPassword,
                        salt);

                new_EncryptedNotebookValue =
                        EncryptionManager.EncryptAES256Salt(
                            EncryptionManager.DecryptAES256Salt(
                                notebook.Notebook_Value,
                                new NetworkCredential("", UserInfoManager.UserPassword).Password,
                                UserInfoManager.UserSalt),
                        exportPassword,
                        salt);


                exportData.Add($"{new_EncryptedNotebookName}:{new_EncryptedNotebookValue}");
            }

            return exportData;
        }

        public static object ImportAllNotebooks(string importPassword, List<string> importData)
        {
            try
            {
                byte[] salt = SaltSplitSystem.SplitStringIntoByteArray(importData[0]);
                importData.RemoveAt(0);
                string new_EncryptedNotebookValue = null, new_EncryptedNotebookName = null;

                foreach (var notebook in importData)
                {
                    new_EncryptedNotebookName = null;
                    new_EncryptedNotebookValue = null;

                    string[] _tmp = notebook.Split(':');

                    new_EncryptedNotebookName =
                        EncryptionManager.EncryptAES256Salt(
                            EncryptionManager.DecryptAES256Salt(_tmp[0], importPassword, salt),
                            new NetworkCredential("", UserInfoManager.UserPassword).Password,
                            UserInfoManager.UserSalt);

                    if (_tmp[1] == "NULL")
                        new_EncryptedNotebookValue = null;
                    else
                    {
                        new_EncryptedNotebookValue =
                            EncryptionManager.EncryptAES256Salt(
                                EncryptionManager.DecryptAES256Salt(_tmp[1], importPassword, salt),
                                new NetworkCredential("", UserInfoManager.UserPassword).Password,
                                UserInfoManager.UserSalt);
                    }


                    DataModelNotebook newNotebook = new DataModelNotebook()
                    {
                        Notebook_Name = new_EncryptedNotebookName,
                        Notebook_Value = new_EncryptedNotebookValue,
                        Notebook_Owner_ID = UserInfoManager.UserID
                    };

                    DatabaseIntance.databaseManager.Notebook.Add(newNotebook);
            }
                // TODO:
                // With the wrong password and then the correct one Comes a NULL Error at Notebook_Name although there is no NULL ?!?!? 
                DatabaseIntance.databaseManager.SaveChanges();
                return "";
            }
            catch { return null; }
        }
    }
}
