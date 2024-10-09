using FluentValidation;
using ProyectoDefinitvo___Northwind.FormulariosDeProyecto;
using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoDefinitvo___Northwind.Servicios.productos.productosService;

namespace ProyectoDefinitvo___Northwind
{
    public partial class mainMenu : Form
    {
        private Form Activarform;
        private readonly IproductosService iproductosService;

        public IcategoriaService icategoriaService { get; }

        public mainMenu(IproductosService iproductosService, IcategoriaService icategoriaService)
        {
            InitializeComponent();
            this.iproductosService = iproductosService;
            this.icategoriaService = icategoriaService;
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            btnCerrarFormularios.Visible = false;
        }

        private void abrirForm(Form formulario)
        {
            if (Activarform != null)
            {
                Activarform.Close();
            }
            Activarform = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            this.panelEscritorio.Controls.Add(formulario);
            this.panelEscritorio.Tag = formulario;
            formulario.BringToFront();
            formulario.Show();
            lblTitulo.Text = formulario.Text;
            btnCerrarFormularios.Visible = true;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirForm(new productosForm(iproductosService));
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirForm(new categoriasForm(icategoriaService));
        }

        private void btnSuplidores_Click(object sender, EventArgs e)
        {
            abrirForm(new suplidoresForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vuelva pronto señor/a: " + labelNombre.Text + " Cualquier cosa el dev esta en maldivas ;)","Log out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoginForm loginForm = new LoginForm(iproductosService, icategoriaService);
            loginForm.Show();
            this.Close();
        }

        private void btnCerrarFormularios_Click(object sender, EventArgs e)
        {
            if (abrirForm != null)
            {
                Activarform.Close();
                lblTitulo.Text = "DASHBOARD";
                btnCerrarFormularios.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ActualizarNombreText(string text)
        {
            labelNombre.Text = text;
        }
    }
}
