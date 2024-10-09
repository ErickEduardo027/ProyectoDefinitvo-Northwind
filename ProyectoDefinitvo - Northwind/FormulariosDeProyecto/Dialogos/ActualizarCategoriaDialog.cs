using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public partial class ActualizarCategoriaDialog : Form
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");
        private readonly IcategoriaService icategoriaService;

        public ActualizarCategoriaDialog(IcategoriaService icategoriaService)
        {
            InitializeComponent();
            this.icategoriaService = icategoriaService;
        }

        private void ActualizarCategoriaDialog_Load(object sender, EventArgs e)
        {
            string categoriasName = this.Tag.ToString();
            CargarCategoriaPorNombre(categoriasName);
        }

        private void CargarCategoriaPorNombre(string categoryName)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = "SELECT CategoryID, CategoryName, Description, Picture FROM Categories WHERE CategoryName = @CategoryName";
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtId.Text = reader["CategoryID"].ToString();
                            txtNombre.Text = reader["CategoryName"].ToString();
                            txtDescripcion.Text = reader["Description"].ToString();

                            byte[] imageData = (byte[])reader["Picture"];

                            try
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show("La imagen no es válida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                pictureBox1.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la categoría con el nombre especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            string categoryName = txtNombre.Text;
            string description = txtDescripcion.Text;
            byte[] pictureData = null;

            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    pictureData = ms.ToArray();
                }
            }

            try
            {

                this.icategoriaService.crearCategoria(new crearCategoriaRequest
                {
                    CategoryName = categoryName,
                    Description = description,
                    Picture = pictureData
                });

                var agregar = new categoriaCRUD();
                if (agregar.ActualizarCategoria(Id, categoryName, description, pictureData))
                {
                    MessageBox.Show("Categoría actualizada con éxito", "Actualizar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("Error al actualizar la categoría", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException ex)
            {
                var message = ex.Message;
                MessageBox.Show(message, "Validación de errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
