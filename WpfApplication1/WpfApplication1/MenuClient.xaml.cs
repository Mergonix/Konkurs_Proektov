﻿using System;
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
    /// Логика взаимодействия для MenuClient.xaml
    /// </summary>
    public partial class MenuClient : Window
    {
        public MenuClient()
        {
            InitializeComponent();
        }

        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Request request = new Request();
            request.Show();
            this.Close();
        }

        private void Evaluations_Click(object sender, RoutedEventArgs e)
        {
            EvaluationsWindow ev = new EvaluationsWindow();
            ev.Show();
            this.Close();
        }

        private void Results_Click(object sender, RoutedEventArgs e)
        {
            Results ev = new Results();
            ev.Show();
            this.Close();
        }
    }
}
