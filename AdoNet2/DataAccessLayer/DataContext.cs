using Entities;
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
            DataTable dt = new DataTable("Person");
            dt.Load(dr);
            connect.Close();
            return dt;
        }

        public static List<Person> GetPersonForListBox(string name)
        {
            //TODO: Verileri al, Liste olarak geri dön. DataReader ile
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT_PERSON", connect);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<Person> isimler = new List<Person>();
            while (dr.Read())
            {
                Person person = new Person();
                person.BusinessEntityId =Convert.ToInt32(dr["BusinessEntityId"]);
                person.FirstName=  dr["FirstName"].ToString();
                person.MiddleName = dr["MiddleName"].ToString();
                person.LastName = dr["LastName"].ToString();
              

                isimler.Add(person);
            }
            dr.Close();
            connect.Close();
            return isimler;
        }

        public static DataTable GetPersonsDetail(int detay)
        {
            //TODO: ismini verdiğim adamları bulsun.İsim boş ise hepsini getirsin. 
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT_PERSON_DETAIL", connect);
            cmd.Parameters.AddWithValue("@BusinessEntityId", detay);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("Person");
            dt.Load(dr);
            connect.Close();
            return dt;
        }
    }
}
