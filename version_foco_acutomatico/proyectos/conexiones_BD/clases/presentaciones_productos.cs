using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace conexiones_BD.clases
{
    public class presentaciones_productos: entidad
    {
        string idpresentacion_producto, idsucursal_producto, 
            idpresentacion, cantidad_unidades, precio, tipo;

        public string Idsucursal_producto
        {
            get
            {
                return idsucursal_producto;
            }

            set
            {
                idsucursal_producto = value;
            }
        }
        public presentaciones_productos(string idpresentacion_producto)
        {
            this.idpresentacion_producto = idpresentacion_producto;
            base.cargarDatosEliminados("presentaciones_productos", idpresentacion_producto, "idpresentacion_producto");
        }

        public presentaciones_productos(List<string> campos, List<string> valores)
        {
            base.busquedaDatos(campos, valores, "presentaciones_productos");
        }

        public presentaciones_productos(string idpresentacion_producto, string idsucursal_producto, string idpresentacion, string cantidad_unidades, string precio, string tipo)
        {
            this.idpresentacion_producto = idpresentacion_producto;
            this.idsucursal_producto = idsucursal_producto;
            this.idpresentacion = idpresentacion;
            this.cantidad_unidades = cantidad_unidades;
            this.precio = precio;
            this.tipo = tipo;
            base.cargarDatosModificados(generarCampos(), generarValores(), "presentaciones_productos", idpresentacion_producto, "idpresentacion_producto");
        }

        public presentaciones_productos(string idsucursal_producto, string idpresentacion, string cantidad_unidades, string precio, string tipo)
        {
            this.idsucursal_producto = idsucursal_producto;
            this.idpresentacion = idpresentacion;
            this.cantidad_unidades = cantidad_unidades;
            this.precio = precio;
            this.tipo = tipo;
            base.cargarDatos(generarCampos(), generarValores(), "presentaciones_productos");
        }

        public override List<string> generarCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("idsucursal_producto");
            campos.Add("idpresentacion");
            campos.Add("cantidad_unidades");
            campos.Add("precio");
            campos.Add("tipo");
            return campos;
        }

        public override List<string> generarValores()
        {
            List<string> valores = new List<string>();
            valores.Add(Idsucursal_producto);
            valores.Add(idpresentacion);
            valores.Add(cantidad_unidades);
            valores.Add(precio);
            valores.Add(tipo);
            return valores;
        }

        public void cargarNevamente()
        {
            base.cargarDatos(generarCampos(), generarValores(), "presentaciones_productos");
        }

        public static DataTable datosTabla()
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = "select * from presentaciones_productos;";
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

        public static DataTable presentacionesXproducto(string idsuc_p)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idpresentacion_producto, pp.idpresentacion, p.nombre_presentacion, pp.cantidad_unidades, pp.precio, pp.tipo
                        from presentaciones_productos pp, sucursales_productos sp, presentaciones p
                        where pp.idsucursal_producto = sp.idsucursal_producto and pp.idpresentacion = p.idpresentacion and sp.idsucursal_producto = '"+idsuc_p+@"'
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

        public static bool cambio_precio(string precioN, string idpresentacio_producto)
        {
            bool modificado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE presentaciones_productos SET precio='"+precioN+"' WHERE idpresentacion_producto='"+idpresentacio_producto+"';");
            Console.WriteLine(sentencia.ToString());
            conexiones_BD.operaciones op = new operaciones();
            if (op.actualizar(sentencia.ToString()) > 0)
            {
                modificado = true;
            }
            

            return modificado;
        }
    }
}
