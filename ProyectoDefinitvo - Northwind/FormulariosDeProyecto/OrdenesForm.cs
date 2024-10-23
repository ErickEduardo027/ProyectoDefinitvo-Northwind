using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProyectoDefinitvo___Northwind.Data;
using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle;
using ProyectoDefinitvo___Northwind.Servicios.Ordenes;
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
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
    public partial class OrdenesForm : Form
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");
        private readonly IOrdenDetalleCRUD iordenDetalleCRUD;
        private readonly IsuplidoresCRUD isuplidoresCRUD;
        private readonly IcategoriaCRUD icategoriaCRUD;
        private readonly IordenCRUD iordenCRUD;
        private readonly IordenService iordenService;

        public OrdenesForm(IOrdenDetalleCRUD IordenDetalleCRUD, IsuplidoresCRUD isuplidoresCRUD, IcategoriaCRUD icategoriaCRUD, IordenCRUD iordenCRUD, IordenService iordenService, IOrdenDetalleCRUD iordenDetalleCRUD)
        {
            InitializeComponent();
            iordenDetalleCRUD = IordenDetalleCRUD;
            this.isuplidoresCRUD = isuplidoresCRUD;
            this.icategoriaCRUD = icategoriaCRUD;
            this.iordenCRUD = iordenCRUD;
            this.iordenService = iordenService;
            this.iordenDetalleCRUD = iordenDetalleCRUD;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var agregar = new AgregarOrdenDialog(iordenService, iordenCRUD, iordenDetalleCRUD);
            agregar.ShowDialog();
        }

        private void OrdenesForm_Load(object sender, EventArgs e)
        {

            label2.Visible = false;
            textBox1.Visible = false;
            btnReset.Visible = false;
            btnFiltrarPorNombre.Visible = false;
            btnReset.Visible = false;
            var dtcontext = new NorthwindContext();
            dataGridView1.DataSource = dtcontext.Orders.ToList();
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

        private void btnFiltrarPorNombre_Click(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            dataGridView1.DataSource = GetDataTable("SELECT * FROM Orders WHERE OrderID = @OrderID",
                new Dictionary<string, object>
                {
            { "@OrderID", int.Parse(textBox1.Text) }
                });
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            textBox1.Text = "";
            comboBox3.SelectedIndex = -1;
            var dtcontext = new NorthwindContext();
            dataGridView1.DataSource = dtcontext.Orders.ToList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            {

                label2.Visible = false;
                textBox1.Visible = false;

                if (comboBox3.Text == "ID")
                {
                    label2.Visible = true;
                    label2.Text = "Ingresa el ID de la orden:";
                    textBox1.Visible = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnFiltrarPorNombre.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

    if (dataGridView1.SelectedRows.Count > 0)
    {
        DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

        int orderId = Convert.ToInt32(filaSeleccionada.Cells["OrderId"].Value);


        var confirmResult = MessageBox.Show($"¿Está seguro que desea eliminar la orden con ID {orderId}?",
                                            "Confirmar eliminación",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

        if (confirmResult == DialogResult.Yes)
        {
       
            if (iordenCRUD.EliminarOrden(orderId))
            {
                MessageBox.Show($"Orden con ID {orderId} eliminada con éxito.", "Eliminar orden", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        dataGridView1.DataSource = iordenCRUD.obtenerOrdenes(); 
            }
            else
            {
                MessageBox.Show("Error al eliminar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    else
    {
        MessageBox.Show("Por favor, seleccione una orden para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
        }
    }
}
