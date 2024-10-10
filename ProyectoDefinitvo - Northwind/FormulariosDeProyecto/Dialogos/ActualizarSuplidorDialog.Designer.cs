namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    partial class ActualizarSuplidorDialog
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
            txtRegion = new TextBox();
            txtFax = new TextBox();
            txtTelefono = new MaskedTextBox();
            txtCodigoPostal = new MaskedTextBox();
            cbxCiudad = new ComboBox();
            cbxPais = new ComboBox();
            cbxPuestoRepresentante = new ComboBox();
            label11 = new Label();
            txtHomepage = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtDireccion = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtRepresentante = new TextBox();
            label1 = new Label();
            txtNombre = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label12 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // txtRegion
            // 
            txtRegion.Location = new Point(63, 425);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(187, 23);
            txtRegion.TabIndex = 53;
            // 
            // txtFax
            // 
            txtFax.Location = new Point(63, 589);
            txtFax.Name = "txtFax";
            txtFax.Size = new Size(187, 23);
            txtFax.TabIndex = 52;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(63, 536);
            txtTelefono.Mask = "000-000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(83, 23);
            txtTelefono.TabIndex = 51;
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(63, 482);
            txtCodigoPostal.Mask = "00-0000";
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(47, 23);
            txtCodigoPostal.TabIndex = 50;
            // 
            // cbxCiudad
            // 
            cbxCiudad.FormattingEnabled = true;
            cbxCiudad.Location = new Point(62, 371);
            cbxCiudad.Name = "cbxCiudad";
            cbxCiudad.Size = new Size(187, 23);
            cbxCiudad.TabIndex = 49;
            // 
            // cbxPais
            // 
            cbxPais.FormattingEnabled = true;
            cbxPais.Location = new Point(63, 313);
            cbxPais.Name = "cbxPais";
            cbxPais.Size = new Size(187, 23);
            cbxPais.TabIndex = 48;
            // 
            // cbxPuestoRepresentante
            // 
            cbxPuestoRepresentante.FormattingEnabled = true;
            cbxPuestoRepresentante.Items.AddRange(new object[] { "Purchasing Manager", "Order Administrator", "Marketing Manager", "Sales Representative", "Export Administrator", "Sales Agent", "International Marketing Mgr.", "Coordinator Foreign Markets", "Regional Account Rep.", "Wholesale Account Agent", "Owner", "Accounting Manager", "Product Manager", "Order Administrator", "Sales Manager" });
            cbxPuestoRepresentante.Location = new Point(63, 201);
            cbxPuestoRepresentante.Name = "cbxPuestoRepresentante";
            cbxPuestoRepresentante.Size = new Size(187, 23);
            cbxPuestoRepresentante.TabIndex = 47;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(63, 619);
            label11.Name = "label11";
            label11.Size = new Size(129, 15);
            label11.TabIndex = 46;
            label11.Text = "Home Page: (opcional)";
            // 
            // txtHomepage
            // 
            txtHomepage.Location = new Point(63, 641);
            txtHomepage.Name = "txtHomepage";
            txtHomepage.Size = new Size(187, 23);
            txtHomepage.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(63, 571);
            label10.Name = "label10";
            label10.Size = new Size(85, 15);
            label10.TabIndex = 44;
            label10.Text = "Fax: (opcional)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(62, 464);
            label9.Name = "label9";
            label9.Size = new Size(84, 15);
            label9.TabIndex = 43;
            label9.Text = "Codigo Postal:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(63, 518);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 42;
            label8.Text = "Telefono:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(63, 295);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 41;
            label7.Text = "Pais:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(63, 407);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 40;
            label6.Text = "Region: (opcional)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 238);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 39;
            label5.Text = "Direccion:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 353);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 38;
            label4.Text = "Ciudad:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(64, 256);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(187, 23);
            txtDireccion.TabIndex = 37;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 183);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 36;
            label3.Text = "Puesto de representante:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 128);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 35;
            label2.Text = "Nombre de representante:";
            // 
            // txtRepresentante
            // 
            txtRepresentante.Location = new Point(63, 146);
            txtRepresentante.Name = "txtRepresentante";
            txtRepresentante.Size = new Size(187, 23);
            txtRepresentante.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 72);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 33;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(63, 90);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(187, 23);
            txtNombre.TabIndex = 32;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.LimeGreen;
            btnAceptar.Location = new Point(170, 682);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(156, 41);
            btnAceptar.TabIndex = 31;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.OrangeRed;
            btnCancelar.Location = new Point(8, 682);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(156, 41);
            btnCancelar.TabIndex = 30;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(62, 19);
            label12.Name = "label12";
            label12.Size = new Size(20, 15);
            label12.TabIndex = 55;
            label12.Text = "Id:";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(62, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(32, 23);
            textBox1.TabIndex = 54;
            // 
            // ActualizarSuplidorDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(335, 734);
            ControlBox = false;
            Controls.Add(label12);
            Controls.Add(textBox1);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ActualizarSuplidorDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Actualizar suplidor";
            Load += ActualizarSuplidorDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRegion;
        private TextBox txtFax;
        private MaskedTextBox txtTelefono;
        private MaskedTextBox txtCodigoPostal;
        private ComboBox cbxCiudad;
        private ComboBox cbxPais;
        private ComboBox cbxPuestoRepresentante;
        private Label label11;
        private TextBox txtHomepage;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtDireccion;
        private Label label3;
        private Label label2;
        private TextBox txtRepresentante;
        private Label label1;
        private TextBox txtNombre;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label12;
        private TextBox textBox1;
    }
}