using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.suplidores
{
    public interface IsuplidoresCRUD
    {
        bool ActualizarSuplidor(int supplierID, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage);
        bool AgregarSuplidor(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage);
        bool EliminarSuplidor(int supplierID);
        DataTable ObtenerSuplidores();
    }

    public class suplidoresCRUD : IsuplidoresCRUD
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");

        public DataTable ObtenerSuplidores()
        {
            string query = "SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage FROM Suppliers";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable proveedores = new DataTable();
                dataAdapter.Fill(proveedores);
                return proveedores;
            }
        }

        public bool AgregarSuplidor(string companyName, string contactName, string contactTitle, string address, string city, string region,
                             string postalCode, string country, string phone, string fax, string homePage)
        {
            string query = "INSERT INTO Suppliers (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage) " +
                           "VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax, @HomePage)";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CompanyName", companyName);
                cmd.Parameters.AddWithValue("@ContactName", contactName);
                cmd.Parameters.AddWithValue("@ContactTitle", contactTitle);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Region", region);
                cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Fax", fax);
                cmd.Parameters.AddWithValue("@HomePage", homePage);

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

        public bool ActualizarSuplidor(int supplierID, string companyName, string contactName, string contactTitle, string address, string city, string region,
                                string postalCode, string country, string phone, string fax, string homePage)
        {
            string query = "UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, " +
                           "PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax, HomePage = @HomePage WHERE SupplierID = @SupplierID";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                cmd.Parameters.AddWithValue("@CompanyName", companyName);
                cmd.Parameters.AddWithValue("@ContactName", contactName);
                cmd.Parameters.AddWithValue("@ContactTitle", contactTitle);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Region", region);
                cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Fax", fax);
                cmd.Parameters.AddWithValue("@HomePage", homePage);

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

        public bool EliminarSuplidor(int supplierID)
        {
            string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);

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
