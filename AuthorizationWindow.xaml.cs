using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace my_project
{
    public partial class AuthorizationWindow : Window
    {
        DataBase dataBase       = new DataBase();
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
        private void Button_Sign_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void utton_Svernut(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Button_Window_Vhod(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow        = new WelcomeWindow();
            welcomeWindow.Show();
            Close();
        }
        private void Button_Window_Reg(object sender, RoutedEventArgs e)
        {
            RegistrationWindow winR = new RegistrationWindow();
            winR.Show();
            Close();
        }
        private void Button_Window_Avtoriz(object sender, RoutedEventArgs e)
        {
            var LoginUser           = TextBoxLogin.Text;
            var passUser            = TextBoxPassword.Password;
            SqlDataAdapter adapter  = new SqlDataAdapter();
            DataTable table         = new DataTable();
            string querystring      = $"select id_user, login_user, password_user from register where Login_user = '{LoginUser}' and password_user = '{passUser}'";
            SqlCommand command      = new SqlCommand(querystring, dataBase.GetConnection());
            adapter.SelectCommand   = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Авторицация прошла успешно");
                MainWindowApplications windowApplications    = new MainWindowApplications();
                windowApplications.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Не верно введен логин или пароль");
            }
        }
    }
}
