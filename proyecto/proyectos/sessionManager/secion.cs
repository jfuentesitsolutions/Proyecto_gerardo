using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sessionManager
{
    public class secion
    {

        private static volatile secion instancia = null;
        private static readonly object Bloqueador = new object();


        List<string> datos = new List<string>();
        List<string> datosRegistro = new List<string>();
        bool caja_activa;
        string idcaja;

        public static secion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (Bloqueador)
                    {
                        if (instancia == null)
                        {
                            instancia = new secion();
                        }
                    }
                }
                return secion.instancia;
            }
        }

        public List<string> Datos
        {
            get
            {
                return datos;
            }

            set
            {
                datos = value;
            }
        }

        public List<string> DatosRegistro
        {
            get
            {
                return datosRegistro;
            }

            set
            {
                datosRegistro = value;
            }
        }

        public bool Caja_activa
        {
            get
            {
                return caja_activa;
            }

            set
            {
                caja_activa = value;
            }
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

        private secion()
        {

        }

        
    }
}
