using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageServerLogin : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;

        public PageServerLogin()
        {
            InitializeComponent();

            this.db = DatabaseIntance.databaseManager;

            msgBox_error.Visibility = Visibility.Hidden;

            if (File.Exists("c2s_owl.gnm"))
                mw.pageMirror.Content = new PageServerOneWayLogin();

            if (File.Exists("c2s.gnm"))
            {
                string[] data = File.ReadAllLines("c2s.gnm");
                tb_serverIP.Text = data[0];
                tb_serverDatabase.Text = data[1];
                tb_serverUsername.Text = data[2];
            }
        }

        private async void bttn_login_Click(object sender, RoutedEventArgs e)
        {
            if (tb_serverIP.Text == "")
            {
                msgBox_error.Text = ("The server-IP cannot be empty!");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }
            else if (tb_serverDatabase.Text == "")
            {
                msgBox_error.Text = ("The database-Name cannot be empty!");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }
            else if (tb_serverUsername.Text == "")
            {
                msgBox_error.Text = ("The username cannot be empty!");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }

            try
            {
                 db = new DatabaseManager(tb_serverIP.Text, tb_serverDatabase.Text, tb_serverUsername.Text, tb_serverPassword.Password);
                 DatabaseIntance.databaseManager = db;
            }
            catch (Exception ex)
            {
                msgBox_error.Text = (ex.Message);
                msgBox_error.Visibility = Visibility.Visible;
            }

            
            if (DatabaseIntance.databaseManager.IsDbConnected())
            {
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

        private void bttn_save_Click(object sender, RoutedEventArgs e)
        {
            string[] data =
            {
                tb_serverIP.Text,
                tb_serverDatabase.Text,
                tb_serverUsername.Text
            };
            File.WriteAllLines("c2s.gnm", data);
        }

        private void bttn_owl_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageServerOneWayLoginKeyCreate();
    }
}
