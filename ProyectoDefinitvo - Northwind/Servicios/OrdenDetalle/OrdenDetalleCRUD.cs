using Microsoft.EntityFrameworkCore;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoDefinitvo___Northwind.FormulariosDeProyecto.OrdenesForm;

namespace ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle
{
    public interface IOrdenDetalleCRUD
    {
        List<OrderDetailViewModel> ObtenerOrdenDetalle(int orderId);
        bool AgregarOrdenDetalle(int orderId, int productId, decimal unitPrice, short quantity, float discount);
        bool EliminarOrdenDetalle(int orderId, int productId);
    }

    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public string ProductName { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public decimal ExtendedPrice { get; set; }
    }


    public class OrdenDetalleCRUD : IOrdenDetalleCRUD
    {

        public List<OrderDetailViewModel> ObtenerOrdenDetalle(int orderId)
        {
            var dbContext = new NorthwindContext();

          
            var orderDetail = dbContext.OrderDetails
                .Include(x => x.Product)
                .Include(x => x.Product.Category)
                .Include(x => x.Product.Supplier)
                .Where(x => x.OrderId == orderId) 
                .Select(x => new OrderDetailViewModel()
                {
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity,
                    Discount = x.Discount,
                    ProductName = x.Product.ProductName,
                    CategoryName = x.Product.Category.CategoryName,
                    CompanyName = x.Product.Supplier.CompanyName,
                    ExtendedPrice = (decimal)((x.Quantity * float.Parse(x.UnitPrice.ToString())) - (x.Quantity * float.Parse(x.UnitPrice.ToString())) * x.Discount),
                })
                .ToList();

            return orderDetail;
        }



        public bool AgregarOrdenDetalle(int orderId, int productId, decimal unitPrice, short quantity, float discount)
        {
            try
            {
                using (var dbContext = new NorthwindContext())
                {
                    var nuevoDetalle = new OrderDetail
                    {
                        OrderId = orderId,
                        ProductId = productId,
                        UnitPrice = unitPrice,
                        Quantity = quantity,
                        Discount = discount
                    };

                    dbContext.OrderDetails.Add(nuevoDetalle);
                    dbContext.SaveChanges(); 
                }

                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el detalle de la orden: {ex.Message}");
                return false;
            }
        }

   
        public bool EliminarOrdenDetalle(int orderId, int productId)
        {
            try
            {
                using (var dbContext = new NorthwindContext())
                {
                    var detalleEliminar = dbContext.OrderDetails
                        .FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);

                    if (detalleEliminar != null)
                    {
                        dbContext.OrderDetails.Remove(detalleEliminar);
                        dbContext.SaveChanges(); 
                        return true; 
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró un detalle de la orden con OrderId = {orderId} y ProductId = {productId}");
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el detalle de la orden: {ex.Message}");
                return false; 
            }
        }
    }
}

