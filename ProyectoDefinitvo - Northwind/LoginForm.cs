namespace ProyectoDefinitvo___Northwind
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Parent = pictureBox1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            splashScreen splashScreen = new splashScreen();
            splashScreen.Show();
            this.Hide();
        }
    }
}
