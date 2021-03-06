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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoUserControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUserInfo newUser = new NewUserInfo();
            newUser.txtFirstName.Text = "NewUser";
            newUser.txtLastName.Text = "Dynamic";
            lbEmployees.Items.Add(newUser);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove all user controls?", 
                                                "Confirmation", 
                                                MessageBoxButton.YesNo, 
                                                MessageBoxImage.Question
                                               );

            if (result == MessageBoxResult.Yes)
                lbEmployees.Items.Clear();
        }
    }
}
