using GymCourse.Scrips;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GymCourse.View
{
    /// <summary>
    /// Логика взаимодействия для Code.xaml
    /// </summary>
    public partial class Code : Window
    {
        private int count = 3;
        LastRegister last = new LastRegister();
        MySQL mySQL = new MySQL();

        public Code()
        {
            InitializeComponent();
        }


        private void DataBase() 
        {
            

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `email`, `PathAvatar`) VALUES (@_login, @_password, @_email, @_photo)", mySQL.GetConnection());

            command.Parameters.Add("@_login", MySqlDbType.VarChar).Value = GetSet.log;
            command.Parameters.Add("@_password", MySqlDbType.VarChar).Value = GetSet.pass;
            command.Parameters.Add("@_email", MySqlDbType.VarChar).Value = GetSet.email;
            command.Parameters.Add("@_photo", MySqlDbType.Text).Value = @"D:\Study\C#\Курсовая Дианы\GymCourse\Image\BG.jpg";

            mySQL.openConBd();

            if (command.ExecuteNonQuery() == 1)
            {
                //Потом вернуть пользователя в меня логина
                this.Close();
                MainApp main = new MainApp();
                main.Show();
            }
            else
            {
                //Понять причину
                string checkNet = " Проверьте соединение со сетью";
                ////ErrorTxt.Text = checkNet;
                MessageBox.Show(checkNet);
            }

            mySQL.CloseConBd();
        } 

        //Подтвердить
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Login.Text != "")
            {
                if (Login.Text == GetSet.Code.ToString())
                {
                    DataBase();

                }
                else
                {
                    count--;
                    txtCount.Text = count.ToString();
                    if (count == 0)
                    {
                        txt.Visibility = Visibility.Hidden;
                        txtCount.Visibility = Visibility.Hidden;
                        textEmail.Text = "Вы ввели код подтверждения неправильно 3 раза. В следующий раз вы сможете ввести код через 30 мин";
                        textEmail.FontSize = 10;
                    }
                }
            }
            else
            {
                textEmail.Text = "Поле не должно быть пустым";
            }

            //Click
           
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            confirm.Opacity = 1;
        }

        private void confirm_MouseLeave(object sender, MouseEventArgs e)
        {
            confirm.Opacity = 0.7;
        }
        

        //Leave
        private void Leave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            GetSet.Condition = true;

        }

        private void Leave_MouseEnter(object sender, MouseEventArgs e)
        {
            Leave.Opacity = 1;
        }

        private void Leave_MouseLeave(object sender, MouseEventArgs e)
        {
            Leave.Opacity = 0.5;
        }


        //Min
        private void Min_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Min_MouseEnter(object sender, MouseEventArgs e)
        {
            Min.Opacity = 1;
        }

        private void Min_MouseLeave(object sender, MouseEventArgs e)
        {
            Min.Opacity = 0.5;
        }

        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
