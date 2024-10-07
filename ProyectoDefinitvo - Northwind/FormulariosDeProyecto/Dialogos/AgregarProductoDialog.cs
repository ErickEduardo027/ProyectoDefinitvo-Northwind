using FluentValidation;
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
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.productoService.CrearProducto(new CrearProductoRequest
                {
                    ProductName = txtProductName.Text,
                    SupplierID = int.Parse(txtSupplierID.Text),
                    CategoryID = int.Parse(txtCategoryID.Text),
                    QuantityPerUnit = txtQuantityPerUnit.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = short.Parse(txtUnitsInStock.Text),
                    UnitsOnOrder = short.Parse(txtUnitsOnOrder.Text),
                    ReorderLevel = short.Parse(txtReorderLevel.Text),
                    Discontinued = cbxDiscontinued.Text
                });
            }
            catch (ValidationException ex)
            {
                var message = ex.GetMessage();
                MessageBox.Show(message, "Validacion de errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    public static class ValidationExceptionExtension
    {
        public static string GetMessage(this ValidationException ex)
        {
            return string.Join("\n", ex.Errors.Select(a => a.ErrorMessage));
        }
    }
}