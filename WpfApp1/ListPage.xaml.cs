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

namespace WpfApp1
{   
    public partial class ListPage : Page
    {
        MasterPolDBEntities entities = new MasterPolDBEntities();
        public ListPage()
        {
            InitializeComponent();
            foreach(var entity in entities.Partner)
                LV.Items.Add(entity);
        }

        private void LV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LV.SelectedItem is Partner selectPartner)
                NavigationService.Navigate(new EditPage(selectPartner.Id));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(0));
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (LV.SelectedItem is Partner selectPartner)
                NavigationService.Navigate(new HistoryPage(selectPartner));
            else
                MessageBox.Show("Выберете партнера!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
