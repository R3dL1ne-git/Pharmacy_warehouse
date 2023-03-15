using Pharmacy_warehouse.Model;
using System;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Pharmacy_warehouse.Forms
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        string textCaptcha = CreateCaptcha();
        public AuthorizationWindow()
        {
            InitializeComponent();
            LabelCaptcha.Content = textCaptcha;
            tBoxCaptcha.Text = textCaptcha;
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            bool isUserValid = CheckUser(TboxLogin.Text, passwordBox.Password);
            bool isCaptchaValid = CheckCaptcha(tBoxCaptcha.Text);

            if (groupBox.Visibility != Visibility.Visible)
            {
                if (isUserValid)
                {
                    MainWindow main = new MainWindow();
                    this.Close();
                    main.Show();
                }
                else
                {
                    groupBox.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (isCaptchaValid)
                {
                    if (isUserValid)
                    {
                        MainWindow main = new MainWindow();
                        this.Close();
                        main.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Капча не совпадает с картинкой. Приложение заблокировано на 10 секунд.");
                    blockApp();
                }
            }
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            var securePassword = passwordBox.SecurePassword;
            var password = new System.Net.NetworkCredential(string.Empty, securePassword).Password;

            passwordBox.Password = password;

            passwordTextBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Collapsed;
            passwordTextBox.Text = password;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Visible;
        }

        public static string CreateCaptcha()
        {
            string allowChar = string.Empty;
            allowChar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowChar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowChar += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' };
            string[] ar = allowChar.Split(a);
            string pwd = string.Empty;
            string temp = string.Empty;
            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                temp = ar[(rnd.Next(0, ar.Length))];
                pwd += temp;
            }

            return pwd;
        }

        public bool CheckCaptcha(string text)
        {
            if (text == textCaptcha)
                return true;
            else
            {
                return false;
            }
        }

        public bool CheckUser(string log, string pass)
        {
            using (AptekaEntities db = new AptekaEntities())
            {
                var user = db.Users.FirstOrDefault(x => x.login_user == log);
                if (user != null)
                {
                    if (user.pass_user == pass)
                    {
                        MessageBox.Show($"Добро пожаловать, {user.first_name}!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Пароль неверен!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя в системе нет!");
                    return false;
                }
            }
        }

        void blockApp()
        {
            int blockTime = 10;
            Thread.Sleep(blockTime * 1000);
        }
    }
}
