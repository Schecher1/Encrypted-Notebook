using System.Windows;
using System.Windows.Controls;

namespace WPF_Encrypted_Notebook.Pages
{
    public partial class PageDatabase404 : Page
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        public PageDatabase404() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e) => mw.pageMirror.Content = new PageServerLogin();
    }
}
