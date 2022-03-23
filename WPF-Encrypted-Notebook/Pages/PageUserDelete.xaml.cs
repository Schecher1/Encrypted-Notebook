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
    public partial class PageUserDelete : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        public PageUserDelete()
        {
            InitializeComponent();
            msgBox_error.Visibility = Visibility.Hidden;
        }

        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserHome();

        private void bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            //if (tb_Password.Password == new NetworkCredential("", UserInfoManager.userPassword).Password)
            //{
            //    DBMgr.deleteUser();
            //    UserInfoManager.userLogout();
            //    mw.pageMirror.Content = new pageUserLogin();
            //}
            //else
            //{
            //    msgBox_error.Text = ("the entered password is not correct!");
            //    msgBox_error.Visibility = Visibility.Visible;
            //}
        }
    }
}
