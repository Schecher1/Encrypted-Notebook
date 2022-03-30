using System.Windows;
using System.Windows.Controls;
using LIB_Encrypted_Notebook.Database;
using LIB_Encrypted_Notebook.DataModels;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageServerConfigure : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        public PageServerConfigure() => InitializeComponent();


        private void bttn_configure_Click(object sender, RoutedEventArgs e)
        {
            DatabaseIntance.databaseManager.Database.EnsureCreated();
            DatabaseIntance.databaseManager.Setting.Add
                (new DataModelSetting
                {
                    Setting_Name = "DataBaseVersion",
                    Setting_Value = "1.0.0.0"
                });
            DatabaseIntance.databaseManager.SaveChanges();

            if (DatabaseIntance.databaseManager.CheckIfDatabaseIsConfigured())
                mw.pageMirror.Content = new PageUserLogin();
            else
                mw.pageMirror.Content = new PageDatabase404();
        }
    }
}
