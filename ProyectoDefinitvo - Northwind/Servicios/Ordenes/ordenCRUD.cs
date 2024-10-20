using Microsoft.EntityFrameworkCore;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.Ordenes
{
    public interface IordenCRUD
    {
        bool ActualizarOrden(int orderId, string customerID, int employeeID, DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, int shipVia, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry);
        bool AgregarOrden(string customerID, int employeeID, DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, int shipVia, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry);
        bool EliminarOrden(int orderId);
    }

    public class ordenCRUD : IordenCRUD
    {
        NorthwindContext dtContext = new NorthwindContext();
        public bool AgregarOrden(string customerID, int employeeID, DateTime orderDate, DateTime requiredDate,
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar la orden: " + ex.Message);
                return false;
            }
        }
        public bool ActualizarOrden(int orderId, string customerID, int employeeID, DateTime orderDate, DateTime requiredDate,
                                  DateTime? shippedDate, int shipVia, decimal freight, string shipName, string shipAddress,
                                  string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            var orden = dtContext.Orders.FirstOrDefault(o => o.OrderId == orderId);

            if (orden == null)
            {
                return false;
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

            try
            {
                dtContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la orden: " + ex.Message);
                return false;
            }
        }

        public bool EliminarOrden(int orderId)
        {
            var orden = dtContext.Orders.FirstOrDefault(o => o.OrderId == orderId);

            if (orden == null)
            {
                return false;
            }

            dtContext.Orders.Remove(orden);

            try
            {
                dtContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la orden: " + ex.Message);
                return false;
            }
        }
    }
}
