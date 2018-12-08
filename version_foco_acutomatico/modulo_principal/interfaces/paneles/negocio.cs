using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.paneles
{
    public partial class negocio : Form
    {
        public negocio()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mantenimientos.procesos_iniciales.agregaPresentaciones ap = new mantenimientos.procesos_iniciales.agregaPresentaciones();
            ap.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mantenimientos.negocio.cambio_precios cp = new mantenimientos.negocio.cambio_precios();
            cp.ShowDialog();
        }

        private void btnAgregaPresentaciones_Click(object sender, EventArgs e)
        {
            ventas.ventas venta = new ventas.ventas();
            venta.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conexiones_BD.clases.ventas.tickets ticke = new conexiones_BD.clases.ventas.tickets(
            //    "1", "2", "2018-06-15", "5", "1", "1", "12", "3", "12.3", "0", "12", "1");

            //List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket> dep = new List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket>();
            //conexiones_BD.clases.ventas.detalles_productos_venta_ticket dp = new conexiones_BD.clases.ventas.detalles_productos_venta_ticket(
            //    "0", "21", "3", "1.50", "3", "0.15", "0");

            //dep.Add(dp);

            //conexiones_BD.operaciones op = new conexiones_BD.operaciones();

            //if (op.transaccionVentasTickets(dep, ticke) > 0)
            //{
            //    MessageBox.Show("Funciono");
            //}
            //else
            //{
            //    MessageBox.Show("No funciono");
            //}

        }
    }
}
