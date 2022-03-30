using System.Net;
using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.UIM;

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
            if (tb_Password.Password == new NetworkCredential("", UserInfoManager.UserPassword).Password)
            {
                User.DeleteUser();
                UserInfoManager.UserLogout();
                mw.pageMirror.Content = new PageUserLogin();
            }
            else
            {
                msgBox_error.Text = ("the entered password is not correct!");
                msgBox_error.Visibility = Visibility.Visible;
            }
        }
    }
}
