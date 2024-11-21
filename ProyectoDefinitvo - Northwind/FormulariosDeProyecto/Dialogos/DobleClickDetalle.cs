using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{

    public partial class DobleClickDetalle : Form

    {
        public DobleClickDetalle()
        {
            InitializeComponent();
        }
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarOrdenPorId(int orderId)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {

                SqlCommand cmdOrden = conexion.CreateCommand();
                cmdOrden.CommandText = "SELECT * FROM Orders WHERE OrderID = @OrderID";
                cmdOrden.Parameters.AddWithValue("@OrderID", orderId);


                SqlCommand cmdDetalles = conexion.CreateCommand();
                cmdDetalles.CommandText = @"
            SELECT 
                p.ProductName AS [Nombre del producto],
                od.UnitPrice AS [Precio por unidad],
                od.Quantity AS [Cantidad del producto],
                od.Discount AS [Descuento],
                c.CategoryName AS [Categoría del producto],
                s.CompanyName AS [Proveedor del producto],
                (od.UnitPrice * od.Quantity * (1 - od.Discount)) AS [Extended Price]
            FROM [Order Details] od
            INNER JOIN Products p ON od.ProductID = p.ProductID
            INNER JOIN Categories c ON p.CategoryID = c.CategoryID
            INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
            WHERE od.OrderID = @OrderID";
                cmdDetalles.Parameters.AddWithValue("@OrderID", orderId);

                conexion.Open();


                SqlDataReader readerDetalles = cmdDetalles.ExecuteReader();
                dataGridView2.Rows.Clear();
                while (readerDetalles.Read())
                {
                    dataGridView2.Rows.Add(
                        readerDetalles["Nombre del producto"],
                        readerDetalles["Precio por unidad"],
                        readerDetalles["Cantidad del producto"],
                        Convert.ToDecimal(readerDetalles["Descuento"]) * 100,
                        readerDetalles["Categoría del producto"],
                        readerDetalles["Proveedor del producto"],
                        readerDetalles["Extended Price"]
                    );
                }
                readerDetalles.Close();

                conexion.Close();
            }
        }

        private void DobleClickDetalle_Load(object sender, EventArgs e)
        {
            int orderID = int.Parse(this.Tag.ToString());
            CargarOrdenPorId(orderID);
        }
    }
}
