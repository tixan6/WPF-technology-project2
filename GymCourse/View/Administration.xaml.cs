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
    /// Логика взаимодействия для Administration.xaml
    /// </summary>
    public partial class Administration : Page
    {
        BrushConverter bc = new BrushConverter();
        MySQL mySQL = new MySQL();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();
        public Administration()

        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            try
            {
                string log = Login.Text;
                string pass = password.Text;
            
                MySqlCommand command = new MySqlCommand("SELECT * FROM `administration` WHERE `Login` = @login AND `Pass`= @passw", mySQL.GetConnection());

                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = log;
                command.Parameters.Add("@passw", MySqlDbType.VarChar).Value = pass;

                adapter.SelectCommand = command;
                adapter.Fill(table);


                if (table.Rows.Count > 0)
                {
                    Window1 window = new Window1();
                    window.Show();

                }
                else
                {
                    ErrorLog.Text = "Пароль или логин неверный";
                    ErrorLog.Visibility = Visibility.Visible;

                }

            }
            catch (Exception)
            {
                ErrorLog.Text = "Проверьте соединение ";
                ErrorLog.Visibility = Visibility.Visible;
                ErrorLog.Foreground = (Brush)bc.ConvertFrom("#FFF9D652");
  
            }


        }
    }
    
}
