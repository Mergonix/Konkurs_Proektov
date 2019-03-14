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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Window
    {
        public authorization()
        {
            InitializeComponent();
        }
        public static int IDUser;
        private void Authorization1_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            if (Service.Authorisation(Convert.ToString(Login.Text), Convert.ToString(Password.Password)).admin==false && Service.Authorisation(Convert.ToString(Login.Text), Convert.ToString(Password.Password)).error == false)
            {
                IDUser = Service.Authorisation(Convert.ToString(Login.Text), Convert.ToString(Password.Password)).id_user;
                MenuClient Window = new MenuClient();
                Window.Show();
                this.Close();
            }
            else if (Service.Authorisation(Convert.ToString(Login.Text), Convert.ToString(Password.Password)).admin == true && Service.Authorisation(Convert.ToString(Login.Text), Convert.ToString(Password.Password)).error == false)
            {
                IDUser = Service.Authorisation(Convert.ToString(Login.Text), Convert.ToString(Password.Password)).id_user;
                MenuAdmin Window = new MenuAdmin();
                Window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(Service.Authorisation(Convert.ToString(Login.Text), Convert.ToString(Password.Password)).error_message, "Внимание");
            }
        }
    }
}
