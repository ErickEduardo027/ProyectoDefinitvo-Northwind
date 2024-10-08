using FluentValidation;
using Microsoft.Data.SqlClient;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoDefinitvo___Northwind.Servicios.productos.productosService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public partial class AgregarProductoDialog : Form
    {
        private readonly IproductosService productoService;

        public AgregarProductoDialog(IproductosService productoService)
        {
            InitializeComponent();
            this.productoService = productoService;
        }
        private void AgregarProductoDialog_Load(object sender, EventArgs e)
        {
            txtSupplierID.Text = "0";
            txtCategoryID.Text = "0";
            txtSupplierID.Text = "0";
            txtUnitPrice.Text = "0";
            txtUnitsInStock.Text = "0";
            txtUnitsOnOrder.Text = "0";
            txtReorderLevel.Text = "0";

            SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-KK0P0EO7\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM Categories";

            conexion.Open();
            var datareader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(datareader);
            conexion.Close();
            dataGridView1.DataSource = dataTable;

            SqlConnection conexion2 = new SqlConnection("Data Source=LAPTOP-KK0P0EO7\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            SqlCommand cmd2 = conexion2.CreateCommand();
            cmd2.CommandText = "SELECT * FROM Suppliers";

            conexion2.Open();
            var datareader2 = cmd2.ExecuteReader();
            DataTable dataTable2 = new DataTable();
            dataTable2.Load(datareader2);
            conexion2.Close();
            dataGridView2.DataSource = dataTable2;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
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
                this.productoService.CrearProducto(new CrearProductoRequest
                {
                    ProductName = ProductName,
                    SupplierID = SupplierID,
                    CategoryID = CategoryID,
                    QuantityPerUnit = QuantityPerUnit,
                    UnitPrice = UnitPrice,
                    UnitsInStock = UnitsInStock,
                    UnitsOnOrder = UnitsOnOrder,
                    ReorderLevel = ReorderLevel,
                    Discontinued = Discontinued
                });

                var agregar = new productoCRUD();
                if (agregar.AgregarProducto(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice,
                        UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued))
                {
                    MessageBox.Show("Nuevo producto ingresado con éxito", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtProductName.Text = "";
                    txtSupplierID.Text = "0";
                    txtCategoryID.Text = "0";
                    txtQuantityPerUnit.Text = "";
                    txtUnitPrice.Text = "0";
                    txtUnitsInStock.Text = "0";
                    txtUnitsOnOrder.Text = "0";
                    txtReorderLevel.Text = "0";
                    chkDiscontinued.Checked = false;
                }
                else
                {
                    MessageBox.Show("Error al agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException ex)
            {
                var message = ex.Message;
                MessageBox.Show(message, "Validación de errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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