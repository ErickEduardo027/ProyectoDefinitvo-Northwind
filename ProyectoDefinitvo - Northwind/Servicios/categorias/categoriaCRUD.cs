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

namespace ProyectoDefinitvo___Northwind.Servicios.categorias
{
    public interface IcategoriaCRUD
    {
        bool ActualizarCategoria(int categoryID, string categoryName, string description, byte[] picture);
        bool AgregarCategoria(string categoryName, string description, byte[] pictureData);
        bool EliminarCategoria(int categoryID);
        List<Category> ObtenerCategorias();
    }

    public class categoriaCRUD : IcategoriaCRUD
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");

        public List<Category> ObtenerCategorias()
        {
            var dbContext = new NorthwindContext();
            var Categoria = dbContext.Categories.ToList();
            return Categoria;

        }

        public bool AgregarCategoria(string categoryName, string description, byte[] pictureData)
        {

            var dbContext = new NorthwindContext();
            var categoria = new Category();
            dbContext.Categories.Add(categoria);

            if (categoria == null)
            {
                return false;
            }

            categoria.CategoryName = categoryName;
            categoria.Description = description;
            categoria.Picture = pictureData;

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

        public bool ActualizarCategoria(int categoryID, string categoryName, string description, byte[] picture)
        {

            var dbcontext = new NorthwindContext();
            var Categoria = new Category();
            dbcontext.Categories.FirstOrDefault(p => p.CategoryId == categoryID);
            if (Categoria == null)
            {
                return false;
            }

            Categoria.CategoryName = categoryName;
            Categoria.Description = description;
            Categoria.Picture = picture;

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

        public bool EliminarCategoria(int categoryID)
        {
            var dbContext = new NorthwindContext();
            var categoria = dbContext.Categories.FirstOrDefault(p => p.CategoryId == categoryID);
            if (categoria == null)
            {
                return false;
            }

            dbContext.Categories.Remove(categoria);

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
