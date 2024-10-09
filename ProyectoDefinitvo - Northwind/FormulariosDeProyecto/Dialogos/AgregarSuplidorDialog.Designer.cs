namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    partial class AgregarSuplidorDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtRepresentante = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtDireccion = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtHomepage = new TextBox();
            cbxPuestoRepresentante = new ComboBox();
            cbxPais = new ComboBox();
            cbxCiudad = new ComboBox();
            txtCodigoPostal = new MaskedTextBox();
            txtTelefono = new MaskedTextBox();
            txtFax = new TextBox();
            txtRegion = new TextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.LimeGreen;
            btnAceptar.Location = new Point(169, 683);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(156, 41);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.OrangeRed;
            btnCancelar.Location = new Point(7, 683);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(156, 41);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(62, 31);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(187, 23);
            txtNombre.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 13);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 5;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 64);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombre de representante:";
            // 
            // txtRepresentante
            // 
            txtRepresentante.Location = new Point(62, 82);
            txtRepresentante.Name = "txtRepresentante";
            txtRepresentante.Size = new Size(187, 23);
            txtRepresentante.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 119);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 9;
            label3.Text = "Puesto de representante:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 297);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 11;
            label4.Text = "Ciudad:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(62, 197);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(187, 23);
            txtDireccion.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 179);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 11;
            label5.Text = "Direccion:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(62, 359);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 13;
            label6.Text = "Region: (opcional)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(62, 236);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 15;
            label7.Text = "Pais:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(62, 477);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 17;
            label8.Text = "Telefono:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(61, 421);
            label9.Name = "label9";
            label9.Size = new Size(84, 15);
            label9.TabIndex = 17;
            label9.Text = "Codigo Postal:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(62, 536);
            label10.Name = "label10";
            label10.Size = new Size(85, 15);
            label10.TabIndex = 19;
            label10.Text = "Fax: (opcional)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(62, 597);
            label11.Name = "label11";
            label11.Size = new Size(129, 15);
            label11.TabIndex = 21;
            label11.Text = "Home Page: (opcional)";
            // 
            // txtHomepage
            // 
            txtHomepage.Location = new Point(62, 619);
            txtHomepage.Name = "txtHomepage";
            txtHomepage.Size = new Size(187, 23);
            txtHomepage.TabIndex = 20;
            // 
            // cbxPuestoRepresentante
            // 
            cbxPuestoRepresentante.FormattingEnabled = true;
            cbxPuestoRepresentante.Items.AddRange(new object[] { "Purchasing Manager", "Order Administrator", "Marketing Manager", "Sales Representative", "Export Administrator", "Sales Agent", "International Marketing Mgr.", "Coordinator Foreign Markets", "Regional Account Rep.", "Wholesale Account Agent", "Owner", "Accounting Manager", "Product Manager", "Order Administrator", "Sales Manager" });
            cbxPuestoRepresentante.Location = new Point(62, 137);
            cbxPuestoRepresentante.Name = "cbxPuestoRepresentante";
            cbxPuestoRepresentante.Size = new Size(187, 23);
            cbxPuestoRepresentante.TabIndex = 22;
            // 
            // cbxPais
            // 
            cbxPais.FormattingEnabled = true;
            cbxPais.Location = new Point(62, 254);
            cbxPais.Name = "cbxPais";
            cbxPais.Size = new Size(187, 23);
            cbxPais.TabIndex = 23;
            cbxPais.SelectedIndexChanged += cbxPais_SelectedIndexChanged;
            // 
            // cbxCiudad
            // 
            cbxCiudad.FormattingEnabled = true;
            cbxCiudad.Location = new Point(62, 315);
            cbxCiudad.Name = "cbxCiudad";
            cbxCiudad.Size = new Size(187, 23);
            cbxCiudad.TabIndex = 25;
            cbxCiudad.SelectedIndexChanged += cbxCiudad_SelectedIndexChanged;
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(62, 439);
            txtCodigoPostal.Mask = "00-0000";
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(47, 23);
            txtCodigoPostal.TabIndex = 26;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(62, 495);
            txtTelefono.Mask = "000-000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(72, 23);
            txtTelefono.TabIndex = 27;
            // 
            // txtFax
            // 
            txtFax.Location = new Point(62, 554);
            txtFax.Name = "txtFax";
            txtFax.Size = new Size(187, 23);
            txtFax.TabIndex = 28;
            // 
            // txtRegion
            // 
            txtRegion.Location = new Point(62, 377);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(187, 23);
            txtRegion.TabIndex = 29;
            // 
            // AgregarSuplidorDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(335, 734);
            Controls.Add(txtRegion);
            Controls.Add(txtFax);
            Controls.Add(txtTelefono);
            Controls.Add(txtCodigoPostal);
            Controls.Add(cbxCiudad);
            Controls.Add(cbxPais);
            Controls.Add(cbxPuestoRepresentante);
            Controls.Add(label11);
            Controls.Add(txtHomepage);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDireccion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtRepresentante);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Name = "AgregarSuplidorDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar suplidor";
            Load += AgregarSuplidorDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtNombre;
        private Label label1;
        private Label label2;
        private TextBox txtRepresentante;
        private Label label3;
        private Label label4;
        private TextBox txtDireccion;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox8;
        private Label label9;
        private Label label10;
        private TextBox textBox10;
        private Label label11;
        private TextBox txtHomepage;
        private ComboBox cbxPuestoRepresentante;
        private ComboBox cbxPais;
        private ComboBox cbxCiudad;
        private MaskedTextBox txtCodigoPostal;
        private MaskedTextBox txtTelefono;
        private TextBox txtFax;
        private TextBox txtRegion;
    }
}