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
    /// Логика взаимодействия для Автомобили.xaml
    /// </summary>
    public partial class LadaBase : Page
    {
        public LadaBase()
        {
            InitializeComponent();
            //DGridAutomibili.ItemsSource = ladaAutoEntities.GetContext().Автомобили.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Автомобили));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var avtomobiliForRemoving = DGridAutomibili.SelectedItems.Cast<Автомобили>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {avtomobiliForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ladaAutoEntities.GetContext().Автомобили.RemoveRange(avtomobiliForRemoving);
                    ladaAutoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridAutomibili.ItemsSource = ladaAutoEntities.GetContext().Автомобили.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ladaAutoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridAutomibili.ItemsSource = ladaAutoEntities.GetContext().Автомобили.ToList();
            }
        }
    }
}
