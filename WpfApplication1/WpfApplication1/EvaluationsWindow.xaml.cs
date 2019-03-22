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
    /// Логика взаимодействия для EvaluationsWindow.xaml
    /// </summary>
    public partial class EvaluationsWindow : Window
    {
        private readonly Evalulation _context = new Evalulation();
        public EvaluationsWindow()
        {
            InitializeComponent();
            CollectionViewSource evalViewSourse = (CollectionViewSource)FindResource("service1EvalulationViewSource");
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuClient cl = new MenuClient();
            cl.Show();
            this.Close();
        }
        public class Item
        {

            public string Request { get; set; }
            public string Expert { get; set; }
            public string Name { get; set; }
            public double Num { get; set; }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource service1EvalulationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("service1EvalulationViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // service1EvalulationViewSource.Source = [универсальный источник данных]
        }
    }
}
