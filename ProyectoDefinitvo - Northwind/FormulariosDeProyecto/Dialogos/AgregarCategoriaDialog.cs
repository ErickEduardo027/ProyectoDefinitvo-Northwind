using FluentValidation;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using Serilog;
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
    public partial class AgregarCategoriaDialog : Form
    {
        private readonly IcategoriaService icategoriaService;
        private readonly ILogger logger;
        private readonly IcategoriaCRUD icategoriaCRUD;

        public AgregarCategoriaDialog(IcategoriaService icategoriaService, ILogger logger, IcategoriaCRUD icategoriaCRUD)
        {
            InitializeComponent();
            this.icategoriaService = icategoriaService;
            this.logger = logger;
            this.icategoriaCRUD = icategoriaCRUD;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            logger.Information("Categoria_ADD:");
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

                if (icategoriaCRUD.AgregarCategoria(categoryName, description, pictureData))
                {
                    MessageBox.Show("Nueva categoría ingresada con éxito", "Agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("Error al agregar la categoría", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException ex)
            {
                var message = ex.Message;
                MessageBox.Show(message, "Validación de errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog subir = new OpenFileDialog();
            subir.Filter = "Select Image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (subir.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(subir.FileName);
            }

        }

        private void AgregarCategoriaDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
