﻿using BuildingMaterials.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuildingMaterials
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            this.DataContext = new AdminWindowViewModel();
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AdminWindowViewModel).DeleteProduct();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AdminWindowViewModel).AddWindow();
        }
    }
}
