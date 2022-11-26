using GymCourse.Scrips;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymCourse.View
{
    /// <summary>
    /// Логика взаимодействия для LastRegister.xaml
    /// </summary>
    public partial class LastRegister : Page
    {
        public LastRegister()
        {
            InitializeComponent();
        }

        public string _login { get; set; }
        public string _mail { get; set; }
        public string _password { get; set; }
        public string _passwordTwo { get; set; }


        

        private bool ComparePasswords(string one, string two) {

            bool check = false;
            
            string pattPass = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$";
            if (one == two && Regex.IsMatch(one, pattPass) && Regex.IsMatch(two, pattPass))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }

        private bool CompareMail(string Mail)
        {

            bool check = false;
            string pattEmail = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            if (Regex.IsMatch(Mail, pattEmail))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }

        private bool CompareLogin(string login)
        {

            bool check = false;
            string pattLog = @"^[\w-[\d_]][\w-[_]]{1,9}$";
            if (Regex.IsMatch(login, pattLog))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }

        private void InputErrorOrEntry(bool pass, bool mail, bool log) 
        {
            bool one = false;
            bool two = false;
            bool three = false;

            if (pass == false)
            {
                Pass.Visibility = Visibility.Visible;
                PassRepead.Visibility = Visibility.Visible;
            }
            else { one = true; }

            if (mail == false)
            {
                mailError.Visibility = Visibility.Visible;
            }
            else { two = true; }

            if (log == false)
            {
                loginError.Visibility = Visibility.Visible;
            }
            else { three = true; }

            if (one == true)
            {
                Pass.Visibility = Visibility.Hidden;
                PassRepead.Visibility = Visibility.Hidden;
            }

            if (two == true)
            {
                mailError.Visibility = Visibility.Hidden;
            }

            if (three == true)
            {
                loginError.Visibility = Visibility.Hidden;
            }

            if (one == true && two == true && three == true )
            {
                MainRegView.Visibility = Visibility.Hidden;
                Loading.Visibility = Visibility.Visible;

                SendMessage(_mail);
                Code code = new Code();
                code.Show();

                GetSet.log = _login;
                GetSet.pass = _password;
                GetSet.email = _mail;
            }        
            
        }

        private void SendMessage(string emailAdress)
        {
            string code = Random().ToString();

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("admin@company.com", "Моя компания");
            message.To.Add(emailAdress);
            message.Subject = "Сообщение от администрации";
            message.Body = "<div style=\"color: black;\">Код для создание аккаунта  + </div>" + code;

            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
            {
                client.Credentials = new NetworkCredential("mail", "pass");
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(message);
            }
        }
        private void animError()
        {
            TranslateTransform translateTransform = new TranslateTransform();
            loginError.RenderTransform = translateTransform;
            mailError.RenderTransform = translateTransform;
            Pass.RenderTransform = translateTransform;
            PassRepead.RenderTransform = translateTransform;

            //1
            DoubleAnimation animationX = new DoubleAnimation(0, 4, TimeSpan.FromSeconds(5));
            translateTransform.BeginAnimation(TranslateTransform.XProperty, animationX);
            DoubleAnimation animationX2 = new DoubleAnimation(-4, -10, TimeSpan.FromSeconds(5));
            translateTransform.BeginAnimation(TranslateTransform.XProperty, animationX2);
            DoubleAnimation animationY = new DoubleAnimation(0, 4, TimeSpan.FromSeconds(5));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, animationY);
            DoubleAnimation animationY2 = new DoubleAnimation(-4, 0, TimeSpan.FromSeconds(5));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, animationY2);
            //2
            DoubleAnimation animationXTwo = new DoubleAnimation(0, 4, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.XProperty, animationXTwo);
            DoubleAnimation animationX2Two = new DoubleAnimation(-4, 0, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.XProperty, animationX2Two);
            DoubleAnimation animationYTwo = new DoubleAnimation(0, 4, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, animationYTwo);
            DoubleAnimation animationY2Two = new DoubleAnimation(-4, 0, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, animationY2Two);
            //3
            DoubleAnimation animationXThree = new DoubleAnimation(0, 4, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.XProperty, animationXThree);
            DoubleAnimation animationX2Three = new DoubleAnimation(-4, 0, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.XProperty, animationX2Three);
            DoubleAnimation animationYThree = new DoubleAnimation(0, 4, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, animationYThree);
            DoubleAnimation animationY2Three = new DoubleAnimation(-4, 0, TimeSpan.FromSeconds(0.1));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, animationY2Three);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _login = Login.Text;
            _mail = Mail.Text;
            _password = password.Text;
            _passwordTwo = RepeatPassword.Text;

            InputErrorOrEntry(ComparePasswords(_password, _passwordTwo), CompareMail(_mail), CompareLogin(_login));
            animError();

        }

        private int Random() 
        {
            Random rnd = new Random();
            int value = rnd.Next(1000, 9999);
            GetSet.Code = value;
            return value;
        }

        private void refresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (GetSet.Condition == true)
            {
                Loading.Visibility = Visibility.Hidden;
                MainRegView.Visibility = Visibility.Visible;
            }
        }
    }
}
