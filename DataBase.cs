using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Markup;


namespace my_project
{
    internal class DataBase
    {

        SqlConnection sglConnection = new SqlConnection(@"Data Source=DESKTOP-NTMKSG2\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");

        
        public void openConnection()
        {
            if (sglConnection.State == System.Data.ConnectionState.Closed)
            {
                sglConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sglConnection.State == System.Data.ConnectionState.Open)
            {
                sglConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sglConnection;
        }

    }
}
