using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    public partial class categoriasForm : Form
    {
        private readonly IcategoriaService icategoriaService;

        public categoriasForm(IcategoriaService icategoriaService)
        {
            InitializeComponent();
            this.icategoriaService = icategoriaService;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formTnstance = new AgregarCategoriaDialog(icategoriaService);
            formTnstance.ShowDialog();
            btnReset.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var leer = new categoriaCRUD();
            dataGridView1.DataSource = leer.ObtenerCategorias();
            btnReset.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta categoría?, no vayas a poner un huevo!",
                    "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                    var categoriaCRUD = new categoriaCRUD();

                    bool exito = categoriaCRUD.EliminarCategoria(id);

                    if (exito)
                    {
                        MessageBox.Show("Categoría eliminada con éxito, despues no te quejes!", "Eliminar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var leer = new categoriaCRUD();
                        DataTable categorias = leer.ObtenerCategorias();
                        dataGridView1.DataSource = categorias;
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string categoriaName = dataGridView1.SelectedRows[0].Cells["CategoryName"].Value.ToString();
                var actualizar = new ActualizarCategoriaDialog(icategoriaService);
                actualizar.Tag = categoriaName;
                actualizar.ShowDialog();
                btnReset.Visible = true;

            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoria para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
