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
            if (db.CheckIfServerIsConfigured() == 1)
                mw.pageMirror.Content = new PageUserLogin();
            else
                mw.pageMirror.Content = new PageDatabase404();
        }
    }
}
