using System;
using System.Collections.Generic;
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
    public partial class PageUserCreate : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserLogin();

        public PageUserCreate()
        {
            InitializeComponent();
            msgBox_error.Visibility = Visibility.Hidden;
        }

        private void bttn_create_Click(object sender, RoutedEventArgs e)
        {
            if (tb_username.Text == "")
            {
                msgBox_error.Text = ("The username cannot be empty");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }
            else if (tb_password.Password == "")
            {
                msgBox_error.Text = ("The password cannot be empty");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }
            else if (tb_password.Password != tb_passwordRepeat.Password)
            {
                msgBox_error.Text = ("The passwords are not identical");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }
            else if (tb_password.Password.Length <= 8)
            {
                msgBox_error.Text = ("Your password must be at least 8 characters long");
                msgBox_error.Visibility = Visibility.Visible;
                return;
            }

            //if (DBMgr.checkIfUserExist(tb_username.Text.ToLower()) == 0)
            //{
            //    DBMgr.createUser(tb_username.Text, tb_password.Password);
            //    mw.pageMirror.Content = new pageUserLogin();
            //}
            //else
            //{
            //    msgBox_error.Text = ("The username is already taken!");
            //    msgBox_error.Visibility = Visibility.Visible;
            //}
        }


    }
}
