using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data; 
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Configuration;

namespace GymCourse.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterData.xaml
    /// </summary>
    public partial class RegisterData : Page
    {
        public RegisterData()
        {
            InitializeComponent();
            LastRegister.Visibility = Visibility.Visible;
            LastRegister.Content = new LastRegister();
            
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Code code = new Code();
            code.Show();
            //SendMessage();
        }

        //Кнопка создания аккаунта

    }
}
