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
    /// Логика взаимодействия для AddExpert.xaml
    /// </summary>
    public partial class AddExpert : Window
    {
        public AddExpert()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Experts exp = new Experts();
            exp.Show();
            this.Close();
        }

        private void AddExpert1_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Experts Reg = new ServiceReference1.Service1Experts();
            Reg.FIO = Convert.ToString(FIO.Text);
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            Service.AddExpert(Reg);
            Experts Window = new Experts();
            Window.Show();
            this.Close();
        }
    }
}
