using GymCourse.Scrips;
using Microsoft.Win32;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GymCourse.View
{
    /// <summary>
    /// Логика взаимодействия для MainApp.xaml
    /// </summary>
    public partial class MainApp : Window
    {

        //AnimNews.BorderThickness = new Thickness(0.6);
        //AnimNews.BorderBrush = Brushes.SlateBlue;

        // FrameNews.Content = new newss();
        public MainApp()
        {
            InitializeComponent();

            try
            {
                string connStr = "server=localhost;port=3306;username=root;password=root;database=gymstudio";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sqlPhoto = "SELECT PathAvatar FROM users WHERE login =  '" + GetSet.log + "'";
                MySqlCommand commandPhoto = new MySqlCommand(sqlPhoto, conn);

                string PhotoAva = commandPhoto.ExecuteScalar().ToString();
                AvatarSett.ImageSource = new BitmapImage(new Uri(PhotoAva));

                conn.Close();

            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Ваш аккаунт был удален!!!");
            }
        }

        private void AnimNews_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameNews.Content = new newss();

            FrameNews.Visibility = Visibility.Visible;
            FramePrice.Visibility = Visibility.Hidden;
            FrameGym.Visibility = Visibility.Hidden;
        }

        private void AnimNews_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimNews.BorderThickness = new Thickness(0.6);
            AnimNews.BorderBrush = Brushes.SlateBlue;
        }

        private void AnimNews_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimNews.BorderThickness = new Thickness(0);
        }

        //

        private void AnimPrice_MouseDown(object sender, MouseButtonEventArgs e)
        {

            FramePrice.Content = new Price();

            FrameNews.Visibility = Visibility.Hidden;
            FramePrice.Visibility = Visibility.Visible;
            FrameGym.Visibility = Visibility.Hidden;
        }
        private void AnimPrice_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimPrice.BorderThickness = new Thickness(0.6);
            AnimPrice.BorderBrush = Brushes.SlateBlue;
        }

        private void AnimPrice_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimPrice.BorderThickness = new Thickness(0);
        }
        //
        private void AnimGym_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //dfdf
            FrameGym.Content = new Trener();

            FrameNews.Visibility = Visibility.Hidden;
            FramePrice.Visibility = Visibility.Hidden;
            FrameGym.Visibility = Visibility.Visible;
        }

        private void AnimGym_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimGym.BorderThickness = new Thickness(0.6);
            AnimGym.BorderBrush = Brushes.SlateBlue;
        }

        private void AnimGym_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimGym.BorderThickness = new Thickness(0);
        }


        //s/ad
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            xxx.Opacity = 1;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            xxx.Opacity = 0.6;

        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void PackIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            X.Opacity = 1;
        }

        private void X_MouseLeave(object sender, MouseEventArgs e)
        {
            X.Opacity = 0.6;
        }

        private void PackIcon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void PackIcon_MouseEnter_1(object sender, MouseEventArgs e)
        {
            L.Opacity = 1;
        }

        private void PackIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            L.Opacity = 0.6;
        }

        string Photo = null;
        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //Добавить фото
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files(*.*)|*.*";

            if (open.ShowDialog() == true)
            {
                try
                {
                    MySQL my = new MySQL();
                    Photo = open.FileName;
                    Uri uri = new Uri(Photo);
                    AvatarSett.ImageSource = new BitmapImage(new Uri(Photo));
                    GetSet.photoAvar = uri.ToString();
                    MySqlCommand command = new MySqlCommand("UPDATE users SET PathAvatar = '" + GetSet.photoAvar + "' WHERE login = '" + GetSet.log + "' ", my.GetConnection());
                    my.openConBd();
                    command.ExecuteNonQuery();
                    my.CloseConBd();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
           // MessageBox.Show(GetSet.log);
        }
    }
}
