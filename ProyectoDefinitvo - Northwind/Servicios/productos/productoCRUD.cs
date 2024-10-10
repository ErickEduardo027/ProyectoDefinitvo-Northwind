using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.productos
{
    public interface IproductoCRUD
    {
        bool ActualizarProducto(int ProductID, string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued);
        bool AgregarProducto(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued);
        bool EliminarProducto(string productName);
        DataTable ObtenerProductos();
    }

    public class productoCRUD : IproductoCRUD
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");

        public DataTable ObtenerProductos()
        {
            string query = "SELECT * FROM Products";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter datatable = new SqlDataAdapter(cmd);
                DataTable productos = new DataTable();
                datatable.Fill(productos);
                return productos;
            }
        }

        public bool AgregarProducto(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
                                    short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            string query = "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                           "VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
                cmd.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
                cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                cmd.Parameters.AddWithValue("@Discontinued", discontinued);

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

        public bool ActualizarProducto(int ProductID, string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
                               short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            string query = "UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, " +
                           "UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued " +
                           "WHERE ProductID = @ProductID";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
                cmd.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
                cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                cmd.Parameters.AddWithValue("@Discontinued", discontinued);

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

        public bool EliminarProducto(string productName)
        {
            string query = "DELETE FROM Products WHERE ProductName = @ProductName";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductName", productName);

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
