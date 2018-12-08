using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.productos
{
    public partial class precios_productos : Form
    {
        public precios_productos()
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

        private void precios_productos_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
        }
    }
}
