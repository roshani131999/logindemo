using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace logindemo.Models
{
    public class registeropertation
    {
        string connectionString = "Data Source=DMANTRA5106\\MANTRA2005;Initial Catalog=User;Integrated Security=True";

        public int logcheck(register reg)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", reg.Username);
                cmd.Parameters.AddWithValue("@Password", reg.Password);
                SqlParameter oblogin = new SqlParameter();
                oblogin.ParameterName = "@Isvalid";
                oblogin.SqlDbType = SqlDbType.Bit;
                oblogin.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oblogin);
                con.Open();
                int res = Convert.ToInt32(oblogin.Value);
                con.Close();
                return res;

            }
        }
    }
}
