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
    public partial class EditPage : Page
    {
        MasterPolDBEntities entities = new MasterPolDBEntities();
        Partner partner = new Partner();

        public EditPage(int PartnerID)
        {
            InitializeComponent();
            foreach (var entity in entities.Partner_type) 
                Partner_type_ComboBox.Items.Add(entity);

            if (PartnerID == 0)
                partner = new Partner();
            else
                partner = entities.Partner.Find(PartnerID);

            if (PartnerID != 0)
            {
                NameTextBox.Text = partner.Partner_name;
                Partner_type_ComboBox.SelectedItem = partner.Partner_type;
                EmailTextBox.Text = partner.Email;
                TelephoneTextBox.Text = partner.Telephone;
                AdressTextBox.Text = partner.Adress;
                Othestvo_directorTextBox.Text = partner.Othestvo_director;
                Name_directorTextBox.Text = partner.Name_director;
                Familia_directorTextBox.Text = partner.Familia_director;
                InnTextBox.Text = partner.Inn;
                ReitingTextBox.Text = partner.Reiting.ToString();
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || EmailTextBox.Text == "" || TelephoneTextBox.Text == "" || AdressTextBox.Text == "" || Othestvo_directorTextBox.Text == "" ||
                Name_directorTextBox.Text == "" || Familia_directorTextBox.Text == "" || InnTextBox.Text == "" || ReitingTextBox.Text == "" || Partner_type_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(!int.TryParse(ReitingTextBox.Text, out int res))
            {
                MessageBox.Show("Рейтинг должен быть положительным целым числом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                partner.Partner_name = NameTextBox.Text;
                partner.Partner_type = Partner_type_ComboBox.SelectedItem as Partner_type;
                partner.Email = EmailTextBox.Text;
                partner.Telephone = TelephoneTextBox.Text;
                partner.Adress = AdressTextBox.Text;
                partner.Othestvo_director = Othestvo_directorTextBox.Text;
                partner.Name_director = Name_directorTextBox.Text;
                partner.Familia_director = Familia_directorTextBox.Text;
                partner.Inn = InnTextBox.Text;
                partner.Reiting = int.Parse(ReitingTextBox.Text);

                if (partner.Id == 0)
                    entities.Partner.Add(partner);

                entities.SaveChanges();
                MessageBox.Show("Запись успешно сохранена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ListPage());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
