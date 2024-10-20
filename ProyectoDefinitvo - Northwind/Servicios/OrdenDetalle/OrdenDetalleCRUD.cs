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
        List<OrderDetailViewModel> ObtenerOrdenDetalle();
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

        public List<OrderDetailViewModel> ObtenerOrdenDetalle()
        {
            var dbContext = new NorthwindContext();
            var orderDetail = dbContext.OrderDetails.Include(x => x.Product)
                .Include(x => x.Product.Category)
                .Include(x => x.Product.Supplier)
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

                }).ToList();

            return orderDetail;

        }
    }
}
