using ProyectoDefinitvo___Northwind.Servicios.productos;

namespace ProyectoDefinitvo___Northwind
{
    public partial class LoginForm : Form
    {
        private readonly IproductosService iproductosService;

        public LoginForm(IproductosService iproductosService)
        {
            InitializeComponent();
            this.iproductosService = iproductosService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Parent = pictureBox1;
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

                
                mainMenu mainMenu = new mainMenu(iproductosService);

                string nombre = txtUsuario.Text;
                mainMenu.ActualizarNombreText(nombre);
                MessageBox.Show("Bienvenido al sistema, señor/a: " + nombre, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                splashScreen splashScreen = new splashScreen();
                splashScreen.Show();

                this.Hide();

                splashScreen.FormClosed += (s, args) =>
                {
                    mainMenu.Show();
                };
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            if (txtContraseña.Text.Trim() == "Contraseña")
            {
                errorProvider1.SetError(txtContraseña, "Es requerido una contraseña.");
                valid = false;
            }
            return valid;
        }

        private void txtUsuario_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUsuario, "");
        }

        private void txtContraseña_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtContraseña, "");
        }
    }
}