using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.productos;
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
using static ProyectoDefinitvo___Northwind.Servicios.productos.productosService;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public partial class ActualizarProductoDialog : Form
    {
        private readonly IproductosService productosService;
        private readonly ILogger logger;
        string connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");
        public ActualizarProductoDialog(IproductosService iproductosService, ILogger logger)
        {
            InitializeComponent();
            this.productosService = iproductosService;
            this.logger = logger;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtCategoryID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null)

                txtSupplierID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void ActualizarProductoDialog_Load(object sender, EventArgs e)
        {
            string productName = this.Tag.ToString();
            CargarProductoPorNombre(productName);

            var ListaDeCategorias = new categoriaCRUD();
            DataTable categorias = ListaDeCategorias.ObtenerCategorias();
            dataGridView1.DataSource = categorias;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            var listaDeSuplidores = new suplidoresCRUD();
            DataTable Suplidores = listaDeSuplidores.ObtenerSuplidores();
            dataGridView2.DataSource = Suplidores;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            logger.Information("producto_UPDATE:");
            var ProductId = int.Parse(txtProductoId.Text);
            var ProductName = txtProductName.Text;
            int SupplierID = int.Parse(txtSupplierID.Text);
            int CategoryID = int.Parse(txtCategoryID.Text);
            string QuantityPerUnit = txtQuantityPerUnit.Text;
            decimal UnitPrice;
            short UnitsInStock;
            short UnitsOnOrder;
            short ReorderLevel;
            bool Discontinued = chkDiscontinued.Checked;

            bool isValid = true;
            StringBuilder errorMessage = new StringBuilder();


            if (!decimal.TryParse(txtUnitPrice.Text, out UnitPrice))
            {
                errorMessage.AppendLine("UnitPrice debe ser un número decimal válido.");
                isValid = false;
            }

            if (!short.TryParse(txtUnitsInStock.Text, out UnitsInStock))
            {
                errorMessage.AppendLine("UnitsInStock debe ser un número entero.");
                isValid = false;
            }

            if (!short.TryParse(txtUnitsOnOrder.Text, out UnitsOnOrder))
            {
                errorMessage.AppendLine("UnitsOnOrder debe ser un número entero.");
                isValid = false;
            }

            if (!short.TryParse(txtReorderLevel.Text, out ReorderLevel))
            {
                errorMessage.AppendLine("ReorderLevel debe ser un número entero.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage.ToString(), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.productosService.CrearProducto(new CrearProductoRequest
                {
                    ProductName = txtProductName.Text,
                    SupplierID = int.Parse(txtSupplierID.Text),
                    CategoryID = int.Parse(txtCategoryID.Text),
                    QuantityPerUnit = txtQuantityPerUnit.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = short.Parse(txtUnitsInStock.Text),
                    UnitsOnOrder = short.Parse(txtUnitsOnOrder.Text),
                    ReorderLevel = short.Parse(txtReorderLevel.Text),
                    Discontinued = chkDiscontinued.Checked

                });
            }
            catch (ValidationException ex)
            {
                var message = ex.GetMessage();
                MessageBox.Show(message, "Validacion de errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var actualizar = new productoCRUD();

            if (actualizar.ActualizarProducto(ProductId, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice,
                        UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued))
            {
                MessageBox.Show("Nuevo producto Actualizado con éxito", "Actualizar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("Error al Actualizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductoPorNombre(string productName)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            {
                SqlCommand cmd = conexion.CreateCommand();
                cmd.CommandText = "SELECT * FROM Products WHERE ProductName = @ProductName";
                cmd.Parameters.AddWithValue("@ProductName", productName);

                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtProductoId.Text = reader["ProductID"].ToString();
                    txtProductName.Text = reader["ProductName"].ToString();
                    txtSupplierID.Text = reader["SupplierID"].ToString();
                    txtCategoryID.Text = reader["CategoryID"].ToString();
                    txtQuantityPerUnit.Text = reader["QuantityPerUnit"].ToString();
                    txtUnitPrice.Text = reader["UnitPrice"].ToString();
                    txtUnitsInStock.Text = reader["UnitsInStock"].ToString();
                    txtUnitsOnOrder.Text = reader["UnitsOnOrder"].ToString();
                    txtReorderLevel.Text = reader["ReorderLevel"].ToString();
                    chkDiscontinued.Checked = (bool)reader["Discontinued"];
                }
                conexion.Close();
            }
        }

        private void txtSupplierID_Click(object sender, EventArgs e)
        {
            MessageBox.Show("campo no editable!. selecciona un suplidor en la lista de suplidores disponibles", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtCategoryID_Click(object sender, EventArgs e)
        {
            MessageBox.Show("campo no editable!. selecciona una categoria en la lista de categorias disponibles", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
