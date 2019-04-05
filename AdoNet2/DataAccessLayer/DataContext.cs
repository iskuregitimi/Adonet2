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
        public static DataTable GetPersons(string name)
        {
            //TODO: ismini verdiğim adamları bulsun.İsim boş ise hepsini getirsin. 

            string connection = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("GET_PERSONS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
            cmd.Parameters["@FirstName"].Value = name;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();

            return dt;
        }

        public static DataTable GetAllPersons()
        {
            string connection = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("GET_ALL_PERSONS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();

            return dt;
        }
    }
}
