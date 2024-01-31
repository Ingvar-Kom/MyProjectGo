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
using System.Windows.Media.Animation;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Data.SqlTypes;






namespace my_project
{
    
    public partial class MainWindow : Window
    {

        DataBase dataBase = new DataBase();
        byte[] image_bytes;

        public MainWindow()
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

        private void Button_Window_Vhod(object sender, RoutedEventArgs e)
        {
            Window2 wwindow2 = new Window2();
            wwindow2.Show();
            Close();
        }
        private void Button_Window_Vhod2(object sender, RoutedEventArgs e)
        {
            Window3 wind3 = new Window3();
            wind3.Show();
            Close();
        }

        private void Button_Window_D(object sender, RoutedEventArgs e)
        {
            string login = InputLog.Text.Trim();
            string pass = InputPass.Password.Trim();
            string Imy = InputFirstName.Text.Trim();
            string Famili = InputLastName.Text.Trim();


            if (Famili.Length == 0)
            {
                InputLastName.Background = Brushes.DarkRed;
            }
            else if (Imy.Length == 0)
            {
                InputLastName.Background = Brushes.Transparent;
                InputFirstName.Background = Brushes.DarkRed;
            }
            else if (login.Length < 5)
            {
                InputFirstName.Background = Brushes.Transparent;
                InputLastName.Background = Brushes.Transparent;
                InputLog.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                InputLog.Background = Brushes.Transparent;
                InputFirstName.Background = Brushes.Transparent;
                InputLastName.Background = Brushes.Transparent;
                InputPass.Background = Brushes.DarkRed;
            }
            else
            {

                InputLog.Background = Brushes.Transparent;
                InputPass.Background = Brushes.Transparent;
                InputFirstName.Background = Brushes.Transparent;
                InputLastName.Background = Brushes.Transparent;

                var fName = InputFirstName.Text;
                var lName = InputLastName.Text;
                var log = InputLog.Text;
                var pas = InputPass.Password;
                if (Checkuser() == false)
                {
                   

                    string connectionString = @"Data Source=DESKTOP-NTMKSG2\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"; 
                    using (SqlConnection connection = new SqlConnection(connectionString)) 
                    {
                        connection.Open(); 
                        SqlCommand command = new SqlCommand(); 
                        command.Connection = connection; 
                        command.CommandText = $"INSERT INTO register(Rimage, login_user, password_user, LName, FName) VALUES (@ImageData, '{log}', '{pas}','{lName}','{fName}')"; 
                        command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);
                        command.Parameters["@ImageData"].Value = image_bytes;

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Ok!");
                            Window1 wwindow1 = new Window1();
                            wwindow1.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("nooooo!");
                        }
                        dataBase.closeConnection();
                    }
                }
            }
        }

        private Boolean Checkuser()
        {
            var logiUser = InputLog.Text;
            var passUser = InputPass.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring1 = $"select id_user, login_user, password_user from register where login_user ='{logiUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring1, dataBase.getConnection());

            adapter.SelectCommand = command;
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
            OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
            openFileDialog.ShowDialog(); // показываем
            
            image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла
            image.Source = ByteImage.Convert(ByteImage.GetImageFromByteArray(image_bytes));


           
        }

        private void DemoClick(object sender, RoutedEventArgs e)
        {
            Window1 wwindow1 = new Window1();
            wwindow1.Show();
            Close();
        }
    }

}

 