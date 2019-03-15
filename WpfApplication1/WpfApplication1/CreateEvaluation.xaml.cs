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
    /// Логика взаимодействия для CreateEvaluation.xaml
    /// </summary>
    public partial class CreateEvaluation : Window
    {
        int ID_Request = 0;
        int ID_Expert = 0;
        public CreateEvaluation()
        {
            InitializeComponent();

            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.SelectRequest().Length; i++)
            {
                Request.Items.Add(Service.SelectRequest()[i].ProjectName);
            }
            for (int i = 0; i < Service.SelectExperts().Length; i++)
            {
                Expert.Items.Add(Service.SelectExperts()[i].FIO);
            }
        }

        private void Request_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.SelectRequest().Length; i++)
            {
                if (Convert.ToString(Request.SelectedItem) == Service.SelectRequest()[i].ProjectName)
                {
                    ID_Request = Service.SelectRequest()[i].ID_Request;
                }
            }
        }

        private void Expert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            for (int i = 0; i < Service.SelectExperts().Length; i++)
            {
                if (Convert.ToString(Expert.SelectedItem) == Service.SelectExperts()[i].FIO)
                {
                    ID_Expert = Service.SelectExperts()[i].ID_Experts;
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Request.Text=="" || Expert.Text=="" || Name1.Text =="" || Evaluation.Text =="")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
                ServiceReference1.Service1Evalulation Ev = new ServiceReference1.Service1Evalulation();
                Ev.Request_ID = ID_Request;
                Ev.Expert_ID = ID_Expert;
                Ev.Name = Name1.Text;
                Ev.EvalulationNum = Convert.ToDouble(Evaluation.Text);
                Service.AddEvalulation(Ev);
                MenuAdmin Window = new MenuAdmin();
                Window.Show();
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin Window = new MenuAdmin();
            Window.Show();
            this.Close();
        }
    }
}
