using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using WPF_Encrypted_Notebook.Classes;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageServerConfigure : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        DatabaseManager db;


        public PageServerConfigure()
        {
            InitializeComponent();
            this.db = DatabaseIntance.databaseManager;
        }
            

        private void bttn_configure_Click(object sender, RoutedEventArgs e)
        {
            DatabaseIntance.databaseManager.Database.EnsureCreated();

            if (DatabaseIntance.databaseManager.CheckIfServerIsConfigured())
                mw.pageMirror.Content = new PageUserLogin();
            else
                mw.pageMirror.Content = new PageDatabase404();
        }
    }
}
