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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public Results()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn Request = new DataGridTextColumn();
            Request.Header = "Заявка";
            Request.Binding = new Binding("Request");
            Res.Columns.Add(Request);
            DataGridTextColumn ColumnDateBirth = new DataGridTextColumn();
            ColumnDateBirth.Header = "Суммарная оценка";
            ColumnDateBirth.Binding = new Binding("Num");
            Res.Columns.Add(ColumnDateBirth);
            DataGridTextColumn Prize = new DataGridTextColumn();
            Prize.Header = "Приз";
            Prize.Binding = new Binding("Prize");
            Res.Columns.Add(Prize);
            double max = 0;
            int idmax = 0;
            double [] mass = new double[Service.SelectRequest().Length];
            for (int i = 0; i < Service.SelectEvalulation().Length; i++)
            {
                mass[i] = Service.SelectEvalulation()[i].EvalulationNum;
                if (Service.SelectEvalulation()[i].EvalulationNum>max)
                {
                    max = Service.SelectEvalulation()[i].EvalulationNum;
                    idmax = i;
                }
            }
            double[] mass2 = new double[Service.SelectRequest().Length];
            double minPrize = Service.SelectCompetition()[1].MinValue;
            double PrizeMax = Service.SelectCompetition()[1].Prize;
            PrizeMax =PrizeMax-( minPrize*Convert.ToDouble(Service.SelectEvalulation().Length));
            for (int i = 0; i < Service.SelectEvalulation().Length; i++)
            {

            }
            for (int i = 0; i < Service.SelectEvalulation().Length; i++)
            {
                if (idmax != i)
                {
                    Res.Items.Add(new Item() { Request = Service.FindByIdRequest(Service.SelectRequest()[i].ID_Request).ProjectName, Num = mass[i], Prize = minPrize });
                }
                else
                {
                    Res.Items.Add(new Item() { Request = Service.FindByIdRequest(Service.SelectRequest()[i].ID_Request).ProjectName, Num = mass[i], Prize = PrizeMax });
                
                }
            }
        }

        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            MenuClient cl = new MenuClient();
            cl.Show();
            this.Close();
        }
        public class Item
        {

            public string Request { get; set; }
            public double Num { get; set; }
            public double Prize { get; set; }

        }
    }
}
