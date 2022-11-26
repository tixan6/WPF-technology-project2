using GymCourse.View;
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

namespace GymCourse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterForm.Visibility = Visibility.Visible;
            AutomaticForm.Visibility = Visibility.Hidden;
            AdministationForm.Visibility = Visibility.Hidden;
            LoginForm.Visibility = Visibility.Hidden;
            RegisterForm.Content = new Register();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            AutomaticForm.Content = new automatic();
        }


        //Нажатие на ВОЙТИ
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MainApp main = new MainApp();
            //main.Show();

            RegisterForm.Visibility = Visibility.Hidden;
            AutomaticForm.Visibility = Visibility.Hidden;
            AdministationForm.Visibility = Visibility.Hidden;
            LoginForm.Visibility = Visibility.Visible;
            LoginForm.Content = new LoginForm();

        }

        //leave
        private void Leave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
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


        //Sign In
        private void SignIn_MouseEnter(object sender, MouseEventArgs e)
        {
            SignIn.Opacity = 1;
        }

        private void SignIn_MouseLeave(object sender, MouseEventArgs e)
        {
            SignIn.Opacity = 0.7;
        }



        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            AdministationForm.Content = new Administration();
            AdministationForm.Visibility = Visibility.Visible;
            RegisterForm.Visibility = Visibility.Hidden;
            AutomaticForm.Visibility = Visibility.Hidden;
            LoginForm.Visibility = Visibility.Hidden;
        }
    }
}
