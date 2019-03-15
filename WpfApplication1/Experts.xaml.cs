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
    /// Логика взаимодействия для Experts.xaml
    /// </summary>
    public partial class Experts : Window
    {
        public Experts()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn ColumnFIO = new DataGridTextColumn();
            ColumnFIO.Header = "Ф.И.О.";
            ColumnFIO.Binding = new Binding("FIO");

            for (int i = 0; i < Service.SelectExperts().Length; i++)
            {
                Expert.Items.Add(new Item() { FIO = Service.SelectExperts()[i].FIO });
            }
            Expert.Columns[2].Width = 210;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menu = new MenuAdmin();
            menu.Show();
            this.Close();
        }
        public class Item
        {

            public string FIO { get; set; }

        }
    }
}
