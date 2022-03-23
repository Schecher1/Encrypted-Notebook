using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.DataModels;
using LIB_Encrypted_Notebook.Encryption;
using WPF_Encrypted_Notebook.Classes;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageUserNotebook : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;

        private void bttn_notesSave_Click(object sender, RoutedEventArgs e)
        {
            db.SaveNotebook(tb_notes.Text);
        }
        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserHome();

        public PageUserNotebook()
        {
            InitializeComponent();
            this.db = DatabaseIntance.databaseManager;
            LoadNotebooks();
        }

        private void LoadNotebooks()
        {
            lb_notebooks.Items.Clear();
            List<DataModelNotebook> Notebooks = new List<DataModelNotebook>();
            Notebooks = db.GetAllNotebooks();
            foreach (var notebook in Notebooks)
                lb_notebooks.Items.Add(notebook);
        }

        private void lb_notebooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_notes.Text = "";
            gp_notes.Header = ("Notes from " + lb_notebooks.SelectedItem);
            if (lb_notebooks.SelectedIndex == -1)
                UserInfoManager.userActivNotebook = null;
            else
            {
                UserInfoManager.userActivNotebook = EncryptionManager.EncryptAES256Salt(lb_notebooks.SelectedItem.ToString(), new NetworkCredential("", UserInfoManager.userPassword).Password, UserInfoManager.userSalt);
                tb_notes.Text = db.ReadNotesFromNotebook();
            }
        }

        private void bttn_notebookCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tb_newNotebook.Text != "")
            {
                db.CreateNotebook(tb_newNotebook.Text);
                LoadNotebooks();
                tb_newNotebook.Text = "";
            }
        }

        private void bttn_notebookDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lb_notebooks.SelectedIndex != -1)
            {
                db.DeleteNotebook(lb_notebooks.SelectedItem.ToString());
                LoadNotebooks();
            }
            else
                MessageBox.Show("You must have selected an Notebook in the list before you can delete it!");
        }
    }
}
