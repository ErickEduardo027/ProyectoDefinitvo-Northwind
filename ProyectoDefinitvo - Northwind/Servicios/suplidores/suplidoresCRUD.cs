using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.Extensions.Configuration;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Models;
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
        List<Supplier> ObtenerSuplidores();
    }

    public class suplidoresCRUD : IsuplidoresCRUD
    {

        public List<Supplier> ObtenerSuplidores()
        {
            var dbContext = new NorthwindContext();
            var suplidores = dbContext.Suppliers.ToList();
            return suplidores;
        }

        public bool AgregarSuplidor(string companyName, string contactName, string contactTitle, string address, string city, string region,
                             string postalCode, string country, string phone, string fax, string homePage)
        {
            var dbcontext = new NorthwindContext();
            var suplidor = new Supplier();
            dbcontext.Suppliers.Add(suplidor);
            if (suplidor == null)
            { 
                return false;
            }

            suplidor.CompanyName = companyName;
            suplidor.ContactName = contactName;
            suplidor.ContactTitle = contactTitle;
            suplidor.Address = address;
            suplidor.City = city;
            suplidor.Region = region;
            suplidor.PostalCode = postalCode;
            suplidor.Country = country;
            suplidor.Phone = phone;
            suplidor.Fax = fax;
            suplidor.HomePage = homePage;

            try
            {
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarSuplidor(int supplierID, string companyName, string contactName, string contactTitle, string address, string city, string region,
                                string postalCode, string country, string phone, string fax, string homePage)
        {
            var dbContext = new NorthwindContext();
            var suplidor = dbContext.Suppliers.FirstOrDefault(p => p.SupplierId == supplierID);
            if (suplidor == null)
            {
                return false;
            }

            suplidor.CompanyName = companyName;
            suplidor.ContactName = contactName;
            suplidor.ContactTitle = contactTitle;
            suplidor.Address = address;
            suplidor.City = city;
            suplidor.Region = region;
            suplidor.PostalCode = postalCode;
            suplidor.Country = country;
            suplidor.Phone = phone;
            suplidor.Fax = fax;
            suplidor.HomePage = homePage;

            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool EliminarSuplidor(int supplierID)
        {
            var dbContext = new NorthwindContext();
            var suplidores = dbContext.Suppliers.FirstOrDefault(p => p.SupplierId == supplierID);
            if (suplidores == null)
            {
                return false;
            }

            dbContext.Suppliers.Remove(suplidores);

            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
