﻿namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto
{
    partial class OrdenesForm
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            btnFiltrarPorNombre = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            btnReset = new Button();
            comboBox3 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(971, 547);
            dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(153, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(70, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnFiltrarPorNombre
            // 
            btnFiltrarPorNombre.Location = new Point(280, 16);
            btnFiltrarPorNombre.Name = "btnFiltrarPorNombre";
            btnFiltrarPorNombre.Size = new Size(59, 46);
            btnFiltrarPorNombre.TabIndex = 2;
            btnFiltrarPorNombre.Text = "Filtrar";
            btnFiltrarPorNombre.UseVisualStyleBackColor = true;
            btnFiltrarPorNombre.Click += btnFiltrarPorNombre_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(864, 644);
            button2.Name = "button2";
            button2.Size = new Size(119, 43);
            button2.TabIndex = 3;
            button2.Text = "Crear Orden";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(739, 644);
            button3.Name = "button3";
            button3.Size = new Size(119, 43);
            button3.TabIndex = 4;
            button3.Text = "Actualizar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(614, 644);
            button4.Name = "button4";
            button4.Size = new Size(119, 43);
            button4.TabIndex = 5;
            button4.Text = "Eliminar";
            button4.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(345, 16);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(59, 46);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "ID" });
            comboBox3.Location = new Point(12, 34);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(94, 23);
            comboBox3.TabIndex = 12;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 16);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 13;
            label1.Text = "Filtrar:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 16);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 14;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(762, 32);
            label3.Name = "label3";
            label3.Size = new Size(221, 15);
            label3.TabIndex = 15;
            label3.Text = "doble click para ver el detalle de la orden";
            // 
            // OrdenesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 699);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox3);
            Controls.Add(btnReset);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnFiltrarPorNombre);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "OrdenesForm";
            Text = "ORDENES";
            Load += OrdenesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button btnFiltrarPorNombre;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button btnReset;
        private ComboBox comboBox3;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}