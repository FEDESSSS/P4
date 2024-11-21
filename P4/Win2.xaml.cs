using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;

namespace P4
{
    /// <summary>
    /// Логика взаимодействия для Win2.xaml
    /// </summary>
    public partial class Win2 : Window
    {
        public Win2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (Pass.Text == Pas.Text)
            {
                DataBase dataBase = new DataBase();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `user` (`Name`, `Surname`, `Oth`, `Dr`, `Email`, `Password`) VALUES (@uN, @uS, @uO, @uD, @uE, @uP)", dataBase.Getbd());
                cmd.Parameters.Add("@uN", MySqlDbType.VarChar).Value = name.Text;
                cmd.Parameters.Add("@uS", MySqlDbType.VarChar).Value = sur.Text;
                cmd.Parameters.Add("@uO", MySqlDbType.VarChar).Value = oth.Text;
                cmd.Parameters.Add("@uD", MySqlDbType.VarChar).Value = dr.Text;
                cmd.Parameters.Add("@uE", MySqlDbType.VarChar).Value = email.Text;
                cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = Pass.Text;

                dataBase.Openbd();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт был создан");
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Аккаунт не был создан");
                }
                dataBase.Closebd();
            }
            else if(Pass.Text==""|| sur.Text == "" || name.Text == ""|| oth.Text == "" || email.Text == "" || dr.Text == "" || Pas.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
        }
    }
}
