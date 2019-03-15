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
    /// Логика взаимодействия для CreateCompetition.xaml
    /// </summary>
    public partial class CreateCompetition : Window
    {
        public CreateCompetition()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin adm = new MenuAdmin();
            adm.Show();
            this.Close();
        }

        private void CreateCompetition_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Competition Reg = new ServiceReference1.Service1Competition();
            Reg.Name = Convert.ToString(Name.Text);
            Reg.Description = Convert.ToString(Desc.Text);
            Reg.Prize = Convert.ToDouble(Prize.Text);
            Reg.MinValue = Convert.ToDouble(MinValue.Text);
            Reg.ApplicationDeadline = Convert.ToDateTime(DeadLine.Text);
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            Service.AddCompetition(Reg);
            MenuAdmin Window = new MenuAdmin();
            Window.Show();
            this.Close();
        }
    }
}
