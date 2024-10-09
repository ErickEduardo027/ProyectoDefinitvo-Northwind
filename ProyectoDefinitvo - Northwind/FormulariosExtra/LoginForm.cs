using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.productos;

namespace ProyectoDefinitvo___Northwind
{
    public partial class LoginForm : Form
    {
        private readonly IproductosService iproductosService;

        public IcategoriaService icategoriaService { get; }

        public LoginForm(IproductosService iproductosService, IcategoriaService icategoriaService)
        {
            InitializeComponent();
            this.iproductosService = iproductosService;
            this.icategoriaService = icategoriaService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //(BUG) hace un hoyo en el programa
            //magicamente se da�o, comprobar despues...
            //pictureBox2.Parent = pictureBox1;
            txtUsuario.Text = "Usuario";
            txtUsuario.ForeColor = Color.DarkGray;
            txtContrase�a.Text = "Contrase�a";
            txtContrase�a.ForeColor = Color.DarkGray;
            txtUsuario.GotFocus += txtUsuario_GotFocus;
            txtUsuario.LostFocus += txtUsuario_LostFocus;
            txtContrase�a.GotFocus += txtContrase�a_GotFocus;
            txtContrase�a.LostFocus += txtContrase�a_LostFocus;
            MostrarContrase�a.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                mainMenu mainMenu = new mainMenu(iproductosService, icategoriaService);

                string nombre = txtUsuario.Text;
                mainMenu.ActualizarNombreText(nombre);
                //(BUG) el mensaje no aparece :,(
                //MessageBox.Show("Bienvenido al sistema, se�or/a: " + nombre, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (MostrarContrase�a.Checked == true)
            {
                txtContrase�a.PasswordChar = '\0';
            }
            else
            {
                txtContrase�a.PasswordChar = '�';
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

        private void txtContrase�a_GotFocus(object sender, EventArgs e)
        {
            if (txtContrase�a.Text == "Contrase�a")
            {
                txtContrase�a.Text = "";
                txtContrase�a.ForeColor = Color.Black;
                txtContrase�a.PasswordChar = '�';
            }
            MostrarContrase�a.Enabled = true;
        }

        private void txtContrase�a_LostFocus(object sender, EventArgs e)
        {
            if (txtContrase�a.Text == "")
            {
                txtContrase�a.Text = "Contrase�a";
                txtContrase�a.PasswordChar = '\0';
                txtContrase�a.ForeColor = Color.DarkGray;
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

            if (txtContrase�a.Text.Trim() == "Contrase�a")
            {
                errorProvider1.SetError(txtContrase�a, "Es requerido una contrase�a.");
                valid = false;
            }
            else errorProvider1.SetError(txtContrase�a, "");

            return valid;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}