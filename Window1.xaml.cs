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

namespace my_project
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void button_Sign_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Svernut(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }


        private void Mes_Demo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("сработала какая-то функция)"); 
        }
        private void Button_Window_Vhod(object sender, RoutedEventArgs e)
        {
            Window2 wwindow2 = new Window2();
            wwindow2.Show();
            Close();
        }
        private void Button_Window_Reg(object sender, RoutedEventArgs e)
        {
            MainWindow winR = new MainWindow();
            winR.Show();
            Close();
        }
        

    }
}