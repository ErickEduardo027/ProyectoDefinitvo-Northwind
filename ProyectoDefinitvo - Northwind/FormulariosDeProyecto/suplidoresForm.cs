﻿using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.productos;
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
    public partial class suplidoresForm : Form
    {
        public suplidoresForm()
        {
            InitializeComponent();
        }

        private void suplidoresForm_Load(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            var leer = new suplidoresCRUD();
            DataTable suplidores = leer.ObtenerSuplidores();
            dataGridView1.DataSource = suplidores;
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
            var formTnstance = new AgregarSuplidorDialog();
            formTnstance.ShowDialog();
            btnReset.Visible = true;
        }
    }
}
