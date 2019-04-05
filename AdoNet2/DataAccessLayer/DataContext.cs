using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DataAccessLayer
{
    public class DataContext
    {

        public static SqlConnection baglan;

        static DataContext()
        {
            string connection = ConfigurationManager.AppSettings["ConnectionString"].ToString();

            baglan = new SqlConnection(connection);
        }



        public static DataTable GetPersons(string name)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("persongetir", baglan);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            //TODO: ismini verdiğim adamları bulsun.İsim boş ise hepsini getirsin. 
            baglan.Close();
            return dt;
        }
    }
}
