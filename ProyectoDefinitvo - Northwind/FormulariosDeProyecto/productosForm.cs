using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    public partial class productosForm : Form
    {
        private readonly IproductosService iproductosService;

        public productosForm(IproductosService iproductosService)
        {
            InitializeComponent();
            this.iproductosService = iproductosService;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var instancia = new AgregarProductoDialog(iproductosService);
            instancia.ShowDialog();
        }
    }
}
