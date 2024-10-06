using ProyectoDefinitvo___Northwind.FormulariosDeProyecto;
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

namespace ProyectoDefinitvo___Northwind
{
    public partial class mainMenu : Form
    {
        private Form Activarform;
        public mainMenu()
        {
            InitializeComponent();
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
            abrirForm(new productosForm());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirForm(new categoriasForm());
        }

        private void btnSuplidores_Click(object sender, EventArgs e)
        {
            abrirForm(new suplidoresForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnCerrarFormularios_Click(object sender, EventArgs e)
        {
            if (abrirForm != null)
            {
                Activarform.Close();
                Resetear();
            }
        }

        private void Resetear()
        {
            lblTitulo.Text = "DASHBOARD";
            btnCerrarFormularios.Visible = false;
        }
    }
}
