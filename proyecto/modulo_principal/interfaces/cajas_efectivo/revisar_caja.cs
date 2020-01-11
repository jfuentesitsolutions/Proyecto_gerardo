using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conexiones_BD.clases;

namespace interfaces.cajas_efectivo
{
    public partial class revisar_caja : Form
    {
        string idcaja;
        DataTable datos;
        bool cerrada = false;
        string total = "0";
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        conexiones_BD.clases.cajas caja;
        public revisar_caja()
        {
            InitializeComponent();
        }

        public string Idcaja
        {
            get
            {
                return idcaja;
            }

            set
            {
                idcaja = value;
            }
        }

        public cajas Caja
        {
            get
            {
                return caja;
            }

            set
            {
                caja = value;
            }
        }

        public bool Cerrada
        {
            get
            {
                return cerrada;
            }

            set
            {
                cerrada = value;
            }
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

        private void colocandoDatos()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            datos = op.datoscaja(Convert.ToInt32(idcaja));
            

            if (datos.Rows.Count>0)
            {
                lblVentaT.Text = "$" + datos.Rows[0][0].ToString();
                lblVentaF.Text = "$" + datos.Rows[0][1].ToString();
                lblAnulacion.Text = "$" + datos.Rows[0][2].ToString();
                lblAnula_Compras.Text = "$" + datos.Rows[0][3].ToString();
                lblGastoOpe.Text = "$" + datos.Rows[0][4].ToString();
                lblCompra.Text = "$" + datos.Rows[0][5].ToString();
                calculandoTotal();
                lblTota.Text = "$" + total;
                lblGanan.Text = "$" + datos.Rows[0][6].ToString();
            }
        }

        private void calculandoTotal()
        {
            if (datos.Rows.Count>0)
            {
                double vt = Convert.ToDouble(datos.Rows[0][0]);
                double vf = Convert.ToDouble(datos.Rows[0][1]);
                double com = Convert.ToDouble(datos.Rows[0][5]);
                double gas = Convert.ToDouble(datos.Rows[0][4]);

                double total = ((vt + vf) - (com + gas));

                this.total = total.ToString();
            }
        }

        private void revisar_caja_Load(object sender, EventArgs e)
        {
            colocandoDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Desea imprimir un reporte de corte despues de cerrar la caja?", "Cerrar caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (cerrandoCaja())
                {
                    sesion.Caja_activa = false;
                    this.cerrada = true;
                    this.Close();
                }else
                {
                    sesion.Caja_activa = true;
                    this.cerrada = false;
                }
            }
            else
            {
                if (cerrandoCaja())
                {
                    sesion.Caja_activa = false;
                    this.cerrada = true;
                    this.Close();
                }
                else
                {
                    sesion.Caja_activa = true;
                    this.cerrada = false;
                }
            }
        }

        private bool cerrandoCaja()
        {
            DateTime fecha_hora;
            fecha_hora = DateTime.Now;
            caja.Fecha_c = fecha_hora.ToString("yyyy-MM-dd hh:mm:ss");
            caja.Estado = "2";
            cortes_diarios cd = new cortes_diarios(total,
                datos.Rows[0][2].ToString(),
                datos.Rows[0][6].ToString(),
                sesion.Datos[6],
                datos.Rows[0][4].ToString(),
                idcaja,
                datos.Rows[0][0].ToString(),
                datos.Rows[0][1].ToString(),
                datos.Rows[0][5].ToString(),
                datos.Rows[0][3].ToString()
                );

            cortes_sucursales cs = new cortes_sucursales(sesion.DatosRegistro[1],
                "", fecha_hora.ToString("yyyy-MM-dd hh:mm:ss"));

            conexiones_BD.operaciones op = new conexiones_BD.operaciones();

            if (op.transaccionCajasCortes(caja, cd, cs) > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("No pudimos cerrar la caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
