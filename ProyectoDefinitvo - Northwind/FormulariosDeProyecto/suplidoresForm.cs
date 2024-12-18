﻿using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
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

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    public partial class suplidoresForm : Form
    {
        private readonly ISuplidorService isuplidorService;
        private readonly ILogger logger;
        private readonly IsuplidoresCRUD isuplidoresCRUD;
 
        public suplidoresForm(ISuplidorService suplidorService, ILogger logger, IsuplidoresCRUD isuplidoresCRUD)
        {
            InitializeComponent();
            this.isuplidorService = suplidorService;
            this.logger = logger;
            this.isuplidoresCRUD = isuplidoresCRUD;
        }

        private void suplidoresForm_Load(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            dataGridView1.DataSource = isuplidoresCRUD.ObtenerSuplidores();
            dataGridView1.Columns["SupplierID"].HeaderText = "Id del suplidor:";
            dataGridView1.Columns["CompanyName"].HeaderText = "Nombre del suplidor:";
            dataGridView1.Columns["ContactName"].HeaderText = "Representante del suplidor:";
            dataGridView1.Columns["ContactTitle"].HeaderText = "Puesto del representante del suplidor:";
            dataGridView1.Columns["Address"].HeaderText = "Direccion del suplidor:";
            dataGridView1.Columns["City"].HeaderText = "Ciudad:";
            dataGridView1.Columns["Region"].HeaderText = "Region:";
            dataGridView1.Columns["PostalCode"].HeaderText = "Codigo Postal:";
            dataGridView1.Columns["Country"].HeaderText = "Pais:";
            dataGridView1.Columns["Phone"].HeaderText = "Numero de telefono:";
            dataGridView1.Columns["Fax"].HeaderText = "Fax:";
            dataGridView1.Columns["HomePage"].HeaderText = "Home Page:";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formTnstance = new AgregarSuplidorDialog(isuplidorService, logger, isuplidoresCRUD);
            formTnstance.ShowDialog();
            btnReset.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar el suplidor?, no vayas a poner un huevo!",
                    "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var suplidorCRUD = new suplidoresCRUD();

                    bool exito = suplidorCRUD.EliminarSuplidor(id);

                    if (exito)
                    {
                        MessageBox.Show("Suplidor eliminado con éxito, despues no me vengas llorando!", "Eliminar suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView1.DataSource = isuplidoresCRUD.ObtenerSuplidores();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el suplidorr.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un suplidor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = isuplidoresCRUD.ObtenerSuplidores();
            btnReset.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string suplidorName = dataGridView1.SelectedRows[0].Cells["CompanyName"].Value.ToString();
                var actualizar = new ActualizarSuplidorDialog(isuplidorService, logger, isuplidoresCRUD);
                actualizar.Tag = suplidorName;
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
