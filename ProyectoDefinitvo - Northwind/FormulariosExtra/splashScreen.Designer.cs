namespace ProyectoDefinitvo___Northwind
{
    partial class splashScreen
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ProgressBar1 = new CircularProgressBar_NET5.CircularProgressBar();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProgressBar1
            // 
            ProgressBar1.AnimationFunction = WinFormAnimation_NET5.KnownAnimationFunctions.Linear;
            ProgressBar1.AnimationSpeed = 500;
            ProgressBar1.BackColor = Color.Transparent;
            ProgressBar1.Font = new Font("Segoe UI", 72F, FontStyle.Bold);
            ProgressBar1.ForeColor = Color.FromArgb(64, 64, 64);
            ProgressBar1.InnerColor = Color.FromArgb(42, 40, 60);
            ProgressBar1.InnerMargin = 2;
            ProgressBar1.InnerWidth = -1;
            ProgressBar1.Location = new Point(21, 70);
            ProgressBar1.MarqueeAnimationSpeed = 2000;
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.OuterColor = Color.FromArgb(28, 26, 43);
            ProgressBar1.OuterMargin = -25;
            ProgressBar1.OuterWidth = 26;
            ProgressBar1.ProgressColor = Color.Cyan;
            ProgressBar1.ProgressWidth = 15;
            ProgressBar1.SecondaryFont = new Font("Segoe UI", 36F);
            ProgressBar1.Size = new Size(341, 314);
            ProgressBar1.StartAngle = 270;
            ProgressBar1.Style = ProgressBarStyle.Continuous;
            ProgressBar1.SubscriptColor = Color.FromArgb(166, 166, 166);
            ProgressBar1.SubscriptMargin = new Padding(10, -35, 0, 0);
            ProgressBar1.SubscriptText = "";
            ProgressBar1.SuperscriptColor = Color.FromArgb(166, 166, 166);
            ProgressBar1.SuperscriptMargin = new Padding(10, 35, 0, 0);
            ProgressBar1.SuperscriptText = "";
            ProgressBar1.TabIndex = 0;
            ProgressBar1.TextMargin = new Padding(8, 8, 0, 0);
            ProgressBar1.Value = 68;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 27.75F, FontStyle.Bold);
            label1.Location = new Point(98, 19);
            label1.Name = "label1";
            label1.Size = new Size(190, 38);
            label1.TabIndex = 1;
            label1.Text = "Northwind";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(42, 40, 60);
            pictureBox1.Image = Properties.Resources.Imagen2;
            pictureBox1.Location = new Point(84, 133);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(214, 190);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(118, 401);
            label2.Name = "label2";
            label2.Size = new Size(149, 26);
            label2.TabIndex = 3;
            label2.Text = "Cargando...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 446);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 4;
            label3.Text = "Copyright© elerikDev";
            // 
            // splashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(382, 471);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(ProgressBar1);
            Cursor = Cursors.WaitCursor;
            FormBorderStyle = FormBorderStyle.None;
            Name = "splashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "splashScreen";
            Load += splashScreen_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private CircularProgressBar_NET5.CircularProgressBar ProgressBar1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
    }
}