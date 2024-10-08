namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    partial class productosForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            UnitsInStock = new DataGridViewTextBoxColumn();
            UnitsOnOrder = new DataGridViewTextBoxColumn();
            ReorderLevel = new DataGridViewTextBoxColumn();
            Discontinued = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            QuantityPerUnit = new DataGridViewTextBoxColumn();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnAgregar = new Button();
            btnReset = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            btnfiltrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued, UnitPrice, QuantityPerUnit });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Location = new Point(12, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1012, 471);
            dataGridView1.TabIndex = 0;
            // 
            // ProductName
            // 
            ProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Nombre de producto:";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // UnitsInStock
            // 
            UnitsInStock.DataPropertyName = "UnitsInStock";
            UnitsInStock.HeaderText = "Unidades en almacen:";
            UnitsInStock.Name = "UnitsInStock";
            UnitsInStock.ReadOnly = true;
            // 
            // UnitsOnOrder
            // 
            UnitsOnOrder.DataPropertyName = "UnitsOnOrder";
            UnitsOnOrder.HeaderText = "Unidades pedidas:";
            UnitsOnOrder.Name = "UnitsOnOrder";
            UnitsOnOrder.ReadOnly = true;
            // 
            // ReorderLevel
            // 
            ReorderLevel.DataPropertyName = "ReorderLevel";
            ReorderLevel.HeaderText = "Nivel de reorden:";
            ReorderLevel.Name = "ReorderLevel";
            ReorderLevel.ReadOnly = true;
            // 
            // Discontinued
            // 
            Discontinued.DataPropertyName = "Discontinued";
            Discontinued.HeaderText = "Discontinued:";
            Discontinued.Name = "Discontinued";
            Discontinued.ReadOnly = true;
            // 
            // UnitPrice
            // 
            UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            UnitPrice.HeaderText = "Precio por unidad:";
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            // 
            // QuantityPerUnit
            // 
            QuantityPerUnit.DataPropertyName = "QuantityPerUnit";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            QuantityPerUnit.DefaultCellStyle = dataGridViewCellStyle2;
            QuantityPerUnit.HeaderText = "Cantidad por unidad:";
            QuantityPerUnit.Name = "QuantityPerUnit";
            QuantityPerUnit.ReadOnly = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(695, 550);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 45);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnActualizar.BackColor = Color.FromArgb(0, 192, 192);
            btnActualizar.Location = new Point(807, 550);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(106, 45);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAgregar.BackColor = Color.FromArgb(0, 192, 0);
            btnAgregar.Location = new Point(919, 550);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(106, 45);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.BackColor = Color.MediumOrchid;
            btnReset.Location = new Point(588, 550);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(101, 45);
            btnReset.TabIndex = 5;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nombre", "Suplidor", "Categoria" });
            comboBox1.Location = new Point(12, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(156, 23);
            comboBox1.TabIndex = 6;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 15);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 7;
            label1.Text = "Filtrar:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 15);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 8;
            label2.Text = "Ingrese el nombre del producto:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(185, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 23);
            textBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Nombre", "Categoria", "Suplidor" });
            comboBox2.Location = new Point(195, 34);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(156, 23);
            comboBox2.TabIndex = 10;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Nombre", "Categoria", "Suplidor" });
            comboBox3.Location = new Point(195, 33);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(156, 23);
            comboBox3.TabIndex = 11;
            // 
            // btnfiltrar
            // 
            btnfiltrar.BackColor = Color.FromArgb(255, 128, 0);
            btnfiltrar.Location = new Point(404, 13);
            btnfiltrar.Name = "btnfiltrar";
            btnfiltrar.Size = new Size(75, 52);
            btnfiltrar.TabIndex = 12;
            btnfiltrar.Text = "filtrar";
            btnfiltrar.UseVisualStyleBackColor = false;
            // 
            // productosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 607);
            Controls.Add(btnfiltrar);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(btnReset);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(dataGridView1);
            Name = "productosForm";
            Text = "PRODUCTOS";
            Load += productosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnAgregar;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn UnitsInStock;
        private DataGridViewTextBoxColumn UnitsOnOrder;
        private DataGridViewTextBoxColumn ReorderLevel;
        private DataGridViewTextBoxColumn Discontinued;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn QuantityPerUnit;
        private Button btnReset;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button btnfiltrar;
    }
}