using Entites;
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
    public class DataContext
    {
        static SqlConnection connection;


        static DataContext()
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public static DataTable GetPersons(string name)
        {


            SqlCommand cmd = new SqlCommand("SELECT_PERSON", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);


            connection.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dtPerson = new DataTable("Person");
            dtPerson.Load(sdr);

            connection.Close();

            return dtPerson;
        }


        public static List<Person> GetPersonForListBox(string name)
        {
            //TODO: Verileri al, Liste olarak geri dön. DataReader ile

            return null;
        }
    }
}
