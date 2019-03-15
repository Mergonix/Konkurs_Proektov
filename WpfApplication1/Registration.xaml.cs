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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration1_Click(object sender, RoutedEventArgs e)
        {
            var input = Password.Text;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{6,}");
            var hasCymbols = new Regex(@"[+]{1}[1-9]{1} [0-9]{3} [0-9]{3} [0-9]{2} [0-9]{2}");

            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);

            var inputTepelhone = Telephone.Text;
            var hasTelephone = new Regex(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$");
            var TelephoneValid = hasCymbols.IsMatch(inputTepelhone);
            if (Email.Text == "" || FIO.Text == "" || Telephone.Text == "" || Password.Text == "" || Login.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Внимание");
            }
            else if (TelephoneValid == false)
            {
                MessageBox.Show("Телефон должен быть записан в международном формате: +Х ХХХ ХХХ ХХ ХХ", "Внимание");
            }
            else if (isValidated == false || (Password.Text.Contains('!') == false && Password.Text.Contains('@') == false && Password.Text.Contains('#') == false && Password.Text.Contains('$') == false && Password.Text.Contains('%') == false && Password.Text.Contains('^') == false))
            {
                MessageBox.Show("Пароль должен соответствовать следующим требованиям: Минимум 6 символов, Минимум 1 прописная буква, Минимум 1 цифра, По крайней мере один из следующих символов : !@#$%^", "Внимание");
            }
            else
            {
                ServiceReference1.Service1Users Reg = new ServiceReference1.Service1Users();
                Reg.Login = Convert.ToString(Login.Text);
                Reg.Email = Convert.ToString(Email.Text);
                Reg.FIO = Convert.ToString(FIO.Text);
                Reg.Phone = Convert.ToString(Telephone.Text);
                Reg.Password = Convert.ToString(Password.Text);
                Reg.Admin = false;
                ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
                Service.AddUsers(Reg);
                MainWindow Window = new MainWindow();
                Window.Show();
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();
        }
    }
}
