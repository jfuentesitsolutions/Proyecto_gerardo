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
        protected string idventa, idDocu, fecha, idsucursal;
        private string anulacion;

        public ventas(string idventa, string anula)
        {
            this.idventa = idventa;
            this.anulacion = anula;
        }

        public ventas(string idventa, string idventa_ticket, string fecha, string idsucursal, string anulacion)
        {
            this.idventa = idventa;
            this.IdDocu = idventa_ticket;
            this.fecha = fecha;
            this.idsucursal = idsucursal;
            this.Anulacion = anulacion; 
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

        protected string Anulacion
        {
            get
            {
                return anulacion;
            }

            set
            {
                anulacion = value;
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

        public static DataTable anulacion_ticket(string idventa)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select vt.correlativo, v.fecha, concat(c.nombre_cliente,' ',c.apellidos_cliente) as nom, p.nom_producto, pre.nombre_presentacion,
                        dvt.cantidad_paquete, dvt.precio_venta, dvt.total, vt.monto_total_neto, vt.efectivo, vt.cambio, u.usuario, fp.nombre_pago
                        from ventas v, ventas_tickets vt, detalles_ventas_ticket dvt, sucursales_productos sp, presentaciones_productos pp,
                        clientes c, productos p, presentaciones pre, usuarios u, formas_pagos fp
                        where v.idventa_ticket = vt.idventa_ticket
                        and vt.idcliente = c.idcliente
                        and dvt.idventa_ticket = vt.idventa_ticket
                        and vt.idusuario = u.idusuario
                        and vt.idforma_pago = fp.idforma_pago
                        and dvt.idsucursal_producto = sp.idsucursal_producto
                        and dvt.idpresentacion_producto = pp.idpresentacion_producto
                        and sp.idproducto = p.idproducto
                        and pp.idpresentacion = pre.idpresentacion
                        and v.idventa = '"+idventa+@"'
                        ;
            ";
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

        public StringBuilder sentenciaModificaAnulacion()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE ventas SET anulacion='" + Anulacion + "' WHERE idventa='" + idventa + "';");
            return sentencia;
        }



    }
}
