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
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using System.Configuration;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    public partial class productosForm : Form
    {
        private readonly IproductosService iproductosService;
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");
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
            btnReset.Visible = true;
        }

        private void productosForm_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            btnReset.Visible = false;
            btnFiltrarPorNombre.Visible = false;
            btnFiltrarPorCategoria.Visible = false;
            btnFiltrarPorSuplidor.Visible = false;
            var leer = new productoCRUD();
            DataTable productos = leer.ObtenerProductos();
            dataGridView1.DataSource = productos;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string nombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar el producto '{nombre}'?, no vayas a poner un huevo!",
                    "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var productoCRUD = new productoCRUD();

                    bool exito = productoCRUD.EliminarProducto(nombre);

                    if (exito)
                    {
                        MessageBox.Show("Producto eliminado con éxito, despues no me vengas llorando!", "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var leer = new productoCRUD();
                        DataTable productos = leer.ObtenerProductos();
                        dataGridView1.DataSource = productos;
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            btnFiltrarPorNombre.Visible = false;
            btnFiltrarPorCategoria.Visible = false;
            btnFiltrarPorSuplidor.Visible = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {

                label2.Visible = false;
                textBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;

                if (comboBox1.Text == "Nombre")
                {
                    label2.Visible = true;
                    textBox1.Visible = true;
                }
                else if (comboBox1.Text == "Suplidor")
                {
                    comboBox2.Visible = true;

                    var listaDeSuplidores = new suplidoresCRUD();
                    DataTable Suplidores = listaDeSuplidores.ObtenerSuplidores();
                    comboBox2.DataSource = Suplidores;
                    comboBox2.ValueMember = "SupplierID";
                    comboBox2.DisplayMember = "CompanyName";
                }
                else if (comboBox1.Text == "Categoria")
                {
                    comboBox3.Visible = true;

                    var ListaDeCategorias = new categoriaCRUD();
                    DataTable categorias = ListaDeCategorias.ObtenerCategorias();
                    comboBox3.DataSource = categorias;
                    comboBox3.ValueMember = "CategoryID";
                    comboBox3.DisplayMember = "CategoryName";
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFiltrarPorCategoria.Visible = true;
            btnFiltrarPorNombre.Visible = false;
            btnFiltrarPorSuplidor.Visible = false;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFiltrarPorCategoria.Visible = false;
            btnFiltrarPorNombre.Visible = false;
            btnFiltrarPorSuplidor.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnFiltrarPorCategoria.Visible = false;
            btnFiltrarPorNombre.Visible = true;
            btnFiltrarPorSuplidor.Visible = false;
        }

        public DataTable GetDataTable(string sql, Dictionary<string, object> parameters = null)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            sqlConnection.Open();

            var dataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            sqlConnection.Close();

            return dataTable;
        }

        private void btnFiltrarPorSuplidor_Click(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            dataGridView1.DataSource = GetDataTable("SELECT * FROM Products WHERE SupplierID = @SupplierID",
                new Dictionary<string, object>
                {
            { "@SupplierID", int.Parse(comboBox2.SelectedValue.ToString()) }
                });
        }

        private void btnFiltrarPorCategoria_Click(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            dataGridView1.DataSource = GetDataTable("SELECT * FROM Products WHERE CategoryID = @CategoryID",
                new Dictionary<string, object>
                {
            { "@CategoryID", int.Parse(comboBox3.SelectedValue.ToString()) }
                });
        }

        private void btnFiltrarPorNombre_Click(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            dataGridView1.DataSource = GetDataTable("SELECT * FROM Products WHERE ProductName = @ProductName",
                new Dictionary<string, object>
                {
            { "@ProductName", textBox1.Text }
                });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
