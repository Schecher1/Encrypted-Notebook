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
            else if (tb_serverPassword.Password.Contains(":"))
            {
                msgBox_error.Text = ("The password cannot contain a   ':'   !");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }
            //byte[] salt = EMgr.GetNewSalt();
            //string encryptedLoginData = EMgr.EncryptAES256Salt(($"{tb_serverIP.Text}:{tb_serverDatabase.Text}:{tb_serverUsername.Text}:{tb_serverPassword.Password}"), tb_loginPassoword.Password, salt);
            //string[] _data = { SplitManager.SplitByteArrayIntoString(salt), encryptedLoginData };
            //File.WriteAllLines("c2s_owl.gnm", _data);
            mw.pageMirror.Content = new PageServerOneWayLogin();
        }
    }
}
