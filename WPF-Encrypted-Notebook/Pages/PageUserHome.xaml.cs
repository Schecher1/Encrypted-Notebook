using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using WPF_Encrypted_Notebook.Classes;
using LIB_Encrypted_Notebook.UIM;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageUserHome : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;


        public PageUserHome()
        {
            this.db = DatabaseIntance.databaseManager;

            if (UserInfoManager.UserID == -1)
                return;
            InitializeComponent();
            bttn_logout.Content = ($"Logout ({UserInfoManager.UserName})");
        }

        private void bttn_notebooks_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserNotebook();
        private void bttn_importExport_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserNotebooksImportExport();
        private void bttn_delAccount_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageUserDelete();
        private void bttn_logout_Click(object sender, RoutedEventArgs e)
        {
            bttn_delAccount.Visibility = Visibility.Hidden;
            bttn_importExport.Visibility = Visibility.Hidden;
            bttn_logout.Visibility = Visibility.Hidden;
            bttn_notebooks.Visibility = Visibility.Hidden;
            UserInfoManager.UserLogout();
            mw.pageMirror.Content = new PageUserLogin();
        }
    }
}
