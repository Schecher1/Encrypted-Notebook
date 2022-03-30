using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using LIB_Encrypted_Notebook.UIM;
using LIB_Encrypted_Notebook.Database;

namespace WPF_Encrypted_Notebook.Classes
{
    public class ImportExportManager
    {
        public static void ExportAll(string exportPassword, string exportPath)
        {
            try
            {
            List<string> exportData = new List<string>();
            exportData = ExportImport.ExportAllNotebooks(exportPassword);
            File.WriteAllLines($@"{exportPath}\ExportAllNotebooks-From-{UserInfoManager.UserName}-At-{DateTime.Now.ToString("d")}.txt", exportData);
            MessageBox.Show("Attention: if you change the data in the file (it is enough only one letter!) then the file is corrupted (for EVER!)", "The export was successful", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        public static void ExportCustom(string exportPassword, string exportPath, List<string> listOfNotebooks)
        {
            try
            {
                List<string> exportData = new List<string>();
            exportData = ExportImport.ExportCustomNotebooks(exportPassword, listOfNotebooks);
            File.WriteAllLines($@"{exportPath}\ExportCustomNotebooks-From-{UserInfoManager.UserName}-At-{DateTime.Now.ToString("d")}.txt", exportData);
            MessageBox.Show("Attention: if you change the data in the file (it is enough only one letter!) then the file is corrupted (for EVER!)", "The export was successful", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
            }
        public static void ImportAll(string importPassword, string importPath)
        {
            try
            {
            List<string> importData = new List<string>();
            string[] _tmp = File.ReadAllLines(importPath);
            for (int i = 1; i <= _tmp.Length; i++)
                importData.Add(_tmp[i - 1]);
            if (ExportImport.ImportAllNotebooks(importPassword, importData) == null)
                MessageBox.Show("The import was NOT successful, maybe the password is wrong. Restart your program if the error stays", "The import was NOT successful", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("The import was successful, all notebooks should be available.", "The import was successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
