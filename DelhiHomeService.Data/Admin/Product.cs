using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DelhiHomeService.Models;

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

        public bool AddProduct(DelhiHomeService.Models.Product product)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("addproduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("product_name", product.ProductName);
                cmd.Parameters.AddWithValue("product_description", product.ProductDescription);
                cmd.Parameters.AddWithValue("product_image", product.ProductImage);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
