using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        DataBase dataBase = new DataBase();
        public Window2()
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
            Window3 wwindow3 = new Window3();
            wwindow3.Show();
            Close();
        }
        private void Button_Window_Reg(object sender, RoutedEventArgs e)
        {
            MainWindow winR = new MainWindow();
            winR.Show();
            Close();
        }
        private void Button_Window_Avtoriz(object sender, RoutedEventArgs e)
        {

            var LoginUser = TextBox_Login.Text;
            var passUser = TextBox_password.Password;


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where Login_user = '{LoginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Авторицация прошла успешно");
                Window1 wwindow1 = new Window1();
                wwindow1.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Не верно введен логин или пароль");
            }

            
        }
    }
}
