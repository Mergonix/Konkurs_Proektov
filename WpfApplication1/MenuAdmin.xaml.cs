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
    /// Логика взаимодействия для MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void CreateComp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Clients user = new Clients();
            user.Show();
            this.Close();
        }

        private void Experts_Click(object sender, RoutedEventArgs e)
        {
            Experts exp = new Experts();
            exp.Show();
            this.Close();
        }
    }
}
