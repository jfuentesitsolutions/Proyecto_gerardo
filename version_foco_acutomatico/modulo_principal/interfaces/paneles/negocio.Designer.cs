namespace interfaces.paneles
{
    partial class negocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(negocio));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btVentas = new System.Windows.Forms.Panel();
            this.btnAgregaPresentaciones = new System.Windows.Forms.Button();
            this.btCompras = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btCam = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btCodigo = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btAgrepre = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.btVentas.SuspendLayout();
            this.btCompras.SuspendLayout();
            this.btCam.SuspendLayout();
            this.btCodigo.SuspendLayout();
            this.btAgrepre.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btVentas);
            this.flowLayoutPanel1.Controls.Add(this.btCompras);
            this.flowLayoutPanel1.Controls.Add(this.btCam);
            this.flowLayoutPanel1.Controls.Add(this.btCodigo);
            this.flowLayoutPanel1.Controls.Add(this.btAgrepre);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(622, 468);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btVentas
            // 
            this.btVentas.Controls.Add(this.btnAgregaPresentaciones);
            this.btVentas.Location = new System.Drawing.Point(10, 10);
            this.btVentas.Margin = new System.Windows.Forms.Padding(10);
            this.btVentas.Name = "btVentas";
            this.btVentas.Size = new System.Drawing.Size(159, 170);
            this.btVentas.TabIndex = 0;
            // 
            // btnAgregaPresentaciones
            // 
            this.btnAgregaPresentaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregaPresentaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregaPresentaciones.FlatAppearance.BorderSize = 0;
            this.btnAgregaPresentaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregaPresentaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregaPresentaciones.Image")));
            this.btnAgregaPresentaciones.Location = new System.Drawing.Point(0, 0);
            this.btnAgregaPresentaciones.Margin = new System.Windows.Forms.Padding(20);
            this.btnAgregaPresentaciones.Name = "btnAgregaPresentaciones";
            this.btnAgregaPresentaciones.Size = new System.Drawing.Size(159, 170);
            this.btnAgregaPresentaciones.TabIndex = 2;
            this.btnAgregaPresentaciones.Text = "Ventas";
            this.btnAgregaPresentaciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregaPresentaciones.UseVisualStyleBackColor = true;
            this.btnAgregaPresentaciones.Click += new System.EventHandler(this.btnAgregaPresentaciones_Click);
            // 
            // btCompras
            // 
            this.btCompras.Controls.Add(this.button1);
            this.btCompras.Location = new System.Drawing.Point(189, 10);
            this.btCompras.Margin = new System.Windows.Forms.Padding(10);
            this.btCompras.Name = "btCompras";
            this.btCompras.Size = new System.Drawing.Size(159, 170);
            this.btCompras.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 170);
            this.button1.TabIndex = 2;
            this.button1.Text = "Compras";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCam
            // 
            this.btCam.Controls.Add(this.button2);
            this.btCam.Location = new System.Drawing.Point(368, 10);
            this.btCam.Margin = new System.Windows.Forms.Padding(10);
            this.btCam.Name = "btCam";
            this.btCam.Size = new System.Drawing.Size(159, 170);
            this.btCam.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 170);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cambio de precios";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btCodigo
            // 
            this.btCodigo.Controls.Add(this.button3);
            this.btCodigo.Location = new System.Drawing.Point(10, 200);
            this.btCodigo.Margin = new System.Windows.Forms.Padding(10);
            this.btCodigo.Name = "btCodigo";
            this.btCodigo.Size = new System.Drawing.Size(159, 170);
            this.btCodigo.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 170);
            this.button3.TabIndex = 2;
            this.button3.Text = "Generación de codigos";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btAgrepre
            // 
            this.btAgrepre.Controls.Add(this.button4);
            this.btAgrepre.Location = new System.Drawing.Point(189, 200);
            this.btAgrepre.Margin = new System.Windows.Forms.Padding(10);
            this.btAgrepre.Name = "btAgrepre";
            this.btAgrepre.Size = new System.Drawing.Size(159, 170);
            this.btAgrepre.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 170);
            this.button4.TabIndex = 2;
            this.button4.Text = "Agregar presentaciones";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // negocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 468);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "negocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "negocio";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.btVentas.ResumeLayout(false);
            this.btCompras.ResumeLayout(false);
            this.btCam.ResumeLayout(false);
            this.btCodigo.ResumeLayout(false);
            this.btAgrepre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel btVentas;
        private System.Windows.Forms.Button btnAgregaPresentaciones;
        private System.Windows.Forms.Panel btCompras;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel btCam;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel btCodigo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel btAgrepre;
        private System.Windows.Forms.Button button4;
    }
}