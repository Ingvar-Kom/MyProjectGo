using System;
using System.Windows;
using System.Windows.Input;

namespace my_project
{
    public partial class MainWindowApplications : Window
    {
        public MainWindowApplications()
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
            WindowState = WindowState.Minimized; 
        }
        private void Mes_Demo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("сработала какая-то функция)"); 
        }
        private void Button_Window_Vhod(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }
        private void Button_Window_Reg(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }
    }
}
