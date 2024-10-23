using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.Models;
using ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle;
using ProyectoDefinitvo___Northwind.Servicios.Ordenes;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoDefinitvo___Northwind.Servicios.Ordenes.ordenService;
using static ProyectoDefinitvo___Northwind.Servicios.productos.productosService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public partial class AgregarOrdenDialog : Form
    {
        private Dictionary<string, List<string>> paisesCiudades = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> ciudadesRegiones = new Dictionary<string, List<string>>();
        private readonly IordenService iordenService;
        private readonly IordenCRUD iordenCRUD;
        private readonly IOrdenDetalleCRUD iordenDetalleCRUD;

        public AgregarOrdenDialog(IordenService iordenService, IordenCRUD iordenCRUD, IOrdenDetalleCRUD iordenDetalleCRUD)
        {
            InitializeComponent();
            CargarDatosComboBox();
            this.iordenService = iordenService;
            this.iordenCRUD = iordenCRUD;
            this.iordenDetalleCRUD = iordenDetalleCRUD;
            InicializarDatos();
        }

        private void AgregarOrdenDialog_Load(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            panel5.Enabled = false;
            comboBoxClientes.Text = string.Empty;
            comboBoxEmpleados.Text = string.Empty;
            comboBoxShippers.Text = string.Empty;
            textBoxClienteID.Text = "";
            textBoxEmpleadoID.Text = "";
            textBoxShipperID.Text = "";
            cbxCiudad.Text = string.Empty;
            cbxPais.Text = string.Empty;
            textBox1.Text = "0";
            btnReset.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {

            var cliente = textBoxClienteID.Text;
            var empleado = int.Parse(textBoxEmpleadoID.Text);
            int shipper = int.Parse(textBoxShipperID.Text);
            int costoDeTransporte;


            if (!int.TryParse(textBox1.Text, out costoDeTransporte))
            {
                MessageBox.Show("NO PONGAS LETRAS, AQUI SOLO VA EL PRECIO. DESCANSA!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fechaActual = dateTimePicker1.Value;
            var fechaDeLaOrden = dateTimePicker3.Value;
            var fechaDeLaEntrega = dateTimePicker4.Value;
            var direccionDeLaEntrega = textBox2.Text;
            var nombreDeLaEntrega = textBox3.Text;
            var paisDeLaEntrega = cbxPais.Text;
            var ciudadDeLaEntrega = cbxCiudad.Text;
            var region = textBox16.Text;
            var codigoPostal = textBox4.Text;


            try
            {
                this.iordenService.CrearOrden(new CrearOrdenRequest
                {
                    CustomerID = cliente,
                    EmployeeID = empleado,
                    ShipVia = shipper,
                    OrderDate = fechaDeLaOrden,
                    RequiredDate = fechaActual,
                    ShippedDate = fechaDeLaEntrega,
                    Freight = costoDeTransporte,
                    ShipName = nombreDeLaEntrega,
                    ShipAddress = direccionDeLaEntrega,
                    ShipCity = ciudadDeLaEntrega,
                    ShipRegion = region,
                    ShipPostalCode = codigoPostal,
                    ShipCountry = paisDeLaEntrega
                });

                empleado = int.Parse(textBoxEmpleadoID.Text);


                if (iordenCRUD.AgregarOrden(cliente, empleado, fechaActual, fechaDeLaOrden, fechaDeLaEntrega, shipper, costoDeTransporte, nombreDeLaEntrega, direccionDeLaEntrega, ciudadDeLaEntrega, region, codigoPostal, paisDeLaEntrega))
                {
                    MessageBox.Show("Nueva orden ingresada con éxito", "Agregar orden", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    panel3.Enabled = true;
                    panel5.Enabled = true;
                    panel1.Enabled = false;

                    textBoxClienteID.Text = "";
                    textBoxEmpleadoID.Text = "";
                    textBoxShipperID.Text = "";
                    textBox1.Text = "0";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    cbxPais.Text = " ";
                    cbxCiudad.Text = " ";
                    textBox16.Text = "";
                    textBox4.Text = "";



                    var dbcontext = new NorthwindContext();
                    var ultimaOrden = dbcontext.Orders
                        .OrderByDescending(o => o.OrderId)
                        .FirstOrDefault();

                    textBox17.Text = ultimaOrden.OrderId.ToString();

                    dataGridView1.DataSource = dbcontext.Products.ToList();

                }
                else
                {
                    MessageBox.Show("Error al agregar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException ex)
            {
                var message = ex.Message;
                MessageBox.Show(message, "Validación de errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void comboBoxShippers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxShippers.SelectedValue != null)
            {
                textBoxShipperID.Text = comboBoxShippers.SelectedValue.ToString();
            }
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

        private void cbxPaiss_SelectedIndexChanged(object sender, EventArgs e)
        {
            string paisSeleccionado = cbxPais.SelectedItem.ToString();
            cbxCiudad.Enabled = true;
            cbxCiudad.DataSource = paisesCiudades[paisSeleccionado];
        }

        private void cbxCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ciudadSeleccionada = cbxCiudad.SelectedItem.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dbcontext = new NorthwindContext();
            var ultimaOrden = dbcontext.Orders
                       .OrderByDescending(o => o.OrderId)
                       .FirstOrDefault();

            if (ultimaOrden == null)
            {
                MessageBox.Show("No se encontró ninguna orden para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridView2.Rows.Count > 0)
            {
                var confirmResult = MessageBox.Show($"Hay registros asociados a la orden. Si desea cancelar se eliminarán tanto los registros como la última orden creada. ¿Está seguro que desea continuar?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    var detallesOrden = dbcontext.OrderDetails
                        .Where(od => od.OrderId == ultimaOrden.OrderId)
                        .ToList();

                    foreach (var detalle in detallesOrden)
                    {
                        dbcontext.OrderDetails.Remove(detalle);
                    }

                    dbcontext.SaveChanges();

                    if (iordenCRUD.EliminarOrden(ultimaOrden.OrderId))
                    {
                        MessageBox.Show($"Última orden con ID {ultimaOrden.OrderId} y sus detalles eliminados con éxito.", "Eliminar orden", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        panel3.Enabled = false;
                        panel5.Enabled = false;
                        panel1.Enabled = true;
                        textBox17.Text = "";
                        textBoxID.Text = "";
                        textBoxPrecio.Text = "";
                        textBox5.Text = "";
                        textBox15.Text = "";
                        textBoxProducto.Text = "";


                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                var confirmResult = MessageBox.Show($"No hay registros en la tabla. ¿Está seguro que desea eliminar la última orden con ID {ultimaOrden.OrderId}?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    if (iordenCRUD.EliminarOrden(ultimaOrden.OrderId))
                    {
                        MessageBox.Show($"Última orden con ID {ultimaOrden.OrderId} eliminada con éxito.", "Eliminar orden", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        dataGridView1.DataSource = null;
                        panel3.Enabled = false;
                        panel5.Enabled = false;
                        panel1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string nombreProducto = textBoxBuscarProducto.Text.Trim();

            if (string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Por favor, ingrese un nombre de producto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dtcontext = new NorthwindContext();
            var productosFiltrados = dtcontext.Products
                .Where(p => p.ProductName.ToLower().Contains(nombreProducto.ToLower()))
                .ToList();

            if (productosFiltrados.Any())
            {

                dataGridView1.DataSource = productosFiltrados;
                btnReset.Visible = true;
            }
            else
            {
                MessageBox.Show("No se encontraron productos con ese nombre.", "Buscar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var dtcontext = new NorthwindContext();
            dataGridView1.DataSource = dtcontext.Products.ToList();
            btnReset.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];


                textBoxID.Text = filaSeleccionada.Cells["ProductId"].Value.ToString();
                textBoxProducto.Text = filaSeleccionada.Cells["ProductName"].Value.ToString();
                textBoxPrecio.Text = filaSeleccionada.Cells["UnitPrice"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var ordenId = int.Parse(textBox17.Text);
            var productiId = int.Parse(textBoxID.Text);
            var precioXunidad = decimal.Parse(textBoxPrecio.Text);
            var cantidad = short.Parse(textBox5.Text);
            var descuento = float.Parse(textBox15.Text) / 100;

            if (iordenDetalleCRUD.AgregarOrdenDetalle(ordenId, productiId, precioXunidad, cantidad, descuento))
            {
                MessageBox.Show("Nuevo detalle de la orden ingresada con éxito", "Agregar Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var dtcontext = new NorthwindContext();
                dataGridView2.DataSource = iordenDetalleCRUD.ObtenerOrdenDetalle(ordenId);
                ActualizarResumen();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView2.SelectedRows[0];

                int orderId = int.Parse(filaSeleccionada.Cells["OrderId"].Value.ToString());
                int productId = int.Parse(filaSeleccionada.Cells["ProductId"].Value.ToString());

                var confirmResult = MessageBox.Show($"¿Está seguro que desea eliminar el detalle del producto con ID {productId} de la orden con ID {orderId}?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    if (iordenDetalleCRUD.EliminarOrdenDetalle(orderId, productId))
                    {
                        MessageBox.Show("Detalle de la orden eliminado con éxito", "Eliminar Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var dtcontext = new NorthwindContext();
                        dataGridView2.DataSource = iordenDetalleCRUD.ObtenerOrdenDetalle(orderId);

                        ActualizarResumen();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el detalle de la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un detalle de la orden para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCrearOrden_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("¿Está seguro que desea crear la orden y cerrar el formulario?",
                                                "Confirmar creación de orden",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {

                this.Close();
            }
            else
            {
                MessageBox.Show("La creación de la orden ha sido cancelada.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                label33.Text = promedioUnitPrice.ToString("F2"); 

                var sumaCantidad = detallesOrden
                    .Sum(row => Convert.ToInt32(row.Cells["Quantity"].Value));
                label34.Text = sumaCantidad.ToString(); 
                
                var promedioDescuento = detallesOrden
                    .Average(row => Convert.ToSingle(row.Cells["Discount"].Value));
                promedioDescuento = promedioDescuento * 100;
                label35.Text = promedioDescuento.ToString(); 


                var subtotal = detallesOrden
      .Sum(row => Convert.ToDecimal(row.Cells["UnitPrice"].Value) * Convert.ToInt32(row.Cells["Quantity"].Value));
                textBoxSubtotal.Text = subtotal.ToString("F2");
              
                var totalDescuento = detallesOrden
                    .Sum(row => Convert.ToDecimal(row.Cells["UnitPrice"].Value) * Convert.ToInt32(row.Cells["Quantity"].Value) * Convert.ToDecimal(row.Cells["Discount"].Value));
                textBoxDescuento.Text = totalDescuento.ToString("F2");

                var total = subtotal - totalDescuento;
                textBoxTotal.Text = total.ToString("F2");
            }
            else
            {
                
                label33.Text = "0.00";
                label34.Text = "0";
                label35.Text = "0.00";
                textBoxSubtotal.Text = "0.00";
                textBoxDescuento.Text = "0.00";
                textBoxTotal.Text = "0.00";
            }
        }

    }

}

