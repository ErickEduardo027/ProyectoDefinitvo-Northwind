using ProyectoDefinitvo___Northwind.Servicios.categorias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    public partial class categoriasForm : Form
    {
        public categoriasForm()
        {
            InitializeComponent();
        }

        private void categoriasForm_Load(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            var ListaDeCategorias = new categoriaCRUD();
            DataTable categorias = ListaDeCategorias.ObtenerCategorias();
            dataGridView1.DataSource = categorias;
            dataGridView1.Columns["CategoryID"].HeaderText = "Id de la categoría:";
            dataGridView1.Columns["CategoryName"].HeaderText = "Nombre de la categoría:";
            dataGridView1.Columns["Description"].HeaderText = "Descripción de la categoría:";
            dataGridView1.Columns["Picture"].HeaderText = "Fotografía:";
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
