using System.IO;
using System.Windows;
using WPF_Encrypted_Notebook.Pages;

namespace WPF_Encrypted_Notebook
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("c2s_owl.gnm"))
                pageMirror.Content = new PageServerOneWayLogin();
            else
                pageMirror.Content = new PageServerLogin();
        }
    }
}
