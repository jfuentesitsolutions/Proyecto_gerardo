using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace conexiones_BD.clases.ventas
{
    public abstract class ventas: entidad
    {
        protected string idventa, idDocu, fecha, idsucursal, anulacion;

        public ventas(string idventa, string idventa_ticket, string fecha, string idsucursal, string anulacion)
        {
            this.idventa = idventa;
            this.IdDocu = idventa_ticket;
            this.fecha = fecha;
            this.idsucursal = idsucursal;
            this.anulacion = anulacion; 
        }

        public string IdDocu
        {
            get
            {
                return idDocu;
            }

            set
            {
                idDocu = value;
            }
        }

        public abstract List<string> campos();

        public abstract List<string> valores();

        public string insertarVenta()
        {
            base.cargarDatos(campos(), valores(), "ventas");
            return base.sentenciaIngresar();
        }

        public static DataTable ventas_diarias(string fecha)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select concat('T',v.idventa_ticket) as ticket, vt.correlativo, vt.fecha, vt.monto_total
from ventas v, ventas_tickets vt
where v.idventa_ticket = vt.idventa_ticket and v.fecha >= '"+fecha+@" 00:00:00' and v.fecha <= '"+fecha+@" 23:60:00'
union
select concat('F', v.idventa_factura) as ticket, vf.numero_factura, vf.fecha, vf.monto_total
 from ventas v, ventas_factura vf
 where v.idventa_factura = vf.idventa and v.fecha >= '"+fecha+" 00:00:00' and v.fecha <= '"+fecha+@" 23:60:00'
     ; ";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            try
            {
                Datos = oOperacion.Consultar(Consulta);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

    }
}
