using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.OrdenDetalle;
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

        public OrdenesForm(IOrdenDetalleCRUD IordenDetalleCRUD, IsuplidoresCRUD isuplidoresCRUD, IcategoriaCRUD icategoriaCRUD)
        {
            InitializeComponent();
            iordenDetalleCRUD = IordenDetalleCRUD;
            this.isuplidoresCRUD = isuplidoresCRUD;
            this.icategoriaCRUD = icategoriaCRUD;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var agregar = new AgregarOrdenDialog();
            agregar.ShowDialog();
        }

        private void OrdenesForm_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox1.Visible = false;
            btnReset.Visible = false;
            btnFiltrarPorNombre.Visible = false;
            btnReset.Visible = false;
            dataGridView1.DataSource = iordenDetalleCRUD.ObtenerOrdenDetalle();
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
            dataGridView1.DataSource = GetDataTable("SELECT * FROM Products WHERE ProductName = @ProductName",
                new Dictionary<string, object>
                {
            { "@ProductName", textBox1.Text }
                });
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            textBox1.Text = "";
            dataGridView1.DataSource = iordenDetalleCRUD.ObtenerOrdenDetalle();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            {

                label2.Visible = false;
                textBox1.Visible = false;

                if (comboBox3.Text == "Nombre")
                {
                    label2.Visible = true;
                    label2.Text = "Ingresa el nombre:";
                    textBox1.Visible = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnFiltrarPorNombre.Visible = true;
        }
    }
}
