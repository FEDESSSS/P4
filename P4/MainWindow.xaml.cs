using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace P4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Win2 win2 = new Win2();
            win2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataBase dB = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `user` WHERE `Email` = @uN AND `Password` = @uP", dB.Getbd());
            cmd.Parameters.Add("@uN", MySqlDbType.VarChar).Value = Email.Text;
            cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = pass.Text;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                Win3 main = new Win3();
                main.Show();
            }
            else
            {
                MessageBox.Show("Аккаунт не найден");
            }
        }
    }
}
