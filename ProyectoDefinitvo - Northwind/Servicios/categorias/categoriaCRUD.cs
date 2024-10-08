using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.categorias
{
    public class categoriaCRUD
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");

        public DataTable ObtenerCategorias()
        {
            string query = "SELECT CategoryID, CategoryName, Description, Picture FROM Categories";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable categorias = new DataTable();
                dataAdapter.Fill(categorias);
                return categorias;
            }
        }

        public bool AgregarCategoria(string categoryName, string description, byte[] picture)
        {
            string query = "INSERT INTO Categories (CategoryName, Description, Picture) VALUES (@CategoryName, @Description, @Picture)";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Picture", picture);  

                try
                {
                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool ActualizarCategoria(int categoryID, string categoryName, string description, byte[] picture)
        {
            string query = "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description, Picture = @Picture WHERE CategoryID = @CategoryID";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Picture", picture);  // Asegúrate de que sea de tipo byte[]

                try
                {
                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool EliminarCategoria(int categoryID)
        {
            string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                try
                {
                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
