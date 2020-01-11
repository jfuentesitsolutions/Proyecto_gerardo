using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexiones_BD.clases
{
    public class cortes_diarios:entidad
    {
        string idcorte, total, total_anulado, 
            total_ganan, idusu, gastos_ope, 
            idca, totavtic, totalvf, total_com, total_c_anulado;

        public cortes_diarios(string total, 
            string total_anulado, 
            string total_ganan, 
            string idusu, 
            string gastos_ope, 
            string idca, 
            string totavtic, 
            string totalvf, 
            string total_com, 
            string tca)
        {
            this.total = total;
            this.total_anulado = total_anulado;
            this.total_ganan = total_ganan;
            this.idusu = idusu;
            this.gastos_ope = gastos_ope;
            this.idca = idca;
            this.totavtic = totavtic;
            this.totalvf = totalvf;
            this.total_com = total_com;
            this.total_c_anulado = tca;
            base.cargarDatos(generarCampos(), generarValores(), "cortes_diarios");
        }

        public override List<string> generarCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("total");
            campos.Add("total_ventas_anuladas");
            campos.Add("total_ganancia");
            campos.Add("idusuario");
            campos.Add("gastos_operativos");
            campos.Add("idcaja");
            campos.Add("total_ventas_tickets");
            campos.Add("total_ventas_facturas");
            campos.Add("total_compras");
            campos.Add("total_compras_anuladas");

            return campos;
        }

        public override List<string> generarValores()
        {
            List<string> valores = new List<string>();
            valores.Add(this.total);
            valores.Add(this.total_anulado);
            valores.Add(this.total_ganan);
            valores.Add(this.idusu);
            valores.Add(this.gastos_ope);
            valores.Add(this.idca);
            valores.Add(this.totavtic);
            valores.Add(this.totalvf);
            valores.Add(this.total_com);
            valores.Add(this.total_c_anulado);
            return valores;
        }
    }
}
