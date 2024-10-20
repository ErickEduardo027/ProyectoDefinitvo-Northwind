using FluentValidation;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public partial class AgregarSuplidorDialog : Form
    {
        private Dictionary<string, List<string>> paisesCiudades = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> ciudadesRegiones = new Dictionary<string, List<string>>();
        private readonly ISuplidorService isuplidorService;
        private readonly ILogger logger;
        private readonly IsuplidoresCRUD isuplidoresCRUD;

        public AgregarSuplidorDialog(ISuplidorService suplidorService, ILogger logger, IsuplidoresCRUD isuplidoresCRUD)
        {

            InitializeComponent();
            InicializarDatos();
            this.isuplidorService = suplidorService;
            this.logger = logger;
            this.isuplidoresCRUD = isuplidoresCRUD;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cbxCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ciudadSeleccionada = cbxCiudad.SelectedItem.ToString();
        }
        private void cbxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            string paisSeleccionado = cbxPais.SelectedItem.ToString();
            cbxCiudad.Enabled = true;
            cbxCiudad.DataSource = paisesCiudades[paisSeleccionado];
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            logger.Information("suplidores_ADD:");

            var nombreSuplidor = txtNombre.Text;
            var representante = txtRepresentante.Text;
            var PuestoRepresentante = cbxPuestoRepresentante.Text;
            var direccion = txtDireccion.Text;
            var pais = cbxPais.Text;
            var ciudad = cbxCiudad.Text;
            var region = txtRegion.Text;
            var codigoPostal = txtCodigoPostal.Text;
            var telefono = txtTelefono.Text;
            var fax = txtFax.Text;
            var homepage = txtHomepage.Text;


            try
            {
                this.isuplidorService.CrearSuplidor(new CrearSuplidorRequest
                {
                    CompanyName = nombreSuplidor,
                    ContactName = representante,
                    ContactTitle = PuestoRepresentante,
                    Address = direccion,
                    City = ciudad,
                    Region = region,
                    PostalCode = codigoPostal,
                    Country = pais,
                    Phone = telefono,
                    Fax = fax,
                    HomePage = homepage,
                });

                if (isuplidoresCRUD.AgregarSuplidor(nombreSuplidor, representante, PuestoRepresentante, direccion, ciudad, region, codigoPostal, pais, telefono, fax, homepage))
                {
                    MessageBox.Show("Nuevo suplidor ingresado con éxito", "Agregar suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombre.Text = "";
                    txtRepresentante.Text = "";
                    cbxPuestoRepresentante.Text = "";
                    txtDireccion.Text = "";
                    cbxPais.Text = "";
                    cbxCiudad.Text = "";
                    txtRegion.Text = "";
                    txtCodigoPostal.Text = "";
                    txtTelefono.Text = "";
                    txtFax.Text = "";
                    txtHomepage.Text = "";
                }
                else
                {
                    MessageBox.Show("Error al agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ValidationException ex)
            {
                var message = ex.Message;
                MessageBox.Show(message, "Validación de errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AgregarSuplidorDialog_Load(object sender, EventArgs e)
        {

        }
    }
}

