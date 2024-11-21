namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    partial class DobleClickDetalle
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
            dataGridView2 = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Discount = new DataGridViewTextBoxColumn();
            ProductCategoryName = new DataGridViewTextBoxColumn();
            ProductSupplierCompanyName = new DataGridViewTextBoxColumn();
            ExtendedPrice = new DataGridViewTextBoxColumn();
            label1 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView2.BackgroundColor = Color.Teal;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ProductName, UnitPrice, Quantity, Discount, ProductCategoryName, ProductSupplierCompanyName, ExtendedPrice });
            dataGridView2.GridColor = Color.FromArgb(0, 0, 192);
            dataGridView2.Location = new Point(12, 86);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(745, 421);
            dataGridView2.TabIndex = 34;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Nombre de producto:";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "Precio por unidad:";
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Cantidad del producto:";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Discount
            // 
            Discount.HeaderText = "Descuento";
            Discount.Name = "Discount";
            Discount.ReadOnly = true;
            // 
            // ProductCategoryName
            // 
            ProductCategoryName.HeaderText = "Categoria del producto:";
            ProductCategoryName.Name = "ProductCategoryName";
            ProductCategoryName.ReadOnly = true;
            // 
            // ProductSupplierCompanyName
            // 
            ProductSupplierCompanyName.HeaderText = "Suplidor del produto:";
            ProductSupplierCompanyName.Name = "ProductSupplierCompanyName";
            ProductSupplierCompanyName.ReadOnly = true;
            // 
            // ExtendedPrice
            // 
            ExtendedPrice.HeaderText = "Extended Price:";
            ExtendedPrice.Name = "ExtendedPrice";
            ExtendedPrice.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(406, 35);
            label1.Name = "label1";
            label1.Size = new Size(249, 32);
            label1.TabIndex = 35;
            label1.Text = "Detalles de la orden:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(657, 44);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 36;
            // 
            // DobleClickDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(769, 522);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DobleClickDetalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalles de la orden";
            Load += DobleClickDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Discount;
        private DataGridViewTextBoxColumn ProductCategoryName;
        private DataGridViewTextBoxColumn ProductSupplierCompanyName;
        private DataGridViewTextBoxColumn ExtendedPrice;
        private Label label1;
        private TextBox textBox1;
    }
}