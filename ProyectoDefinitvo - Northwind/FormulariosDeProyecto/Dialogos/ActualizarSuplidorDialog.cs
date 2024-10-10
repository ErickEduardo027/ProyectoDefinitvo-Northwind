using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
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
    public partial class ActualizarSuplidorDialog : Form
    {
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");
        private readonly ISuplidorService isuplidorService;
        private readonly ILogger logger;

        public ActualizarSuplidorDialog(ISuplidorService isuplidorService, ILogger logger)
        {
            InitializeComponent();
            this.isuplidorService = isuplidorService;
            this.logger = logger;
        }

        private void ActualizarSuplidorDialog_Load(object sender, EventArgs e)
        {
            string suplidorName = this.Tag.ToString();
            CargarSuplidorPorNombre(suplidorName);
        }

        private void CargarSuplidorPorNombre(string suplidorName)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            {
                SqlCommand cmd = conexion.CreateCommand();
                {
                    cmd.CommandText = "SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage FROM Suppliers WHERE CompanyName = @CompanyName";
                    cmd.Parameters.AddWithValue("@CompanyName", suplidorName);

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["SupplierID"].ToString();
                            txtNombre.Text = reader["CompanyName"].ToString();
                            txtRepresentante.Text = reader["ContactName"].ToString();
                            cbxPuestoRepresentante.Text = reader["ContactTitle"].ToString();
                            txtDireccion.Text = reader["Address"].ToString();
                            cbxCiudad.Text = reader["City"].ToString();
                            txtRegion.Text = reader["Region"].ToString();
                            txtCodigoPostal.Text = reader["PostalCode"].ToString();
                            cbxPais.Text = reader["Country"].ToString();
                            txtTelefono.Text = reader["Phone"].ToString();
                            txtFax.Text = reader["Fax"].ToString();
                            txtHomepage.Text = reader["HomePage"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("No se encontró el suplidor con el nombre especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            logger.Information("suplidor_UPDATE");
            var id = int.Parse(textBox1.Text);
            var nombreSuplidor = txtNombre.Text;
            var representante = txtRepresentante.Text;
            var PuestoRepresentante = cbxPuestoRepresentante.Text;
            var direccion = txtDireccion.Text;
            var pais = cbxPais.Text;
            var ciudad = cbxCiudad.Text;
            var region = txtRegion.Text;
            var codigoPostal = txtCodigoPostal.Text;
            var telefono = txtTelefono.Text;
            var fax = txtFax.Text;
            var homepage = txtHomepage.Text;


            try
            {
                this.isuplidorService.CrearSuplidor(new CrearSuplidorRequest
                {
                    CompanyName = nombreSuplidor,
                    ContactName = representante,
                    ContactTitle = PuestoRepresentante,
                    Address = direccion,
                    City = ciudad,
                    Region = region,
                    PostalCode = codigoPostal,
                    Country = pais,
                    Phone = telefono,
                    Fax = fax,
                    HomePage = homepage,
                });

                var agregar = new suplidoresCRUD();
                if (agregar.ActualizarSuplidor(id, nombreSuplidor, representante, PuestoRepresentante, direccion, ciudad, region, codigoPostal, pais, telefono, fax, homepage))
                {
                    MessageBox.Show("Nuevo suplidor actualizado con éxito", "Actualizar suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error al actualizar el suplidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
