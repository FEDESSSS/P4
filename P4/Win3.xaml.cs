using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P4
{
    /// <summary>
    /// Логика взаимодействия для Win3.xaml
    /// </summary>
    public partial class Win3 : Window
    {
        public Win3()
        {
            InitializeComponent();
            BT.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Loc.Text == "")
            {
                MessageBox.Show("Введите название места");
            }
            else
            {
                string Loca = Loc.Text;
                List.Items.Add(Loca);
            }
        }
        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Показываем кнопку только если выбран элемент
            if (List.SelectedItem != null)
            {
                BT.Visibility = Visibility.Visible;
            }
            else
            {
                BT.Visibility = Visibility.Collapsed;
            }
        }

        private void BT_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = List.SelectedItem as string;
            if (selectedItem != null)
            {
                int index = List.SelectedIndex;
                List.Items[index] = selectedItem + " - Посетил";
                BT.Visibility = Visibility.Collapsed;
                List.SelectedItem = null;
                Loc.Clear();
            }
        }
    }
}
