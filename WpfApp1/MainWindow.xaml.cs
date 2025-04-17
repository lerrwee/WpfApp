using System.Windows;

namespace WpfApp1
{   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ListPage());
        }
    }
}
