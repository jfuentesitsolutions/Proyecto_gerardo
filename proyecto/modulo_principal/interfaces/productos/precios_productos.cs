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
        utilitarios.cargar_tablas tabla;
        DataTable marca, categoria, estantes;
        DataTable productos;

        public DataTable Productos
        {
            get
            {
                return productos;
            }

            set
            {
                productos = value;
            }
        }

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
            cargarTablas(false);
        }

        private void cargarTablas(bool actuali)
        {
            tabla = new utilitarios.cargar_tablas(tablad, txtBusqueda, productos, "productoCod");
            tabla.cargarSinContadorRegistros();

            /*if (!actuali)
            {
                cargarListas();
            }*/
            
        }

        private void cargarListas()
        {
            marca = conexiones_BD.clases.marcas.datosTabla();
            categoria = conexiones_BD.clases.categorias.datosTabla();
            estantes = conexiones_BD.clases.estantes.datosTabla();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {         
                    tablad.Focus();
                
            } else if (e.KeyCode== Keys.Enter)
            {
                this.cargarDatos();
            }
        }

        private void tablad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBusqueda.Focus();
            }else if(e.KeyCode == Keys.Enter){
                this.cargarDatos();
            }
        }

        private void tablad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void cargarDatos()
        {
            if (tablad.Rows.Count != 0)
            {
                producto pr = new producto();
                pr.txtCodigo.Text = tablad.CurrentRow.Cells[1].Value.ToString();
                pr.txtNombre.Text = tablad.CurrentRow.Cells[2].Value.ToString();
                pr.existencia.Value = Convert.ToDecimal(tablad.CurrentRow.Cells[6].Value.ToString());

                utilitarios.cargandoListas.cargarLista(marca, pr.listaMarca, "nombre", "idmarca");
                utilitarios.cargandoListas.establecerValor(pr.listaMarca, tablad.CurrentRow.Cells[15].Value.ToString());
                utilitarios.cargandoListas.cargarLista(categoria, pr.listaCategoria, "nombre_categoria", "idcategoria");
                utilitarios.cargandoListas.establecerValor(pr.listaCategoria, tablad.CurrentRow.Cells[16].Value.ToString());
                utilitarios.cargandoListas.cargarLista(estantes, pr.listaEstante, "nombre", "idestante");
                if (!tablad.CurrentRow.Cells[17].Value.ToString().Equals(""))
                {
                    utilitarios.cargandoListas.establecerValor(pr.listaEstante, tablad.CurrentRow.Cells[17].Value.ToString());
                }
                if (tablad.CurrentRow.Cells[18].Value.ToString().Equals("SI"))
                {
                    pr.chkKardex.Checked = true;
                }
                if (!tablad.CurrentRow.Cells[19].Value.ToString().Equals(""))
                {
                    pr.fecha.Value = Convert.ToDateTime(tablad.CurrentRow.Cells[19].Value.ToString());
                }
                

                pr.Idsuc_produ = tablad.CurrentRow.Cells[0].Value.ToString();
                pr.Idproducto = tablad.CurrentRow.Cells[14].Value.ToString();

                pr.Utili_m = tablad.CurrentRow.Cells[20].Value.ToString();
                pr.Utili_d = tablad.CurrentRow.Cells[21].Value.ToString();
                pr.Pv = tablad.CurrentRow.Cells[22].Value.ToString();
                pr.Pc = tablad.CurrentRow.Cells[23].Value.ToString();
                pr.Pvm = tablad.CurrentRow.Cells[24].Value.ToString();
                pr.Pcm = tablad.CurrentRow.Cells[25].Value.ToString();


                pr.ShowDialog();
                txtBusqueda.Focus();
                if (tablad.Rows.Count != 0)
                {
                    tablad.CurrentCell = tablad.Rows[0].Cells[1];
                }

                if (pr.Actualiza)
                {
                    cargarTablas(true);
                }
            }
            else
            {
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
                
            }     
        }


    }
}
