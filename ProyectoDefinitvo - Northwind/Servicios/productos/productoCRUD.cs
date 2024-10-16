using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Models;
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
        List<Product> ObtenerProductos();
    }

    public class productoCRUD : IproductoCRUD
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");

        public List<Product> ObtenerProductos()
        {
            var dbcontext = new NorthwindContext();
            var productos = dbcontext.Products.ToList();
            return productos;

        }

        public bool AgregarProducto(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
                                    short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            var dbcontext = new NorthwindContext();
            var producto = new Product();
            dbcontext.Products.Add(producto);
            if (producto == null)
            {
                return false;
            }

            producto.ProductName = productName;
            producto.SupplierId = supplierID;
            producto.CategoryId = categoryID;
            producto.QuantityPerUnit = quantityPerUnit;
            producto.UnitPrice = unitPrice;
            producto.UnitsInStock = unitsInStock;
            producto.UnitsOnOrder = unitsOnOrder;
            producto.ReorderLevel = reorderLevel;
            producto.Discontinued = discontinued;

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

        public bool ActualizarProducto(int ProductID, string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice,
                               short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            var dbContext = new NorthwindContext();
            var product = dbContext.Products.FirstOrDefault(p => p.ProductId == ProductID);
            if (product == null)
            {
                return false;
            }

            product.ProductName = productName;
            product.SupplierId = supplierID;
            product.CategoryId = categoryID;
            product.QuantityPerUnit = quantityPerUnit;
            product.UnitPrice = unitPrice;
            product.UnitsInStock = unitsInStock;
            product.UnitsOnOrder = unitsOnOrder;
            product.ReorderLevel = reorderLevel;
            product.Discontinued = discontinued;

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

        public bool EliminarProducto(string productName)
        {
            var dbContext = new NorthwindContext();
            var product = dbContext.Products.FirstOrDefault(p => p.ProductName == productName);
            if (product == null)
            {
                return false;
            }

            dbContext.Products.Remove(product);

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
