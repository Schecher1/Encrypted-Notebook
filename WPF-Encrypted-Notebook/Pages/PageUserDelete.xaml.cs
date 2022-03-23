using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public partial class PageUserDelete : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;


        public PageUserDelete()
        {
            InitializeComponent();
            this.db = DatabaseIntance.databaseManager;
            msgBox_error.Visibility = Visibility.Hidden;
        }

        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserHome();

        private void bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Password.Password == new NetworkCredential("", UserInfoManager.userPassword).Password)
            {
                db.DeleteUser();
                UserInfoManager.userLogout();
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
