using FluentValidation;
using ProyectoDefinitvo___Northwind.FormulariosDeProyecto;
using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle;
using ProyectoDefinitvo___Northwind.Servicios.Ordenes;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
using Serilog;
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
        private readonly ISuplidorService isuplidorService;
        private readonly ILogger logger;
        private readonly IproductoCRUD iproductoCRUD;
        private readonly IcategoriaCRUD icategoriaCRUD;
        private readonly IsuplidoresCRUD isuplidoresCRUD;
        private readonly IOrdenDetalleCRUD iordenDetalleCRUD;
        private readonly IordenCRUD iordenCRUD;
        private readonly IordenService iordenService;
        private readonly IOrdenDetalleCRUD iordenDetalleCRUD1;
        private OrdenesForm ordenesForm;


        public IcategoriaService icategoriaService { get; }

        public mainMenu(IproductosService iproductosService, IcategoriaService icategoriaService, ISuplidorService isuplidorService, ILogger logger, IproductoCRUD iproductoCRUD, IcategoriaCRUD icategoriaCRUD, IsuplidoresCRUD isuplidoresCRUD, IOrdenDetalleCRUD IordenDetalleCRUD, IordenCRUD iordenCRUD, IordenService iordenService, IOrdenDetalleCRUD iordenDetalleCRUD, OrdenesForm ordenesForm)
        {
            InitializeComponent();
            this.iproductosService = iproductosService;
            this.icategoriaService = icategoriaService;
            this.isuplidorService = isuplidorService;
            this.logger = logger;
            this.iproductoCRUD = iproductoCRUD;
            this.icategoriaCRUD = icategoriaCRUD;
            this.isuplidoresCRUD = isuplidoresCRUD;
            this.iordenDetalleCRUD = IordenDetalleCRUD;
            this.iordenCRUD = iordenCRUD;
            this.iordenService = iordenService;
            this.iordenDetalleCRUD1 = iordenDetalleCRUD;
            
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
            abrirForm(new productosForm(iproductosService, logger, iproductoCRUD, icategoriaCRUD, isuplidoresCRUD));
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirForm(new categoriasForm(icategoriaService, logger, icategoriaCRUD));
        }

        private void btnSuplidores_Click(object sender, EventArgs e)
        {
            abrirForm(new suplidoresForm(isuplidorService, logger, isuplidoresCRUD));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vuelva pronto señor/a: " + labelNombre.Text + " Cualquier cosa el dev esta en maldivas ;)", "Log out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoginForm loginForm = new LoginForm(iproductosService, icategoriaService, isuplidorService, logger, iproductoCRUD, icategoriaCRUD, isuplidoresCRUD, iordenDetalleCRUD, iordenCRUD, iordenService);
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

        public void ActualizarNombreText(string text)
        {
            labelNombre.Text = text;
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            abrirForm(new OrdenesForm(iordenDetalleCRUD, isuplidoresCRUD, icategoriaCRUD, iordenCRUD, iordenService, iordenDetalleCRUD, ordenesForm));
        }
    }
}
