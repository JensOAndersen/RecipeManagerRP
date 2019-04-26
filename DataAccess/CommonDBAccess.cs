using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CommonDBAccess
    {
        private const string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipeRP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        protected DataTable ExecuteQuery(string q)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter dap = new SqlDataAdapter(q,ConString))
            {
                dap.Fill(dt);
            }

            return dt;
        }

        protected int ExecuteNonQuery(string q)
        {
            using(SqlConnection con = new SqlConnection(ConString))
            using(SqlCommand com = new SqlCommand(q, con))
            {
                con.Open();

                return com.ExecuteNonQuery();
            }
        }
    }
}
