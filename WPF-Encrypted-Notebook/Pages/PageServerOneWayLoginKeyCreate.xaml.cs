using System.IO;
using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Encryption;
using LIB_Encrypted_Notebook.SplitSystem;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageServerOneWayLoginKeyCreate : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        public PageServerOneWayLoginKeyCreate()
        {
            InitializeComponent();
            msgBox_error.Visibility = Visibility.Hidden;
        }

        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageServerLogin();

        private void bttn_create_Click(object sender, RoutedEventArgs e)
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
            else if (tb_serverPassword.Password.Contains(':'))
            {
                msgBox_error.Text = ("The password cannot contain a   ':'   !");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }
            byte[] salt = EncryptionManager.GetNewSalt();
            string encryptedLoginData = EncryptionManager.EncryptAES256Salt(($"{tb_serverIP.Text}:{tb_serverDatabase.Text}:{tb_serverUsername.Text}:{tb_serverPassword.Password}"), tb_loginPassoword.Password, salt);
            string[] _data = { SaltSplitSystem.SplitByteArrayIntoString(salt), encryptedLoginData };
            File.WriteAllLines("c2s_owl.gnm", _data);
            mw.pageMirror.Content = new PageServerOneWayLogin();
        }
    }
}
