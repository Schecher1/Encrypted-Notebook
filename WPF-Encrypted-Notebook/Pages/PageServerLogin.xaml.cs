using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LIB_Encrypted_Notebook;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.DataModels;
using WPF_Encrypted_Notebook.Classes;

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

        private void bttn_login_Click(object sender, RoutedEventArgs e)
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

            //DBMgr.connectionString(tb_serverIP.Text, tb_serverDatabase.Text, tb_serverUsername.Text, tb_serverPassword.Password);

            //if (DBMgr.dbConnect() == "successfully connected to the database!")
            //{
            //    if (DBMgr.checkIfServerIsConfigured() == 1)
            //        mw.pageMirror.Content = new PageUserLogin();
            //    else
            //        mw.pageMirror.Content = new PageServerConfigure();
            //}
            //else
            //{
            //    msgBox_error.Text = ("No connection could be established");
            //    msgBox_error.Visibility = Visibility.Visible;
            //}
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
