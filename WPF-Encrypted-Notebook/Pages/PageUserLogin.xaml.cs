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
    public partial class PageUserLogin : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        private void bttn_createUser_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserCreate();

        public PageUserLogin()
        {
            InitializeComponent();
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
                //if (DBMgr.loginUser(tb_username.Text, tb_password.Password))
                //    mw.pageMirror.Content = new PageUserHome();
                //else
                //{
                //    msgBox_error.Text = ("The login data do not match!");
                //    msgBox_error.Visibility = Visibility.Visible;
                //}
            }
        }

        private void bttn_BackTo_Click(object sender, RoutedEventArgs e)
        {
            //DBMgr.dbDisconnect();
            if (File.Exists("c2s_owl.gnm"))
                mw.pageMirror.Content = new PageServerOneWayLogin();
            else
                mw.pageMirror.Content = new PageServerLogin();
        }
    }
}
