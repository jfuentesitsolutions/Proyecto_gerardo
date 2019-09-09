using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace control_principal
{
    public partial class principal : Form
    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int msg, int wparam, int lparam);

        public principal()
        {
            InitializeComponent();

        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            this.slider();
            this.dibujarTitulo();
        }

        private void slider()
        {
            if (panelLateral.Width == 175)
            {
                panelLateral.Width = 57;

            }
            else
            {
                panelLateral.Width = 175;
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {

            if (btnInventario.Location==new Point(5,65))
            {
                this.funcionamientoBotones(0);
                this.panel_contenidos.Controls.RemoveAt(0);
                this.colocarPanel(new interfaces.panel_inicio.inicio());
            }
            else
            {
                this.funcionamientoBotones(1);
                this.panel_contenidos.Controls.RemoveAt(0);
                this.colocarPanel(new interfaces.paneles.inventarios());

            }

               
            
        }

        private void funcionamientoBotones(Int16 i)
        {
            switch (i)
            {
                case 0:
                    {
                        btnInventario.Location = new Point(0, 65);
                        btnVentas.Location = new Point(0, 127);
                        btncon.Location = new Point(0, 189);
                        btnrepo.Location = new Point(0, 251);
                        break;
                    }

                case 1:
                    {
                        btnInventario.Location = new Point(5,65);
                        btnVentas.Location = new Point(0,127);
                        btncon.Location = new Point(0, 189);
                        btnrepo.Location = new Point(0, 251);
                        break;
                    }
                case 2:
                    {
                        btnInventario.Location = new Point(0, 65);
                        btnVentas.Location = new Point(5, 127);
                        btncon.Location = new Point(0, 189);
                        btnrepo.Location = new Point(0, 251);
                        break;
                    }
                case 3:
                    {
                        btnInventario.Location = new Point(0, 65);
                        btnVentas.Location = new Point(0, 127);
                        btncon.Location = new Point(5, 189);
                        btnrepo.Location = new Point(0, 251);
                        break;
                    }
                case 4:
                    {
                        btnInventario.Location = new Point(0, 65);
                        btnVentas.Location = new Point(0, 127);
                        btncon.Location = new Point(0, 189);
                        btnrepo.Location = new Point(5, 251);
                        break;
                    }
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (btnVentas.Location == new Point(5, 127))
            {
                this.funcionamientoBotones(0);
                this.panel_contenidos.Controls.RemoveAt(0);
                this.colocarPanel(new interfaces.panel_inicio.inicio());
            }
            else
            {
                this.funcionamientoBotones(2);
                this.panel_contenidos.Controls.RemoveAt(0);
                this.colocarPanel(new interfaces.paneles.negocio());
            }
        }

        private void btncon_Click(object sender, EventArgs e)
        {
            if (btncon.Location == new Point(5, 189))
            {
                this.funcionamientoBotones(0);
                if (this.panel_contenidos.Controls.Count > 0)
                {
                    this.panel_contenidos.Controls.RemoveAt(0);
                    this.colocarPanel(new interfaces.panel_inicio.inicio());
                }

            }
            else
            {
                this.funcionamientoBotones(3);
                if (this.panel_contenidos.Controls.Count > 0)
                {
                    this.panel_contenidos.Controls.RemoveAt(0);
                    this.colocarPanel(new interfaces.paneles.configuracion());
                }
            }
        }

        private void btnrepo_Click(object sender, EventArgs e)
        {
            if (btnrepo.Location == new Point(5, 251))
            {
                this.funcionamientoBotones(0);
            }
            else
            {
                this.funcionamientoBotones(4);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.dibujarTitulo();
            }else
            {
                this.WindowState = FormWindowState.Normal;
                this.dibujarTitulo();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012,0);
        }

        private void principal_Load(object sender, EventArgs e)
        {
            this.slider();
            this.colocarPanel(new interfaces.panel_inicio.inicio());
            this.dibujarTitulo();
        }

        private void colocarPanel(object formulario)
        {
            if (this.panel_contenidos.Controls.Count>0)
            {
                this.panel_contenidos.Controls.RemoveAt(0);
                
            }else
            {
                Form frm = formulario as Form;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                this.panel_contenidos.Controls.Add(frm);
                this.panel_contenidos.Tag = frm;
                frm.Show();
            }
        }

        private void inicio_Click(object sender, EventArgs e)
        {
            if (this.panel_contenidos.Controls.Count > 0)
            {
                this.panel_contenidos.Controls.RemoveAt(0);
                this.colocarPanel(new interfaces.panel_inicio.inicio());
            }
        }

        private void dibujarTitulo()
        {
            int posicion = (panelSuperior.Width / 2) - (lblTitulo.Width / 2);
            Point punto = new Point(posicion, 13);
            lblTitulo.Location = punto;
        }

        private void btnCerrarsesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", sesion.Datos[0], MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
