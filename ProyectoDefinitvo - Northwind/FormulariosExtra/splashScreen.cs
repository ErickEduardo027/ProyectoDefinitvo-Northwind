using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDefinitvo___Northwind
{
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
            ConfigurarCircularProgressBar();
        }

        private async void CargarProgreso()
        {
            for (int i = 0; i <= 100; i++)
            {
                ActualizarProgreso(i);
                await Task.Delay(50);
            }
            this.Close();
        }

        private void ActualizarProgreso(int valor)
        {
            ProgressBar1.Value = valor;
            ProgressBar1.Text = $"{valor}%";
        }

        private void ConfigurarCircularProgressBar()
        {
            ProgressBar1.Value = 0;
            ProgressBar1.Maximum = 100;
            ProgressBar1.Minimum = 0;
            ProgressBar1.ProgressColor = System.Drawing.Color.Blue;
        }

        private void splashScreen_Load_1(object sender, EventArgs e)
        {
            CargarProgreso();
        }
    }
}
