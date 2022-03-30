using System.IO;
using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.UIM;
using WPF_Encrypted_Notebook.Classes;
using LIB_Encrypted_Notebook.Encryption;
using LIB_Encrypted_Notebook.SplitSystem;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageUserLogin : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;

        private void bttn_createUser_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserCreate();

        public PageUserLogin()
        {
            InitializeComponent();
            this.db = DatabaseIntance.databaseManager;
            msgBox_error.Visibility = Visibility.Hidden;
            mw.pageMirror.NavigationService.RemoveBackEntry();
        }

        private void bttn_login_Click(object sender, RoutedEventArgs e)
        {
            if (tb_password.Password == "" || tb_username.Text == "")
            {
                msgBox_error.Text = ("The login data can not be empty!");
                msgBox_error.Visibility = Visibility.Visible;
            }
            else
            {
                if (User.LoginUser(tb_username.Text, tb_password.Password))
                {
                    UserInfoManager.UserID = UserInfoManager.ActivUserDataModel.User_ID;
                    UserInfoManager.UserName = tb_username.Text.ToLower();
                    UserInfoManager.UserPassword = tb_password.SecurePassword;
                    UserInfoManager.UserSalt = SaltSplitSystem.SplitStringIntoByteArray(UserInfoManager.ActivUserDataModel.User_Salt.Salt_Value);
                    Notebook.GetAllDecryptedNotebooks();
                    Notebook.GetAllEncryptedNotebooks();
                    mw.pageMirror.Content = new PageUserHome();
                }
                else
                {
                    msgBox_error.Text = ("The login data do not match!");
                    msgBox_error.Visibility = Visibility.Visible;
                }
            }
        }

        private void bttn_BackTo_Click(object sender, RoutedEventArgs e)
        {
            DatabaseIntance.databaseManager.DbDisconnectConnection();

            if (File.Exists("c2s_owl.gnm"))
                mw.pageMirror.Content = new PageServerOneWayLogin();
            else
                mw.pageMirror.Content = new PageServerLogin();
        }
    }
}
