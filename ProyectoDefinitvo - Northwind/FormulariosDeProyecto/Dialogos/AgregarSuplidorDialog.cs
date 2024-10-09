using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public partial class AgregarSuplidorDialog : Form
    {
        private Dictionary<string, List<string>> paisesCiudades = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> ciudadesRegiones = new Dictionary<string, List<string>>();

        public AgregarSuplidorDialog()
        {

            InitializeComponent();
            InicializarDatos();

        }

        private void AgregarSuplidorDialog_Load(object sender, EventArgs e)
        {


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

        }
    }
}

