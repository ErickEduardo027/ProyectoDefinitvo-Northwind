using Microsoft.EntityFrameworkCore;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Models;
using ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.Ordenes
{
    public interface IordenCRUD
    {
        List<dynamic> obtenerOrdenes();
        public int ActualizarOrden(int orderId, string customerID, int employeeID, DateTime orderDate, DateTime requiredDate,
                  DateTime? shippedDate, int shipVia, decimal freight, string shipName, string shipAddress,
                  string shipCity, string shipRegion, string shipPostalCode, string shipCountry,
                  List<OrderDetailViewModel> nuevosDetalles, List<OrderDetailViewModel> detallesEliminados);
        int AgregarOrden(string customerID, int employeeID, DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, int shipVia, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry);
        bool EliminarOrden(int orderId);
    }

    public class ordenCRUD : IordenCRUD
    {
        NorthwindContext dtContext = new NorthwindContext();

        public List<dynamic> obtenerOrdenes()
        {
            using (var dbContext = new NorthwindContext())
            {
                var ordenes = dbContext.Orders
                    .Select(o => new
                    {
                        Id = o.OrderId,
                        NombreDeLaEntrega = o.ShipName,
                        FechaDeLaOrden = o.OrderDate,
                        FechaDeEntrega = o.ShippedDate,
                        CostoDeTransporte = o.Freight,
                        DireccionDeLaEntrega = o.ShipAddress,
                        CiudadDeLaEntrega = o.ShipCity,
                        RegionDeLaEntrega = o.ShipRegion,
                        PaisDeLaEntrega = o.ShipCountry,
                        CodigoPostal = o.ShipPostalCode
                    })
                    .ToList<dynamic>();

                return ordenes;
            }
        }



        public int AgregarOrden(string customerID, int employeeID, DateTime orderDate, DateTime requiredDate,
                        DateTime? shippedDate, int shipVia, decimal freight, string shipName, string shipAddress,
                        string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            var orden = new Order
            {
                CustomerId = customerID,
                EmployeeId = employeeID,
                OrderDate = orderDate,
                RequiredDate = requiredDate,
                ShippedDate = shippedDate,
                ShipVia = shipVia,
                Freight = freight,
                ShipName = shipName,
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipRegion = shipRegion,
                ShipPostalCode = shipPostalCode,
                ShipCountry = shipCountry
            };

            dtContext.Orders.Add(orden);
            try
            {
                dtContext.SaveChanges();
                return orden.OrderId; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar la orden: " + ex.Message);
                return 0; 
            }
        }

        public int ActualizarOrden(int orderId, string customerID, int employeeID, DateTime orderDate, DateTime requiredDate,
                  DateTime? shippedDate, int shipVia, decimal freight, string shipName, string shipAddress,
                  string shipCity, string shipRegion, string shipPostalCode, string shipCountry,
                  List<OrderDetailViewModel> nuevosDetalles, List<OrderDetailViewModel> detallesEliminados)
        {
            using (var dbContext = new NorthwindContext())
            {
                var orden = dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);

                if (orden == null)
                {
                    return 0;
                }

                orden.CustomerId = customerID;
                orden.EmployeeId = employeeID;
                orden.OrderDate = orderDate;
                orden.RequiredDate = requiredDate;
                orden.ShippedDate = shippedDate;
                orden.ShipVia = shipVia;
                orden.Freight = freight;
                orden.ShipName = shipName;
                orden.ShipAddress = shipAddress;
                orden.ShipCity = shipCity;
                orden.ShipRegion = shipRegion;
                orden.ShipPostalCode = shipPostalCode;
                orden.ShipCountry = shipCountry;


                foreach (var detalleEliminado in detallesEliminados)
                {
                    var detalle = dbContext.OrderDetails
                        .FirstOrDefault(od => od.OrderId == detalleEliminado.OrderId && od.ProductId == detalleEliminado.ProductId);

                    if (detalle != null)
                    {
                        dbContext.OrderDetails.Remove(detalle);
                    }
                }


                foreach (var nuevoDetalle in nuevosDetalles)
                {
                    var detalleExistente = dbContext.OrderDetails
                        .FirstOrDefault(od => od.OrderId == nuevoDetalle.OrderId && od.ProductId == nuevoDetalle.ProductId);

                    if (detalleExistente != null)
                    {
                        detalleExistente.UnitPrice = nuevoDetalle.UnitPrice;
                        detalleExistente.Quantity = nuevoDetalle.Quantity;
                        detalleExistente.Discount = nuevoDetalle.Discount;
                    }
                    else
                    {
                        dbContext.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = nuevoDetalle.OrderId,
                            ProductId = nuevoDetalle.ProductId,
                            UnitPrice = nuevoDetalle.UnitPrice,
                            Quantity = nuevoDetalle.Quantity,
                            Discount = nuevoDetalle.Discount
                        });
                    }
                }

                try
                {
                    dbContext.SaveChanges();
                    return 1; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar la orden: " + ex.Message);
                    return -1; 
                }
            }
        }

        public bool EliminarOrden(int orderId)
        {
            using (var dbContext = new NorthwindContext())
            {

                var orden = dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);

                if (orden == null)
                {
                    Console.WriteLine($"La orden con ID {orderId} no existe.");
                    return false;
                }


                var detalles = dbContext.OrderDetails.Where(d => d.OrderId == orderId).ToList();

                if (detalles.Any())
                {
                    dbContext.OrderDetails.RemoveRange(detalles);
                }

                dbContext.Orders.Remove(orden);

                try
                {
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar la orden: {ex.Message}");
                    return false;
                }

            }

        }
    }
}
