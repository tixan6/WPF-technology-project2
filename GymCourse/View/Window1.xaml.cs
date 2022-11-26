using GymCourse.Scrips;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string Photo = null;
        public Window1()
        {
            InitializeComponent();
        }
        MySQL MySQL = new MySQL();
        private static byte[] GetPhoto(string filePath)
        {

            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Photo != null)
            {
                String newsaddtext = "Статья добавлена";
                byte[] photo = GetPhoto(GetSet.photo);

                MySqlCommand command = new MySqlCommand("INSERT INTO `news` (`img`, `mtxt`,`txt`) VALUES (@photo, @mtext, @text)", MySQL.GetConnection());
                command.Parameters.Add("@photo", MySqlDbType.Blob).Value = photo;
                command.Parameters.Add("@mtext", MySqlDbType.Text).Value = nametxt.Text;
                command.Parameters.Add("@text", MySqlDbType.Text).Value = txt.Text;



                MySQL.openConBd();
                command.ExecuteNonQuery();

                newsAddText.Text = newsaddtext;
            }
            else
            {
                MessageBox.Show("Добавьте фото");
            }

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Code
           
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files(*.*)|*.*";

            if (open.ShowDialog() == true)
            {
                try
                {

                    Photo = open.FileName;
                    Uri uri = new Uri(Photo);
                    imageAdd.Source = new BitmapImage(new Uri(Photo));
                    GetSet.photo = Photo;

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }

        private void xxxL_MouseEnter(object sender, MouseEventArgs e)
        {
            xxxL.Opacity = 1;
        }

        private void xxxL_MouseLeave(object sender, MouseEventArgs e)
        {
            xxxL.Opacity = 0.6;
        }

        private void lllX_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ///
            this.WindowState = WindowState.Minimized;
        }

        private void lllX_MouseEnter(object sender, MouseEventArgs e)
        {
            lllX.Opacity = 1;
        }

        private void lllX_MouseLeave(object sender, MouseEventArgs e)
        {
            lllX.Opacity = 0.6;
        }
    }
}
