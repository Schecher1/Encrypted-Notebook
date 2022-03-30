using System.IO;
using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.Encryption;
using LIB_Encrypted_Notebook.SplitSystem;
using System;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageServerOneWayLogin : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;

        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageServerLogin();

        public PageServerOneWayLogin()
        {
            InitializeComponent();

            this.db = DatabaseIntance.databaseManager;
            
            msgBox_error.Visibility = Visibility.Hidden;
        }

        private void bttn_login_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string[] _data = File.ReadAllLines("c2s_owl.gnm");
                byte[] salt = SaltSplitSystem.SplitStringIntoByteArray(_data[0]);
                string[] loginData = EncryptionManager.DecryptAES256Salt(_data[1], tb_filePassword.Password, salt).Split(':');

                try
                {
                    db = new DatabaseManager(loginData[0], loginData[1], loginData[2], loginData[3]);
                    DatabaseIntance.databaseManager = db;
                }
                catch (Exception ex)
                {
                    msgBox_error.Text = (ex.Message);
                    msgBox_error.Visibility = Visibility.Visible;
                }

                if (DatabaseIntance.databaseManager.IsDbConnected())
                {
                    DatabaseIntance.databaseManager = db;

                    if (DatabaseIntance.databaseManager.CheckIfDatabaseIsConfigured())
                        mw.pageMirror.Content = new PageUserLogin();
                    else
                        mw.pageMirror.Content = new PageServerConfigure();
                }
                else
                {
                    msgBox_error.Text = ("No connection could be established");
                    msgBox_error.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                msgBox_error.Text = ("No connection could be established");
                msgBox_error.Visibility = Visibility.Visible;
            }

        }

        private void bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("c2s_owl.gnm"))
            {
                File.Delete("c2s_owl.gnm");
                mw.pageMirror.Content = new PageServerLogin();
            }
        }

        
    }
}
