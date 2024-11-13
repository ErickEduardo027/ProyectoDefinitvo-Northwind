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
using System.Data.SqlTypes;
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
            comboBoxClientes.SelectedIndex = -1;
            comboBoxEmpleados.SelectedIndex = -1;
            comboBoxShippers.SelectedIndex = -1;
            textBoxClienteID.Text = "";
            textBoxEmpleadoID.Text = "";
            textBoxShipperID.Text = "";
            cbxCiudad.Text = string.Empty;
            cbxPais.Text = string.Empty;
            textBox1.Text = "0";
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

                MessageBox.Show("Paso 2", "Proceda a agregar los detalles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel3.Enabled = true;
                panel1.Enabled = false;
                textBoxCostoTransporte.Text = textBox1.Text;
                label29.Text = "0";
                label32.Text = "0";
                label36.Text = "0";
                textBoxSubtotal.Text = "0";
                textBoxCostoTransporte.Text = "0";
                textBoxTotal.Text = "0";

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

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedItem != null)
            {
                var productoSeleccionado = (dynamic)cbxProducto.SelectedItem;

                textBoxID.Text = productoSeleccionado.ProductId.ToString();
                textBoxPrecio.Text = productoSeleccionado.UnitPrice.ToString("C");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta fila?",
                                                      "Confirmar eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    {
                        dataGridView2.Rows.Remove(row);
                        ActualizarResumen();
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

                var total = subtotal + int.Parse(textBoxCostoTransporte.Text);
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

    }

}


