using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexiones_BD.clases
{
    public class cajas
    {

        public cajas()
        {

        }

        public static DataTable datosTabla(string nombre)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = "select * from cajas where estado=1 and nombre_equipo='"+nombre+"';";
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
