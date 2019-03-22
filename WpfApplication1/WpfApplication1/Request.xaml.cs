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
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        int ID_Competition = 0;
        public Request()
        {
            InitializeComponent();
            
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.SelectCompetition().Length; i++)
            {
                    combobox.Items.Add(Service.SelectCompetition()[i].Name);
            }
            
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.SelectCompetition().Length; i++)
            {
                if (Convert.ToString(combobox.SelectedItem) == Service.SelectCompetition()[i].Name)
                {
                    ID_Competition = Service.SelectCompetition()[i].ID_Competition;
                }
            }
        }

        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
                ServiceReference1.Service1Request Request = new ServiceReference1.Service1Request();
                Request.ProjectName = ProjectNamee.Text;
                Request.Competition_ID = ID_Competition;
                Service.AddRequest(Request);
                MenuClient Window = new MenuClient();
                Window.Show();
                this.Close();
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuClient Window = new MenuClient();
            Window.Show();
            this.Close();
        }
    }
}
