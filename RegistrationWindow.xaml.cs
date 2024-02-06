using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace my_project
{
    public partial class RegistrationWindow : Window
    {
        DataBase dataBase = new DataBase();
        byte[] image_bytes;
        public RegistrationWindow()
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
        private void Button_Window_Vhod(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }
        private void Button_Window_Vhod2(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            Close();
        }
        private void Button_Window_D(object sender, RoutedEventArgs e)
        {
            string login                    = InputLog.Text.Trim();
            string pass                     = InputPass.Password.Trim();
            string Imy                      = InputFirstName.Text.Trim();
            string Famili                   = InputLastName.Text.Trim();

            if (Famili.Length == 0)
            {
                InputLastName.Background    = Brushes.DarkRed;
            }
            else if (Imy.Length == 0)
            {
                InputLastName.Background    = Brushes.Transparent;
                InputFirstName.Background   = Brushes.DarkRed;
            }
            else if (login.Length < 5)
            {
                InputFirstName.Background   = Brushes.Transparent;
                InputLastName.Background    = Brushes.Transparent;
                InputLog.Background         = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                InputLog.Background         = Brushes.Transparent;
                InputFirstName.Background   = Brushes.Transparent;
                InputLastName.Background    = Brushes.Transparent;
                InputPass.Background        = Brushes.DarkRed;
            }
            else
            {
                InputLog.Background         = Brushes.Transparent;
                InputPass.Background        = Brushes.Transparent;
                InputFirstName.Background   = Brushes.Transparent;
                InputLastName.Background    = Brushes.Transparent;

                var fName                   = InputFirstName.Text;
                var lName                   = InputLastName.Text;
                var log                     = InputLog.Text;
                var pas                     = InputPass.Password;

                if (Checkuser() == false)
                {
                    string connectionString = @"Data Source=DESKTOP-NTMKSG2\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"; 
                    using (SqlConnection connection = new SqlConnection(connectionString)) 
                    {
                        connection.Open(); 
                        SqlCommand command  = new SqlCommand(); 
                        command.Connection  = connection; 
                        command.CommandText = $"INSERT INTO register(Rimage, login_user, password_user, LName, FName) VALUES (@ImageData, '{log}', '{pas}','{lName}','{fName}')"; 
                        command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);
                        command.Parameters["@ImageData"].Value = image_bytes;

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Регистрация прошла успешно!");
                            MainWindowApplications mainWindowApplications = new MainWindowApplications();
                            mainWindowApplications.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при регистрации!");
                        }
                        dataBase.CloseConnection();
                    }
                }
            }
        }
        private Boolean Checkuser()
        {
            var logiUser            = InputLog.Text;
            var passUser            = InputPass.Password;
            SqlDataAdapter adapter  = new SqlDataAdapter();
            DataTable table         = new DataTable();
            string querystring1     = $"select id_user, login_user, password_user from register where login_user ='{logiUser}' and password_user = '{passUser}'";
            SqlCommand command      = new SqlCommand(querystring1, dataBase.GetConnection());
            adapter.SelectCommand   = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else if(image_bytes == null)
            {
                MessageBox.Show("Загрузите фото!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            image_bytes = File.ReadAllBytes(openFileDialog.FileName); 
            image.Source = ByteImage.Convert(ByteImage.GetImageFromByteArray(image_bytes)); 
        }
        private void DemoClick(object sender, RoutedEventArgs e)
        {
            MainWindowApplications mainWindowApplications = new MainWindowApplications();
            mainWindowApplications.Show();
            Close();
        }
    }
}

 