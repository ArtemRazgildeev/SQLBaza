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

namespace LadaAutoApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Автомобили _currentCar = new Автомобили();
        public AddEditPage(Автомобили selectedAvtomobili)
        {
            if (selectedAvtomobili != null)
                _currentCar = selectedAvtomobili;
            InitializeComponent();
            DataContext = _currentCar;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentCar.Модель))
                errors.AppendLine("Укажите название модели");
            if (string.IsNullOrWhiteSpace(_currentCar.Цвет))
                errors.AppendLine("Укажите цвет");
            if (string.IsNullOrWhiteSpace(_currentCar.Комплектации))
                errors.AppendLine("Укажите комплектацию");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentCar.Цена)))
                errors.AppendLine("Укажите цену");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentCar.Код == 0)
                ladaAutoEntities.GetContext().Автомобили.Add(_currentCar);
            try
            {
                ladaAutoEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
