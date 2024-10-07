namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    partial class AgregarProductoDialog
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtProductName = new TextBox();
            txtSupplierID = new TextBox();
            txtCategoryID = new TextBox();
            txtQuantityPerUnit = new TextBox();
            txtUnitPrice = new TextBox();
            txtUnitsInStock = new TextBox();
            txtUnitsOnOrder = new TextBox();
            txtReorderLevel = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            label9 = new Label();
            label10 = new Label();
            dataGridView2 = new DataGridView();
            cbxDiscontinued = new ComboBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.OrangeRed;
            btnCancelar.Location = new Point(8, 463);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(156, 41);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.LimeGreen;
            btnAceptar.Location = new Point(170, 463);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(156, 41);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(80, 45);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(215, 23);
            txtProductName.TabIndex = 2;
            // 
            // txtSupplierID
            // 
            txtSupplierID.Location = new Point(80, 92);
            txtSupplierID.Name = "txtSupplierID";
            txtSupplierID.Size = new Size(34, 23);
            txtSupplierID.TabIndex = 3;
            // 
            // txtCategoryID
            // 
            txtCategoryID.Location = new Point(80, 141);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.Size = new Size(34, 23);
            txtCategoryID.TabIndex = 4;
            // 
            // txtQuantityPerUnit
            // 
            txtQuantityPerUnit.Location = new Point(80, 185);
            txtQuantityPerUnit.Name = "txtQuantityPerUnit";
            txtQuantityPerUnit.Size = new Size(100, 23);
            txtQuantityPerUnit.TabIndex = 5;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(80, 232);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(100, 23);
            txtUnitPrice.TabIndex = 6;
            // 
            // txtUnitsInStock
            // 
            txtUnitsInStock.Location = new Point(80, 280);
            txtUnitsInStock.Name = "txtUnitsInStock";
            txtUnitsInStock.Size = new Size(100, 23);
            txtUnitsInStock.TabIndex = 7;
            // 
            // txtUnitsOnOrder
            // 
            txtUnitsOnOrder.Location = new Point(80, 328);
            txtUnitsOnOrder.Name = "txtUnitsOnOrder";
            txtUnitsOnOrder.Size = new Size(100, 23);
            txtUnitsOnOrder.TabIndex = 8;
            // 
            // txtReorderLevel
            // 
            txtReorderLevel.Location = new Point(80, 374);
            txtReorderLevel.Name = "txtReorderLevel";
            txtReorderLevel.Size = new Size(100, 23);
            txtReorderLevel.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 27);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 11;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 74);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 12;
            label2.Text = "Id de suplidor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 123);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 13;
            label3.Text = "Id de categoria:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 171);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 14;
            label4.Text = "Cantidad por unidad:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 214);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 15;
            label5.Text = "Precio por Unidad:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(79, 262);
            label6.Name = "label6";
            label6.Size = new Size(122, 15);
            label6.TabIndex = 16;
            label6.Text = "Unidades disponibles:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(80, 310);
            label7.Name = "label7";
            label7.Size = new Size(109, 15);
            label7.TabIndex = 17;
            label7.Text = "Unidades en orden:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(80, 358);
            label8.Name = "label8";
            label8.Size = new Size(97, 15);
            label8.TabIndex = 18;
            label8.Text = "Nivel de reorden:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(335, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(11, 511);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(346, 252);
            panel2.Name = "panel2";
            panel2.Size = new Size(576, 13);
            panel2.TabIndex = 20;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(353, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(564, 216);
            dataGridView1.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(353, 12);
            label9.Name = "label9";
            label9.Size = new Size(129, 15);
            label9.TabIndex = 22;
            label9.Text = "Categorias disponibles:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(353, 272);
            label10.Name = "label10";
            label10.Size = new Size(128, 15);
            label10.TabIndex = 24;
            label10.Text = "Suplidores disponibles:";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(353, 290);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(564, 214);
            dataGridView2.TabIndex = 23;
            // 
            // cbxDiscontinued
            // 
            cbxDiscontinued.FormattingEnabled = true;
            cbxDiscontinued.Items.AddRange(new object[] { "0", "1" });
            cbxDiscontinued.Location = new Point(80, 422);
            cbxDiscontinued.Name = "cbxDiscontinued";
            cbxDiscontinued.Size = new Size(120, 23);
            cbxDiscontinued.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(80, 404);
            label11.Name = "label11";
            label11.Size = new Size(80, 15);
            label11.TabIndex = 26;
            label11.Text = "Discontinued:";
            // 
            // AgregarProductoDialog
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = btnCancelar;
            ClientSize = new Size(923, 512);
            ControlBox = false;
            Controls.Add(label11);
            Controls.Add(cbxDiscontinued);
            Controls.Add(label10);
            Controls.Add(dataGridView2);
            Controls.Add(label9);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtReorderLevel);
            Controls.Add(txtUnitsOnOrder);
            Controls.Add(txtUnitsInStock);
            Controls.Add(txtUnitPrice);
            Controls.Add(txtQuantityPerUnit);
            Controls.Add(txtCategoryID);
            Controls.Add(txtSupplierID);
            Controls.Add(txtProductName);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarProductoDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = " ";
            Load += AgregarProductoDialog_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtProductName;
        private TextBox txtSupplierID;
        private TextBox txtCategoryID;
        private TextBox txtQuantityPerUnit;
        private TextBox txtUnitPrice;
        private TextBox txtUnitsInStock;
        private TextBox txtUnitsOnOrder;
        private TextBox txtReorderLevel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Label label9;
        private Label label10;
        private DataGridView dataGridView2;
        private ComboBox cbxDiscontinued;
        private Label label11;
    }
}