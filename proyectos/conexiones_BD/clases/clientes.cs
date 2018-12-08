using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace conexiones_BD.clases
{
    public class clientes:entidad
    {
        string idcliente, cod_cliente, nombre_cliente, apellidos_cliente, direccion, dui, nit, ncr, razon_social, telefono, correo, iddescuento, fecha_ingreso, genero;

        public clientes(string idcliente, string cod_cliente, string nombre_cliente, string apellidos_cliente, string direccion, string dui, string nit, string ncr, string razon_social, string telefono, string correo, string iddescuento, string fecha_ingreso, string genero)
        {
            this.idcliente = idcliente;
            this.cod_cliente = cod_cliente;
            this.nombre_cliente = nombre_cliente;
            this.apellidos_cliente = apellidos_cliente;
            this.direccion = direccion;
            this.dui = dui;
            this.nit = nit;
            this.ncr = ncr;
            this.razon_social = razon_social;
            this.telefono = telefono;
            this.correo = correo;
            this.iddescuento = iddescuento;
            this.fecha_ingreso = fecha_ingreso;
            this.genero = genero;
            base.cargarDatosModificados(generarCampos(), generarValores(), "clientes", idcliente, "idcliente");
        }

        public clientes(string cod_cliente, string nombre_cliente,
            string apellidos_cliente, string direccion, string dui, string nit, 
            string ncr, string razon_social, string telefono, string correo, 
            string iddescuento, string fecha_ingreso, string genero)
        {
            this.cod_cliente = cod_cliente;
            this.nombre_cliente = nombre_cliente;
            this.apellidos_cliente = apellidos_cliente;
            this.direccion = direccion;
            this.dui = dui;
            this.nit = nit;
            this.ncr = ncr;
            this.razon_social = razon_social;
            this.telefono = telefono;
            this.correo = correo;
            this.iddescuento = iddescuento;
            this.fecha_ingreso = fecha_ingreso;
            this.genero = genero;
            base.cargarDatos(generarCampos(), generarValores(), "clientes");
        }

        public clientes(string idcliente)
        {
            this.idcliente = idcliente;
            base.cargarDatosEliminados("clientes", idcliente, "idcliente");
        }

        public clientes(List<string> campos, List<string> valores)
        {
            base.busquedaDatos(campos, valores, "clientes");
        }

        public override List<string> generarCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("cod_cliente");
            campos.Add("nombre_cliente");
            campos.Add("apellidos_cliente");
            campos.Add("direccion");
            campos.Add("dui");
            campos.Add("nit");
            campos.Add("ncr");
            campos.Add("razon_social");
            campos.Add("telefono");
            campos.Add("correo");
            campos.Add("iddescuento");
            campos.Add("fecha_ingreso");
            campos.Add("genero");
            return campos;
        }

        public override List<string> generarValores()
        {
            List<string> valores = new List<string>();
            valores.Add(cod_cliente);
            valores.Add(nombre_cliente);
            valores.Add(apellidos_cliente);
            valores.Add(direccion);
            valores.Add(dui);
            valores.Add(nit);
            valores.Add(ncr);
            valores.Add(razon_social);
            valores.Add(telefono);
            valores.Add(correo);
            valores.Add(iddescuento);
            valores.Add(fecha_ingreso);
            valores.Add(genero);
            return valores;
        }

        public static DataTable datosTabla()
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select *, d.tipo_descuento as nombres_des, concat(c.nombre_cliente, ' ', c.apellidos_cliente) as nom
from clientes c, descuentos d
where c.iddescuento = d.iddescuento
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
