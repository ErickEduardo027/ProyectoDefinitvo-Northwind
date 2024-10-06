namespace ProyectoDefinitvo___Northwind
{
    partial class mainMenu
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
            panelMenu = new Panel();
            button3 = new Button();
            btnSuplidores = new Button();
            btnCategorias = new Button();
            btnProductos = new Button();
            panelLogo = new Panel();
            label1 = new Label();
            panelTitulo = new Panel();
            btnCerrarFormularios = new Button();
            lblTitulo = new Label();
            panelEscritorio = new Panel();
            pictureBox1 = new PictureBox();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitulo.SuspendLayout();
            panelEscritorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(btnSuplidores);
            panelMenu.Controls.Add(btnCategorias);
            panelMenu.Controls.Add(btnProductos);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 688);
            panelMenu.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.Teal;
            button3.Dock = DockStyle.Bottom;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Image = Properties.Resources.salida__1_;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 628);
            button3.Name = "button3";
            button3.Padding = new Padding(12, 0, 0, 0);
            button3.Size = new Size(220, 60);
            button3.TabIndex = 4;
            button3.Text = "   Log out";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btnSuplidores
            // 
            btnSuplidores.Dock = DockStyle.Top;
            btnSuplidores.FlatAppearance.BorderSize = 0;
            btnSuplidores.FlatStyle = FlatStyle.Flat;
            btnSuplidores.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSuplidores.ForeColor = SystemColors.ButtonHighlight;
            btnSuplidores.Image = Properties.Resources.caja;
            btnSuplidores.ImageAlign = ContentAlignment.MiddleLeft;
            btnSuplidores.Location = new Point(0, 200);
            btnSuplidores.Name = "btnSuplidores";
            btnSuplidores.Padding = new Padding(12, 0, 0, 0);
            btnSuplidores.Size = new Size(220, 60);
            btnSuplidores.TabIndex = 3;
            btnSuplidores.Text = "   Suplidores";
            btnSuplidores.TextAlign = ContentAlignment.MiddleLeft;
            btnSuplidores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSuplidores.UseVisualStyleBackColor = true;
            btnSuplidores.Click += btnSuplidores_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCategorias.ForeColor = SystemColors.ButtonHighlight;
            btnCategorias.Image = Properties.Resources.categorias;
            btnCategorias.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategorias.Location = new Point(0, 140);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new Padding(12, 0, 0, 0);
            btnCategorias.Size = new Size(220, 60);
            btnCategorias.TabIndex = 2;
            btnCategorias.Text = "   Categorias";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProductos.ForeColor = SystemColors.ButtonHighlight;
            btnProductos.Image = Properties.Resources.agregar;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(0, 80);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(12, 0, 0, 0);
            btnProductos.Size = new Size(220, 60);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "   Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(label1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(73, 33);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido!";
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(0, 150, 136);
            panelTitulo.Controls.Add(btnCerrarFormularios);
            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(220, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(958, 80);
            panelTitulo.TabIndex = 1;
            // 
            // btnCerrarFormularios
            // 
            btnCerrarFormularios.FlatAppearance.BorderSize = 0;
            btnCerrarFormularios.FlatStyle = FlatStyle.Flat;
            btnCerrarFormularios.Image = Properties.Resources.hogar__1_;
            btnCerrarFormularios.Location = new Point(6, 8);
            btnCerrarFormularios.Name = "btnCerrarFormularios";
            btnCerrarFormularios.Size = new Size(67, 65);
            btnCerrarFormularios.TabIndex = 1;
            btnCerrarFormularios.UseVisualStyleBackColor = true;
            btnCerrarFormularios.Click += btnCerrarFormularios_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(424, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(127, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DASHBOARD";
            // 
            // panelEscritorio
            // 
            panelEscritorio.Controls.Add(pictureBox1);
            panelEscritorio.Dock = DockStyle.Fill;
            panelEscritorio.Location = new Point(220, 80);
            panelEscritorio.Name = "panelEscritorio";
            panelEscritorio.Size = new Size(958, 608);
            panelEscritorio.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(292, 131);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(404, 301);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 688);
            Controls.Add(panelEscritorio);
            Controls.Add(panelTitulo);
            Controls.Add(panelMenu);
            MinimumSize = new Size(950, 500);
            Name = "mainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenu";
            WindowState = FormWindowState.Maximized;
            Load += mainMenu_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            panelEscritorio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnProductos;
        private Panel panelLogo;
        private Button button3;
        private Button btnSuplidores;
        private Button btnCategorias;
        private Panel panelTitulo;
        private Label lblTitulo;
        private Label label1;
        private Panel panelEscritorio;
        private Button btnCerrarFormularios;
        private PictureBox pictureBox1;
    }
}