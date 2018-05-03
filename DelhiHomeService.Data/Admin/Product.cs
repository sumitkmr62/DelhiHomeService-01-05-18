using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelhiHomeService.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DelhiHomeService.Data.Admin
{
    public class Product
    {
        //Connection Method
        public string GetConnection()
        {
            string str = ConfigurationManager.ConnectionStrings["DHSCS"].ConnectionString;
            return str;
        }

        public List<DelhiHomeService.Models.Product> GetProduct()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("getproducts", con);
                da.Fill(dt);

                List<DelhiHomeService.Models.Product> product = new List<DelhiHomeService.Models.Product>();
                foreach (DataRow dr in dt.Rows)
                {
                    product.Add(
                        new Models.Product
                        {
                            ProductID = Convert.ToInt32(dr["product_id"]),
                            ProductName = dr["product_name"].ToString(),
                            ProductDescription = dr["product_description"].ToString(),
                            ProductImage = dr["product_image"].ToString()
                        }
                        );
                }
                return product;

            }
        }
    }
}
