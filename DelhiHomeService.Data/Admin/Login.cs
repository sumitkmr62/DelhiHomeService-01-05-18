using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DelhiHomeService.Models.Admin;

namespace DelhiHomeService.Data.Admin
{
    public class Login
    {
        //Connection Method
        public string GetConnection()
        {
            string str = ConfigurationManager.ConnectionStrings["DHSCS"].ConnectionString;        
            return str;
        }

        //Method for admin to login
        public bool AdminLogin(string username,string password)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("admin_login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("admin_username", username);
                cmd.Parameters.AddWithValue("admin_password", password);

                con.Open();

                var reader= cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
                
        }
    }
}
