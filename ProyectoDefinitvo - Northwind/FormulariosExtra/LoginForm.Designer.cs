namespace ProyectoDefinitvo___Northwind
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            btnSalir = new Button();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            btnIngresar = new Button();
            comboBox1 = new ComboBox();
            txtUsuario = new TextBox();
            MostrarContraseña = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            txtContraseña = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(585, 680);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1171, 42);
            panel1.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(540, 2);
            btnSalir.Margin = new Padding(0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(42, 36);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(5, 8);
            label1.Name = "label1";
            label1.Size = new Size(250, 25);
            label1.TabIndex = 0;
            label1.Text = "Northwind - Inicio de sesion";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.logo;
            pictureBox2.Location = new Point(135, 67);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(298, 264);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.None;
            btnIngresar.BackColor = Color.LimeGreen;
            btnIngresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(20, 238);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(188, 46);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.None;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Empleado" });
            comboBox1.Location = new Point(20, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 23);
            comboBox1.TabIndex = 4;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.None;
            txtUsuario.Location = new Point(20, 93);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(188, 23);
            txtUsuario.TabIndex = 6;
            // 
            // MostrarContraseña
            // 
            MostrarContraseña.Anchor = AnchorStyles.None;
            MostrarContraseña.AutoSize = true;
            MostrarContraseña.Location = new Point(83, 190);
            MostrarContraseña.Name = "MostrarContraseña";
            MostrarContraseña.Size = new Size(128, 19);
            MostrarContraseña.TabIndex = 7;
            MostrarContraseña.Text = "Mostrar contraseña";
            MostrarContraseña.UseVisualStyleBackColor = true;
            MostrarContraseña.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(18, 14);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 8;
            label2.Text = "Elige tu rol:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(18, 75);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 9;
            label3.Text = "Usuario:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(18, 143);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 10;
            label4.Text = "Contraseña:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(128, 255, 255);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtContraseña);
            panel2.Controls.Add(btnIngresar);
            panel2.Controls.Add(txtUsuario);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(MostrarContraseña);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(170, 345);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 296);
            panel2.TabIndex = 13;
            // 
            // txtContraseña
            // 
            txtContraseña.Anchor = AnchorStyles.None;
            txtContraseña.Location = new Point(20, 161);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(188, 23);
            txtContraseña.TabIndex = 11;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(585, 680);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnSalir;
        private Label label1;
        private PictureBox pictureBox2;
        private Button btnIngresar;
        private ComboBox comboBox1;
        private TextBox txtUsuario;
        private CheckBox MostrarContraseña;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel2;
        private TextBox txtContraseña;
        private ErrorProvider errorProvider1;
    }
}
