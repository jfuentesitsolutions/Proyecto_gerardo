using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace interfaces.ventas.auxiliares
{
    public partial class busquedaArticulos : Form
    {
        utilitarios.cargar_tablas tabla;
        DataTable docu=null;
        bool elegido = false;
        string idventa_tic = null;
        Action accion;
        sessionManager.secion sesion = sessionManager.secion.Instancia;

        public DataTable Docu
        {
            get
            {
                return docu;
            }

            set
            {
                docu = value;
            }
        }

        public bool Elegido
        {
            get
            {
                return elegido;
            }

            set
            {
                elegido = value;
            }
        }

        public string Idventa_tic
        {
            get
            {
                return idventa_tic;
            }

            set
            {
                idventa_tic = value;
            }
        }

        public busquedaArticulos()
        {
            InitializeComponent();
        }

        private void cargarTodo()
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            listaDocumentos.SelectedIndex = 0;
            cargarTablas();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void busquedaArticulos_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(creandoAccion);
            t.Start();
        }

        private void creandoAccion()
        {
            accion = cargarTodo;
            if (InvokeRequired)
            {
                Invoke(accion);
            }
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void cargarTablas()
        {
            if (listaDocumentos.SelectedIndex == 0)
            {
                utilitarios.maneja_fechas fe = new utilitarios.maneja_fechas();
                tabla = new utilitarios.cargar_tablas(tablaDocumentos, txtBuscar, conexiones_BD.clases.ventas.tickets.datosTabla(fe.fechaCortaMysql(fecha), sesion.DatosRegistro[1]), "correlativo");
                tabla.cargarSinContadorRegistros();
            } else
            {
                tablaDocumentos.DataSource = null;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void listaDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTablas();
        }

        private void tablaDocumentos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                docu = conexiones_BD.clases.ventas.detalles_productos_venta_ticket.detalle_proTic(tablaDocumentos.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                docu = null;
            }

            if (docu != null)
            {
                elegido = true;
                idventa_tic = tablaDocumentos.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            cargarTablas();
        }
    }
}
