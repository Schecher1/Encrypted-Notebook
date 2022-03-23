using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class PageServerOneWayLogin : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        private void bttn_BackTo_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageServerLogin();

        public PageServerOneWayLogin()
        {
            InitializeComponent();
            msgBox_error.Visibility = Visibility.Hidden;
        }

        private void bttn_login_Click(object sender, RoutedEventArgs e)
        {
            /*
            try
            {
               string[] _data = File.ReadAllLines("c2s_owl.gnm");
               byte[] salt = SplitManager.SplitStringIntoByteArray(_data[0]);
               string[] loginData = EMgr.DecryptAES256Salt(_data[1], tb_filePassword.Password, salt).Split(':');

                DBMgr.connectionString(loginData[0], loginData[1], loginData[2], loginData[3]);

                
                if (DBMgr.dbConnect() == "successfully connected to the database!")
                {
                    if (DBMgr.checkIfServerIsConfigured() == 1)
                        mw.pageMirror.Content = new pageUserLogin();
                    else
                        mw.pageMirror.Content = new pageServerConfigure();
                }
                else
                {
                    msgBox_error.Text = ("No connection could be established");
                    msgBox_error.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                msgBox_error.Text = ("No connection could be established");
                msgBox_error.Visibility = Visibility.Visible;
            }
                */
        }

        private void bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("c2s_owl.gnm"))
            {
                File.Delete("c2s_owl.gnm");
                mw.pageMirror.Content = new PageServerLogin();
            }
        }

        
    }
}
