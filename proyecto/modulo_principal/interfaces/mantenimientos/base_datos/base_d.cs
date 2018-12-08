using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.mantenimientos.base_datos
{
    public partial class base_d : Form
    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        public base_d()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void base_d_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            guardar.ShowDialog();
            
        }

        private void guardar_FileOk(object sender, CancelEventArgs e)
        {
            string name = guardar.FileName;
            txtRuta.Text = name;
        }

        private void btnRespaldar_Click(object sender, EventArgs e)
        {
            if (txtRuta.TextLength!=0)
            {
                conexiones_BD.Conexion con = new conexiones_BD.Conexion();
                if (con.exportar(txtRuta.Text))
                {
                    lblRespuesta.Text = "La base se respaldo con éxito";
                    lblRespuesta.ForeColor = Color.Green;
                    txtRuta.Text = "";
                }
                else
                {
                    lblRespuesta.Text = "Ocurrio algun error durante el respaldo";
                    lblRespuesta.ForeColor = Color.Red;
                }
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscar.ShowDialog();
        }

        private void buscar_FileOk(object sender, CancelEventArgs e)
        {
            string name = buscar.FileName;
            txtBu.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBu.TextLength != 0)
            {
                conexiones_BD.Conexion con = new conexiones_BD.Conexion();
                if (con.importar(txtBu.Text))
                {
                    lblres.Text = "La base se importo con éxito";
                    lblres.ForeColor = Color.Green;
                    txtBu.Text="";
                }
                else
                {
                    lblres.Text = "Ocurrio algun error durante la importación";
                    lblres.ForeColor = Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
