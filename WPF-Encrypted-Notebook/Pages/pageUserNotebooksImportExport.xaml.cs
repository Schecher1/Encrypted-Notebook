using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.DataModels;
using WPF_Encrypted_Notebook.Classes;


namespace WPF_Encrypted_Notebook.Pages
{

    public partial class PageUserNotebooksImportExport : Page
    {
        public static Notebook notebook = new Notebook();
        MainWindow mw = (MainWindow)System.Windows.Application.Current.MainWindow;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        OpenFileDialog ofd = new OpenFileDialog();

        public PageUserNotebooksImportExport()
        {
            InitializeComponent();
            LoadNotebooks();
        }

        private void LoadNotebooks()
        {
            lb_notebooks.Items.Clear();
            List<DataModelNotebook> notebooks = Notebook.GetAllDecryptedNotebooks();
            foreach (var notebook in notebooks)
                lb_notebooks.Items.Add(notebook.Notebook_Name);
        }

        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserHome();

        private void bttn_export_Click(object sender, RoutedEventArgs e)
        {
            if (tb_password.Password != "" && tb_password.Password != null)
            {
                if (tb_pathExport.Text != "" && tb_pathExport.Text != null)
                {
                    if (lb_notebooks.Items.Count != 0)
                    {
                        if (cb_all.IsChecked == true)
                        {
                            ImportExportManager.ExportAll(tb_password.Password, tb_pathExport.Text);
                            finish();
                        }
                        else if (cb_custom.IsChecked == true)
                        {
                            if (lb_notebooks.SelectedIndex != -1)
                            {
                                List<string> listOfNotebooks = new List<string>();
                                foreach (var notebook in lb_notebooks.SelectedItems)
                                    listOfNotebooks.Add(notebook.ToString());
                                ImportExportManager.ExportCustom(tb_password.Password, tb_pathExport.Text, listOfNotebooks);
                                finish();
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Minimum one notebook must be selected!");
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Minimum one method must be selected!");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("There must be at least one notebook!");
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("The Path can not be empty or invalid!");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("The password can not be empty or invalid!");
            }
        }

        private void bttn_import_Click(object sender, RoutedEventArgs e)
        {
            if (tb_password.Password != "" && tb_password.Password != null)
                if (tb_pathImport.Text != "" && tb_pathImport.Text != null)
                {
                    ImportExportManager.ImportAll(tb_password.Password, tb_pathImport.Text);
                    finish();
                }
                else
                    System.Windows.MessageBox.Show("The Path can not be empty or invalid!");
            else
                System.Windows.MessageBox.Show("The password can not be empty or invalid!");
        }

        private void bttn_selectPathExport_Click(object sender, RoutedEventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
                tb_pathExport.Text = fbd.SelectedPath;
        }

        private void bttn_selectPathImport_Click(object sender, RoutedEventArgs e)
        {
            ofd.Title = "Select your export file!";
            ofd.Filter = "TxT| *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
                tb_pathImport.Text = ofd.FileName;
        }

        private void finish()
        {
            tb_password.Password = "";
            tb_pathExport.Text = "";
            tb_pathImport.Text = "";
            lb_notebooks.SelectedIndex = -1;
            cb_all.IsChecked = false;
            cb_custom.IsChecked = false;
            LoadNotebooks();
        }
    }
}
