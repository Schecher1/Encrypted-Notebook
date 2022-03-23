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
using LIB_Encrypted_Notebook;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.DataModels;
using WPF_Encrypted_Notebook.Classes;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageUserHome : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;


        public PageUserHome()
        {
            this.db = DatabaseIntance.databaseManager;

            //if (UserInfoManager.userID == -1)
            //    return;
            //InitializeComponent();
            //bttn_logout.Content = ($"Logout ({UserInfoManager.userName})");
        }

        private void bttn_notebooks_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserNotebook();
        private void bttn_importExport_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new pageUserNotebooksImportExport();
        private void bttn_delAccount_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserDelete();
        private void bttn_logout_Click(object sender, RoutedEventArgs e)
        {
            bttn_delAccount.Visibility = Visibility.Hidden;
            bttn_importExport.Visibility = Visibility.Hidden;
            bttn_logout.Visibility = Visibility.Hidden;
            bttn_notebooks.Visibility = Visibility.Hidden;
            //UserInfoManager.userLogout();
            mw.pageMirror.Content = new PageUserLogin();
        }
    }
}
