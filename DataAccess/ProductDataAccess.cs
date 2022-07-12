using DesafioDotNet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesafioDotNet.DataAccess
{
    public class Product
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["desafiodotNet"].ConnectionString;

        private readonly string spGet = "SP_PRODUCT_GET";
        private readonly string spPost = "SP_PRODUCT_POST";
        private readonly string spPut = "SP_PRODUCT_PUT";
        private readonly string spDelete = "SP_PRODUCT_DELETE";

        public IEnumerable<ProductModel> GetAllProduct()
        {
            try
            {
                List<ProductModel> lstProduct = new List<ProductModel>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    DateTime data = DateTime.Now;
                    SqlCommand cmd = new SqlCommand(spGet, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ProductModel product = new ProductModel
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Name = rdr["NAME"].ToString(),
                            Price = Convert.ToDouble(rdr["PRICE"]),
                            Brand = rdr["BRAND"].ToString(),
                            CreatedAt = Convert.ToDateTime(rdr["createdAt"]),
                            UpdatedAt = (DateTime.TryParse(rdr["updatedAt"].ToString(), out data)) ? Convert.ToDateTime(rdr["updatedAt"]) : Convert.ToDateTime(rdr["createdAt"])
                        };


                        lstProduct.Add(product);
                    }
                    con.Close();
                }
                return lstProduct;
            }
            catch
            {
                throw;
            }
        }

        public bool AddProduct(RequestProduct product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(spPost, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@pName", product.Name);
                    cmd.Parameters.AddWithValue("@pPrice", product.Price);
                    cmd.Parameters.AddWithValue("@pBrand", product.Brand);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }

        public bool UpdateProduct(RequestProduct product, int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(spPut, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@pId", id);
                    cmd.Parameters.AddWithValue("@pName", product.Name);
                    cmd.Parameters.AddWithValue("@pPrice", product.Price);
                    cmd.Parameters.AddWithValue("@pBrand", product.Brand);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }

        public ProductModel GetProductData(int id)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    DateTime data = DateTime.Now;
                    SqlCommand cmd = new SqlCommand(spGet, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@pId", id);
                    ProductModel product = new ProductModel();

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        product.Id = Convert.ToInt32(rdr["ID"]);
                        product.Name = rdr["NAME"].ToString();
                        product.Price = Convert.ToDouble(rdr["PRICE"]);
                        product.Brand = rdr["BRAND"].ToString();
                        product.CreatedAt = Convert.ToDateTime(rdr["createdAt"]);
                        product.UpdatedAt = (DateTime.TryParse(rdr["updatedAt"].ToString(), out data)) ? Convert.ToDateTime(rdr["updatedAt"]) : Convert.ToDateTime(rdr["createdAt"]);

                    }
                    con.Close();
                    return product;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(spDelete, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@pId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }
    }
}