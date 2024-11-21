using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle;
using ProyectoDefinitvo___Northwind.Servicios.Ordenes;
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public partial class ActualizarOrdenDialog : Form
    {
        private Dictionary<string, List<string>> paisesCiudades = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> ciudadesRegiones = new Dictionary<string, List<string>>();
        private readonly IordenService iordenService;
        private readonly IordenCRUD iordenCRUD;
        private readonly IOrdenDetalleCRUD iordenDetalleCRUD;
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");

        public ActualizarOrdenDialog(IordenService iordenService, IordenCRUD iordenCRUD, IOrdenDetalleCRUD iordenDetalleCRUD)
        {
            InitializeComponent();
            CargarDatosComboBox();
            InicializarDatos();
            this.iordenService = iordenService;
            this.iordenCRUD = iordenCRUD;
            this.iordenDetalleCRUD = iordenDetalleCRUD;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarOrden_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Está seguro que desea actualizar la orden?",
                                                "Confirmar actualización de orden",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {

                var cliente = textBoxClienteID.Text;
                var empleado = int.Parse(textBoxEmpleadoID.Text);
                int shipper = int.Parse(textBoxShipperID.Text);
                decimal costoDeTransporte = decimal.Parse(textBoxCostoTransporte.Text);
                var id = Int32.Parse(textBox5.Text);
                var fechaActual = dateTimePicker1.Value;
                var fechaDeLaOrden = dateTimePicker3.Value;
                var fechaDeLaEntrega = dateTimePicker4.Value;
                var direccionDeLaEntrega = textBox2.Text;
                var nombreDeLaEntrega = textBox3.Text;
                var paisDeLaEntrega = cbxPais.Text;
                var ciudadDeLaEntrega = cbxCiudad.Text;
                var region = textBox16.Text;
                var codigoPostal = textBox4.Text;


                List<OrderDetailViewModel> nuevosDetalles = new List<OrderDetailViewModel>();
                List<OrderDetailViewModel> detallesEliminados = new List<OrderDetailViewModel>();


                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["ProductName"].Value == null ||
                        row.Cells["UnitPrice"].Value == null ||
                        row.Cells["Quantity"].Value == null ||
                        row.Cells["Discount"].Value == null)
                    {
                        continue;
                    }

                    var nombreProducto = row.Cells["ProductName"].Value.ToString();
                    var precioPorUnidad = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                    var cantidad = (short)Convert.ToInt32(row.Cells["Quantity"].Value);
                    var descuento = (float)Convert.ToDecimal(row.Cells["Discount"].Value) / 100;

                    using (var context = new NorthwindContext())
                    {
                        var productoId = context.Products
                                                 .Where(p => p.ProductName == nombreProducto)
                                                 .Select(p => p.ProductId)
                                                 .FirstOrDefault();

                        if (productoId == 0)
                        {
                            MessageBox.Show($"No se encontró el ID para el producto: {nombreProducto}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        nuevosDetalles.Add(new OrderDetailViewModel
                        {
                            OrderId = id,
                            ProductId = productoId,
                            UnitPrice = precioPorUnidad,
                            Quantity = cantidad,
                            Discount = descuento
                        });
                    }
                }

                int resultado = iordenCRUD.ActualizarOrden(id, cliente, empleado, fechaActual, fechaDeLaOrden, fechaDeLaEntrega, shipper,
                                                           costoDeTransporte, nombreDeLaEntrega, direccionDeLaEntrega, ciudadDeLaEntrega,
                                                           region, codigoPostal, paisDeLaEntrega, nuevosDetalles, detallesEliminados);

                if (resultado == 1)
                {
                    MessageBox.Show("La orden y sus detalles se actualizaron con éxito.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (resultado == 0)
                {
                    MessageBox.Show("No se encontró la orden para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La actualización de la orden ha sido cancelada.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void ActualizarOrdenDialog_Load(object sender, EventArgs e)
        {
            int orderID = int.Parse(this.Tag.ToString());
            CargarOrdenPorId(orderID);
            ActualizarResumen();
            using (var context = new NorthwindContext())
            {
                var productos = context.Products
                                       .Select(p => new { p.ProductId, p.ProductName, p.UnitPrice })
                                       .ToList();

                cbxProducto.DataSource = productos;
                cbxProducto.DisplayMember = "ProductName";
                cbxProducto.ValueMember = "UnitPrice";
            }
            cbxProducto.SelectedIndex = -1;
            textBoxID.Text = "";
            textBoxPrecio.Text = "";
        }

        private void InicializarDatos()
        {
            paisesCiudades.Add("Argentina", new List<string> { "Buenos Aires", "Córdoba", "Rosario", "Mendoza", "La Plata", "San Miguel", "Salta", "Santa Fe", "San Juan", "Resistencia" });
            paisesCiudades.Add("Brasil", new List<string> { "São Paulo", "Río de Janeiro", "Brasilia", "Salvador", "Fortaleza", "Belo Horizonte", "Manaos", "Curitiba", "Recife", "Porto Alegre" });
            paisesCiudades.Add("Canadá", new List<string> { "Toronto", "Montreal", "Vancouver", "Calgary", "Edmonton", "Ottawa", "Quebec", "Winnipeg", "Hamilton", "Victoria" });
            paisesCiudades.Add("Chile", new List<string> { "Santiago", "Valparaíso", "Concepción", "La Serena", "Antofagasta", "Temuco", "Rancagua", "Talca", "Arica", "Puerto Montt" });
            paisesCiudades.Add("Colombia", new List<string> { "Bogotá", "Medellín", "Cali", "Barranquilla", "Cartagena", "Cúcuta", "Bucaramanga", "Soacha", "Pereira", "Ibagué" });
            paisesCiudades.Add("México", new List<string> { "Ciudad de México", "Guadalajara", "Monterrey", "Puebla", "Tijuana", "Toluca", "León", "Ciudad Juárez", "Cancún", "Querétaro" });
            paisesCiudades.Add("Estados Unidos", new List<string> { "Nueva York", "Los Ángeles", "Chicago", "Houston", "Phoenix", "Filadelfia", "San Antonio", "San Diego", "Dallas", "San José" });
            paisesCiudades.Add("Perú", new List<string> { "Lima", "Arequipa", "Trujillo", "Chiclayo", "Piura", "Iquitos", "Cusco", "Huancayo", "Tacna", "Ayacucho" });
            paisesCiudades.Add("República Dominicana", new List<string> { "Santo Domingo", "Santiago", "La Vega", "San Cristóbal", "Puerto Plata", "La Romana", "San Pedro de Macorís", "Higüey", "Moca", "Bonao" });
            paisesCiudades.Add("Venezuela", new List<string> { "Caracas", "Maracaibo", "Valencia", "Barquisimeto", "Maracay", "Ciudad Guayana", "Barcelona", "Maturín", "Cumaná", "San Cristóbal" });

            cbxPais.DataSource = new BindingSource(paisesCiudades.Keys.ToList(), null);
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


                SqlDataReader readerOrden = cmdOrden.ExecuteReader();
                if (readerOrden.Read())
                {
                    textBoxClienteID.Text = readerOrden["CustomerID"].ToString();
                    textBoxEmpleadoID.Text = readerOrden["EmployeeID"].ToString();
                    textBoxShipperID.Text = readerOrden["ShipVia"].ToString();
                    textBox1.Text = readerOrden["Freight"].ToString();
                    textBoxCostoTransporte.Text = readerOrden["Freight"].ToString();
                    textBox5.Text = readerOrden["OrderID"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(readerOrden["OrderDate"]);
                    dateTimePicker3.Value = Convert.ToDateTime(readerOrden["RequiredDate"]);
                    dateTimePicker4.Value = readerOrden["ShippedDate"] != DBNull.Value
                        ? Convert.ToDateTime(readerOrden["ShippedDate"])
                        : DateTime.Now;
                    textBox2.Text = readerOrden["ShipAddress"].ToString();
                    textBox3.Text = readerOrden["ShipName"].ToString();
                    cbxPais.Text = readerOrden["ShipCountry"].ToString();
                    cbxCiudad.Text = readerOrden["ShipCity"].ToString();
                    textBox16.Text = readerOrden["ShipRegion"].ToString();
                    textBox4.Text = readerOrden["ShipPostalCode"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró la orden con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conexion.Close();
                    return;
                }
                readerOrden.Close();


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

        private void CargarDatosComboBox()
        {
            var dbcontext = new NorthwindContext();

            var clientes = dbcontext.Customers.Select(c => new { c.CustomerId, c.CompanyName }).ToList();
            comboBoxClientes.DataSource = clientes;
            comboBoxClientes.DisplayMember = "CompanyName";
            comboBoxClientes.ValueMember = "CustomerId";


            var empleados = dbcontext.Employees.Select(e => new { e.EmployeeId, FullName = e.FirstName + " " + e.LastName }).ToList();
            comboBoxEmpleados.DataSource = empleados;
            comboBoxEmpleados.DisplayMember = "FullName";
            comboBoxEmpleados.ValueMember = "EmployeeId";


            var shippers = dbcontext.Shippers.Select(s => new { s.ShipperId, s.CompanyName }).ToList();
            comboBoxShippers.DataSource = shippers;
            comboBoxShippers.DisplayMember = "CompanyName";
            comboBoxShippers.ValueMember = "ShipperId";

        }

        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClientes.SelectedValue != null)
            {
                textBoxClienteID.Text = comboBoxClientes.SelectedValue.ToString();
            }
        }

        private void comboBoxEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEmpleados.SelectedValue != null)
            {
                textBoxEmpleadoID.Text = comboBoxEmpleados.SelectedValue.ToString();
            }
        }

        private void comboBoxShippers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShippers.SelectedValue != null)
            {
                textBoxShipperID.Text = comboBoxShippers.SelectedValue.ToString();
            }
        }

        private void cbxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            string paisSeleccionado = cbxPais.SelectedItem.ToString();
            cbxCiudad.Enabled = true;
            cbxCiudad.DataSource = paisesCiudades[paisSeleccionado];
        }

        private void cbxCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ciudadSeleccionada = cbxCiudad.SelectedItem.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedValue != null)
            {
                int productoId = int.Parse(textBoxID.Text);

                int cantidad = (int)numericUpDown1.Value;
                decimal descuento = string.IsNullOrWhiteSpace(textBox15.Text) ? 0 : decimal.Parse(textBox15.Text) / 100;

                using (var context = new NorthwindContext())
                {

                    var producto = context.Products
                                          .Where(p => p.ProductId == productoId)
                                          .Select(p => new
                                          {
                                              p.ProductName,
                                              p.UnitPrice,
                                              p.CategoryId,
                                              p.SupplierId
                                          })
                                          .FirstOrDefault();

                    if (producto != null)
                    {

                        MessageBox.Show("Producto agregado al detalle con exito", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxProducto.SelectedIndex = -1;
                        textBoxID.Text = "";
                        textBox15.Text = "";
                        textBoxPrecio.Text = "";
                        numericUpDown1.Value = 0;


                        var categoria = context.Categories
                                               .Where(c => c.CategoryId == producto.CategoryId)
                                               .Select(c => c.CategoryName)
                                               .FirstOrDefault();

                        var proveedor = context.Suppliers
                                               .Where(p => p.SupplierId == producto.SupplierId)
                                               .Select(p => p.CompanyName)
                                               .FirstOrDefault();

                        SqlMoney precioPorUnidad = producto.UnitPrice ?? 0;
                        SqlMoney precioExtendido = (precioPorUnidad * cantidad) * (1 - descuento);

                        dataGridView2.Rows.Add(
                            producto.ProductName,
                            precioPorUnidad.ToString(),
                            cantidad,
                            (descuento * 100).ToString(),
                            categoria,
                            proveedor,
                            precioExtendido.ToString()
                        );

                        ActualizarResumen();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el producto en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumen()
        {

            if (dataGridView2.Rows.Count > 0)
            {
                var detallesOrden = dataGridView2.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => row.Cells["UnitPrice"].Value != null && row.Cells["Quantity"].Value != null && row.Cells["Discount"].Value != null); // Filtrar filas válidas

                var promedioUnitPrice = detallesOrden
                    .Average(row => Convert.ToDecimal(row.Cells["UnitPrice"].Value));
                label29.Text = promedioUnitPrice.ToString("F2");

                var sumaCantidad = detallesOrden
                    .Sum(row => Convert.ToInt32(row.Cells["Quantity"].Value));
                label32.Text = sumaCantidad.ToString();

                var promedioDescuento = detallesOrden
                    .Average(row => Convert.ToSingle(row.Cells["Discount"].Value));
                label36.Text = promedioDescuento.ToString();


                var subtotal = detallesOrden
      .Sum(row => Convert.ToDecimal(row.Cells["ExtendedPrice"].Value));
                textBoxSubtotal.Text = subtotal.ToString("F2");

                var total = subtotal + decimal.Parse(textBoxCostoTransporte.Text);
                textBoxTotal.Text = total.ToString("F2");
            }
            else
            {

                label29.Text = "0";
                label32.Text = "0";
                label36.Text = "0";
                textBoxSubtotal.Text = "0.00";
                textBoxCostoTransporte.Text = "0";
                textBoxTotal.Text = "0.00";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este detalle?",
                                                      "Confirmar eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (int.TryParse(textBox5.Text, out int orderId))
                    {
                        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                        {
                            if (row.Cells["ProductName"].Value != null)
                            {
                                string productName = row.Cells["ProductName"].Value.ToString();

                                int productId;
                                using (var context = new NorthwindContext())
                                {
                                    productId = context.Products
                                        .Where(p => p.ProductName == productName)
                                        .Select(p => p.ProductId)
                                        .FirstOrDefault();
                                }

                                if (productId > 0)
                                {
                                    bool eliminado = iordenDetalleCRUD.EliminarOrdenDetalle(orderId, productId);

                                    if (eliminado)
                                    {
                                        dataGridView2.Rows.Remove(row);
                                        ActualizarResumen();
                                    }
                                    else
                                    {
                                        MessageBox.Show($"No se pudo eliminar el detalle para la orden con ID {orderId} y producto {productName}.",
                                                        "Error al eliminar",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"No se encontró el ID para el producto: {productName}",
                                                    "Error",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La fila seleccionada no contiene un nombre de producto válido.",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ID de la orden no es válido.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedItem != null)
            {
                var productoSeleccionado = (dynamic)cbxProducto.SelectedItem;

                textBoxID.Text = productoSeleccionado.ProductId.ToString();
                textBoxPrecio.Text = productoSeleccionado.UnitPrice.ToString("C");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedValue != null)
            {
                int productoId = int.Parse(textBoxID.Text);

                int cantidad = (int)numericUpDown1.Value;
                decimal descuento = string.IsNullOrWhiteSpace(textBox15.Text) ? 0 : decimal.Parse(textBox15.Text) / 100;

                using (var context = new NorthwindContext())
                {

                    var producto = context.Products
                                          .Where(p => p.ProductId == productoId)
                                          .Select(p => new
                                          {
                                              p.ProductName,
                                              p.UnitPrice,
                                              p.CategoryId,
                                              p.SupplierId
                                          })
                                          .FirstOrDefault();

                    if (producto != null)
                    {

                        MessageBox.Show("Producto agregado al detalle con exito", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxProducto.SelectedIndex = -1;
                        textBoxID.Text = "";
                        textBox15.Text = "";
                        textBoxPrecio.Text = "";
                        numericUpDown1.Value = 0;


                        var categoria = context.Categories
                                               .Where(c => c.CategoryId == producto.CategoryId)
                                               .Select(c => c.CategoryName)
                                               .FirstOrDefault();

                        var proveedor = context.Suppliers
                                               .Where(p => p.SupplierId == producto.SupplierId)
                                               .Select(p => p.CompanyName)
                                               .FirstOrDefault();

                        SqlMoney precioPorUnidad = producto.UnitPrice ?? 0;
                        SqlMoney precioExtendido = (precioPorUnidad * cantidad) * (1 - descuento);

                        dataGridView2.Rows.Add(
                            producto.ProductName,
                            precioPorUnidad.ToString(),
                            cantidad,
                            (descuento * 100).ToString(),
                            categoria,
                            proveedor,
                            precioExtendido.ToString()
                        );

                        ActualizarResumen();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el producto en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
