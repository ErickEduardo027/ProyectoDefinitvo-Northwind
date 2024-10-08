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
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    public partial class productosForm : Form
    {
        private readonly IproductosService iproductosService;

        public productosForm(IproductosService iproductosService)
        {
            InitializeComponent();
            this.iproductosService = iproductosService;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var agregar = new AgregarProductoDialog(iproductosService);
            agregar.ShowDialog();
        }

        private void productosForm_Load(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            btnfiltrar.Visible = false;
            var leer = new productoCRUD();
            DataTable productos = leer.ObtenerProductos();
            dataGridView1.DataSource = productos;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string nombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                var productoCRUD = new productoCRUD();

                bool exito = productoCRUD.EliminarProducto(nombre);

                if (exito)
                {
                    MessageBox.Show("Producto eliminado con éxito.", "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var leer = new productoCRUD();
                    DataTable productos = leer.ObtenerProductos();
                    dataGridView1.DataSource = productos;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string productName = dataGridView1.SelectedRows[0].Cells["ProductName"].Value.ToString();
                var actualizar = new ActualizarProductoDialog(iproductosService);
                actualizar.Tag = productName;
                actualizar.ShowDialog();
                btnReset.Visible = true;

            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var leer = new productoCRUD();
            DataTable productos = leer.ObtenerProductos();
            dataGridView1.DataSource = productos;
            btnReset.Visible = false;
        }
    }
}
