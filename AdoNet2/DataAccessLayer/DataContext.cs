using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DataContext

    {
       

        static DataContext()
        {
            connect = ConnectDatabase();
        }
        public static SqlConnection connect;
        public static SqlConnection ConnectDatabase()
        {
            //string server = ".";
            //string database = "AdventureWorks";
            //string username = "sa";
            //string password = "123";

            //string connectionstring = $"Server={server};Database={database};User Id={username};Password = {password} ";
            string conn = ConfigurationManager.AppSettings["connectionstring"].ToString();
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            connection.Close();
            return connection;



        }


        public static DataTable GetPersons(string name)
        {
            //TODO: ismini verdiğim adamları bulsun.İsim boş ise hepsini getirsin. 
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT_PERSON",connect);
            cmd.Parameters.AddWithValue("@Name",name);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            connect.Close();
            return dt;
        }
    }
}
