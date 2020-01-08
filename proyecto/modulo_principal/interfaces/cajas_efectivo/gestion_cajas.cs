using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.cajas_efectivo
{
    public partial class Imagenes : Form
    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        string idcaja="0";
        public Imagenes()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Imagenes_Load(object sender, EventArgs e)
        {
            this.colocandoCajasActivas();
        }

        private void colocandoCajasActivas()
        {
            DataTable cajas = conexiones_BD.clases.cajas.datosTabla(sesion.DatosRegistro[6]);
            if (cajas.Rows.Count==1)
            {
               ListViewGroup grupo1 = new ListViewGroup("Cajas abiertas", HorizontalAlignment.Center);
                lista_cajas.Groups.Add(grupo1);
                lista_cajas.LargeImageList = lista_imagenes;
                lista_cajas.Items.Add(new ListViewItem(cajas.Rows[0][4].ToString(),0, grupo1));
                lblNombre.Text = cajas.Rows[0][4].ToString();
                efectivo_inicial.Value = Convert.ToDecimal(cajas.Rows[0][5].ToString());
                idcaja = cajas.Rows[0][0].ToString();
                efectivo_inicial.ReadOnly = true;
                btnAbrir.Enabled = false;
            }
            else if(cajas.Rows.Count==0)
            {
                btnCerrar.Enabled = false;
                btnRevisar.Enabled = false;
                efectivo_inicial.ReadOnly = false;
                lblNombre.Text = sesion.DatosRegistro[6];

            }
            else if (cajas.Rows.Count > 1)
            {
                MessageBox.Show("Hemos detectado mas de una caja con el mismo nombre.\nPorfavor elimine una", "Caja duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lista_cajas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fech = DateTime.Now;

            string hola = lista_cajas.SelectedItems[0].Text;
            MessageBox.Show(fech.ToString("yyyy-MM-dd hh:mm:ss"));
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }
    }
}
