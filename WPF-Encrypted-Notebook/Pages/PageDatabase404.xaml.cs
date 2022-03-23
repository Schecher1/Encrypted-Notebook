using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using WPF_Encrypted_Notebook.Classes;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageDatabase404 : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;

        public PageDatabase404()
        {
            InitializeComponent();
            this.db = DatabaseIntance.databaseManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageServerLogin();
    }
}
