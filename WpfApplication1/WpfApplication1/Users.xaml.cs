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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        public Clients()
        {
            InitializeComponent();
            ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
            DataGridTextColumn ColumnFIO = new DataGridTextColumn();
            ColumnFIO.Header = "Ф.И.О.";
            ColumnFIO.Binding = new Binding("FIO");
            Users.Columns.Add(ColumnFIO);
            DataGridTextColumn ColumnDateBirth = new DataGridTextColumn();
            ColumnDateBirth.Header = "Телефон";
            ColumnDateBirth.Binding = new Binding("Phone");
            Users.Columns.Add(ColumnDateBirth);
            DataGridTextColumn ColumnAdress = new DataGridTextColumn();
            ColumnAdress.Header = "Почта";
            ColumnAdress.Binding = new Binding("Email");
            Users.Columns.Add(ColumnAdress);

            for (int i = 0; i < Service.SelectUsers().Length; i++)
            {
                    Users.Items.Add(new Item() { FIO = Service.SelectUsers()[i].FIO , Phone = Service.SelectUsers()[i].Phone, Email = Service.SelectUsers()[i].Email });
            }
            Users.Columns[2].Width = 210;
        }
        public class Item
        {

            public string FIO { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menu = new MenuAdmin();
            menu.Show();
            this.Close();
        }
    }
}
