using ProyectoDefinitvo___Northwind.FormulariosDeProyecto;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle;
using ProyectoDefinitvo___Northwind.Servicios.Ordenes;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
using Serilog;

namespace ProyectoDefinitvo___Northwind
{
    public partial class LoginForm : Form
    {
        private readonly IproductosService iproductosService;
        private readonly ISuplidorService isuplidorService;
        private readonly ILogger logger;
        private readonly IproductoCRUD iproductoCRUD;
        private readonly IcategoriaCRUD icategoriaCRUD;
        private readonly IsuplidoresCRUD isuplidoresCRUD;
        private readonly IOrdenDetalleCRUD iordenDetalleCRUD;
        private readonly IordenCRUD iordenCRUD;
        private readonly IordenService iordenService;
        private readonly IcategoriaService icategoriaService;
        private OrdenesForm ordenesForm;

        public LoginForm(IproductosService iproductosService, IcategoriaService icategoriaService,  ISuplidorService isuplidorService, ILogger logger, IproductoCRUD iproductoCRUD, IcategoriaCRUD icategoriaCRUD, IsuplidoresCRUD isuplidoresCRUD, IOrdenDetalleCRUD iordenDetalleCRUD, IordenCRUD iordenCRUD, IordenService iordenService)
        {
            InitializeComponent();
            this.iproductosService = iproductosService;
            this.icategoriaService = icategoriaService;
            this.isuplidorService = isuplidorService;
            this.logger = logger;
            this.iproductoCRUD = iproductoCRUD;
            this.icategoriaCRUD = icategoriaCRUD;
            this.isuplidoresCRUD = isuplidoresCRUD;
            this.iordenDetalleCRUD = iordenDetalleCRUD;
            this.iordenCRUD = iordenCRUD;
            this.iordenService = iordenService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //(BUG) hace un hoyo en el programa
            //magicamente se daño, comprobar despues...
            //pictureBox2.Parent = pictureBox1;
            txtUsuario.Text = "Usuario";
            txtUsuario.ForeColor = Color.DarkGray;
            txtContraseña.Text = "Contraseña";
            txtContraseña.ForeColor = Color.DarkGray;
            txtUsuario.GotFocus += txtUsuario_GotFocus;
            txtUsuario.LostFocus += txtUsuario_LostFocus;
            txtContraseña.GotFocus += txtContraseña_GotFocus;
            txtContraseña.LostFocus += txtContraseña_LostFocus;
            MostrarContraseña.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                mainMenu mainMenu = new mainMenu(iproductosService, icategoriaService, isuplidorService, logger, iproductoCRUD, icategoriaCRUD, isuplidoresCRUD, iordenDetalleCRUD, iordenCRUD, iordenService, iordenDetalleCRUD, ordenesForm);

                string nombre = txtUsuario.Text;
                mainMenu.ActualizarNombreText(nombre);
                //(BUG) el mensaje no aparece :,(
                //MessageBox.Show("Bienvenido al sistema, señor/a: " + nombre, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                splashScreen splashScreen = new splashScreen();
                splashScreen.Show();
                this.Hide();

                splashScreen.FormClosed += (s, args) =>
                {
                    mainMenu.Show();
                };
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (MostrarContraseña.Checked == true)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '•';
            }
        }

        private void txtUsuario_GotFocus(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_LostFocus(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DarkGray;
            }
        }

        private void txtContraseña_GotFocus(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.Black;
                txtContraseña.PasswordChar = '•';
            }
            MostrarContraseña.Enabled = true;
        }

        private void txtContraseña_LostFocus(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.PasswordChar = '\0';
                txtContraseña.ForeColor = Color.DarkGray;
            }
        }

        private bool Validar()
        {
            bool valid = true;

            if (txtUsuario.Text.Trim() == "Usuario")
            {
                errorProvider1.SetError(txtUsuario, "Es requerido un usuario.");
                valid = false;
            }
            else errorProvider1.SetError(txtUsuario, "");


            if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBox1, "Es requerido un rol.");
                valid = false;
            }
            else errorProvider1.SetError(comboBox1, "");

            if (txtContraseña.Text.Trim() == "Contraseña")
            {
                errorProvider1.SetError(txtContraseña, "Es requerido una contraseña.");
                valid = false;
            }
            else errorProvider1.SetError(txtContraseña, "");

            return valid;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}