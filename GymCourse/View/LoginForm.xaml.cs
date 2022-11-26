using GymCourse.Scrips;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymCourse.View
{
    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Page
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        BrushConverter bc = new BrushConverter();
        MySQL mySQL = new MySQL();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ВХод
            try
            {
                string logq = Login.Text;
                string pass = password.Text;

                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login AND `password`= @passw", mySQL.GetConnection());

                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = logq;
                command.Parameters.Add("@passw", MySqlDbType.VarChar).Value = pass;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                GetSet.log = logq;

                if (table.Rows.Count > 0)
                {
                   
                    MainApp main = new MainApp();
                    main.Show();
                    
 

                }
                else
                {
                    qwe.Text = "Пароль или логин неверный";
                    qwe.Visibility = Visibility.Visible;

                }

            }
            catch (Exception)
            {
                qwe.Text = "Проверьте соединение ";
                qwe.Visibility = Visibility.Visible;
                qwe.Foreground = (Brush)bc.ConvertFrom("#FFF9D652");

            }
        }
    }
}
