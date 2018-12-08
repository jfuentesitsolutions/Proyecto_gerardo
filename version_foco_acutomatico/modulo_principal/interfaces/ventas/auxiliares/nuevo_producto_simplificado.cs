using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.ventas.auxiliares
{
    public partial class nuevo_producto_simplificado : Form
    {
        conexiones_BD.clases.productos pro;
        conexiones_BD.clases.sucursales_productos sp;
        conexiones_BD.operaciones op;
        sessionManager.secion sesion = sessionManager.secion.Instancia;

        bool ingresado = false;

        public bool Ingresado
        {
            get
            {
                return ingresado;
            }

            set
            {
                ingresado = value;
            }
        }

        public nuevo_producto_simplificado()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevo_producto_simplificado_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);


        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.TextLength!=0)
            {
                if (!validarExistencias())
                {

                }
                else
                {
                    mantenimientos.procesos_iniciales.agregaPresentaciones ap = new mantenimientos.procesos_iniciales.agregaPresentaciones();
                    ap.Codigo = txtCodigo.Text;
                    ap.ShowDialog();
                    if (ap.IngresadoN)
                    {
                        ingresado = true;
                        this.Close();
                    }
                }
            }
            
        }

        private List<conexiones_BD.clases.proveedores_productos> generaProveedores()
        {
            List<conexiones_BD.clases.proveedores_productos> pro = new List<conexiones_BD.clases.proveedores_productos>();

            
                pro.Add(new conexiones_BD.clases.proveedores_productos("2", "0"));

            return pro;
        }

        private List<conexiones_BD.clases.presentaciones_productos> generaPresentaciones()
        {
            List<conexiones_BD.clases.presentaciones_productos> pp = new List<conexiones_BD.clases.presentaciones_productos>();

            
                pp.Add(new conexiones_BD.clases.presentaciones_productos("0", "1", "1", precio.Value.ToString(), "2"));
            

            return pp;
        }

        private bool validarExistencias()
        {
            List<string> campos = new List<string>();
            List<string> valores = new List<string>();
            bool valido = false;
            campos.Add("nom_producto");
            campos.Add("cod_producto");
            valores.Add(txtnombreP.Text);
            valores.Add(txtCodigo.Text);

            pro = new conexiones_BD.clases.productos(campos, valores);

            
                if (pro.validarCamposcondicorOR(true) > 0)
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            

            return valido;
        }

        private bool validar()
        {
            bool valido = false;
            error.Clear();
            string mensaje = "No puede quedar este campo en blanco";

            if (txtCodigo.TextLength == 0)
            {
                error.SetError(txtCodigo, mensaje);
                valido = true;
            }
            if (txtnombreP.TextLength == 0)
            {
                error.SetError(txtnombreP, mensaje);
                valido = true;
            }
            if (precio.Value == 0)
            {
                error.SetError(precio, mensaje);
                valido = true;
            }

            return valido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            utilitarios.maneja_fechas fe = new utilitarios.maneja_fechas();
            if (!validar())
            {
                pro = new conexiones_BD.clases.productos(
                        txtCodigo.Text,
                        txtnombreP.Text,
                        fe.fechaMysql(fecha),
                        "60",
                        "53");

                sp = new conexiones_BD.clases.sucursales_productos(
                        sesion.DatosRegistro[1],
                        "0",
                        "2",
                        "4",
                        "1",
                        "1000",
                        precio.Value.ToString(),
                        "0.0",
                        "0.0",
                        "0.0");

                op = new conexiones_BD.operaciones();
                if (op.transaccionProductos_Presentaciones_Proveedores(generaProveedores(), generaPresentaciones(), pro, sp) > 0)
                {
                    MessageBox.Show("El producto se ingreso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ingresado = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El producto no se pudo ingresar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
