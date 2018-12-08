using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace conexiones_BD.clases.ventas
{
    public class impresion_prueba
    {
        LibPrintTicket.Ticket ticket = new LibPrintTicket.Ticket();
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        DataTable productos;

        
        public bool impresionTicket(string nombreim, DataTable p)
        {
            bool impreso = false;
            productos = p;
            ticket.AddHeaderLine("        TIENDA JOSÉ GERARDO");
            ticket.AddHeaderLine("           SUCURSAL: "+sesion.DatosRegistro[0]);
            ticket.AddHeaderLine(sesion.DatosRegistro[2]);
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("Propietario: Carlos Alfredo Cabrera");
            ticket.AddHeaderLine("      Giro: Venta de articulos");
            ticket.AddHeaderLine("          de consumo diario");
            ticket.AddHeaderLine("            NRC: 157975-3");
            ticket.AddHeaderLine("        NIT: 0307-010767-101-2");
            //ticket.AddHeaderLine("Telefono: (503)"+sesion.DatosRegistro[3]);
            ticket.AddHeaderLine("      Vendedor: "+sesion.Datos[0]);
            ticket.AddHeaderLine("   DEL: "+generandoCorrelativos(productos.Rows[0][13].ToString(), productos.Rows[0][15].ToString())+ " AL: " + generandoCorrelativos(productos.Rows[0][14].ToString(), productos.Rows[0][15].ToString()));

            ticket.AddSubHeaderLine("        Ticket #: "+productos.Rows[0][6].ToString());
            ticket.AddSubHeaderLine("Fecha: "+productos.Rows[0][5].ToString());

            foreach (DataRow fila in productos.Rows)
            {
               
                ticket.AddItem(String.Format("{0:#,##0.00;MENOS #,##0.00;—}", fila[0]), String.Format("{0:c}", fila[3]) + "->" + fila[1].ToString() +" "+ fila[2].ToString(),String.Format("{0:c}", fila[4]));
                ticket.AddItem("", "", "");
            }
            

            ticket.AddTotal("VENTAS GRAVADAS:", String.Format("{0:c}", productos.Rows[0][7]));
            ticket.AddTotal("VENTAS EXENTAS:", "$0.00");
            ticket.AddTotal("VENTAS NO SUJETAS:", "$0.00");
            ticket.AddTotal("TOTAL:", String.Format("{0:c}", productos.Rows[0][7]));
            ticket.AddTotal("EFECTIVO:", String.Format("{0:c}", productos.Rows[0][8]));
            ticket.AddTotal("CAMBIO:", String.Format("{0:c}", productos.Rows[0][9]));
            ticket.AddTotal("", "");

            ticket.AddFooterLine("      Total de articulos: "+productos.Rows.Count.ToString());
            ticket.AddFooterLine("");
            ticket.AddFooterLine("Ciente: "+productos.Rows[0][11].ToString());
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("Direccion: " + productos.Rows[0][12].ToString());
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("G=Articulo gravado | E=Articulo exento | NS=Articulo No sujeto");
            ticket.AddFooterLine("");


            ticket.AddFooterLine("      GRACIAS POR SU COMPRA");
            ticket.AddFooterLine("        "+productos.Rows[0][10].ToString());

            try
            {
                ticket.PrintTicket(nombreim); //Nombre de la impresora de tickets
                impreso = true;
            }
            catch
            {
                impreso = false;
            }
            return impreso;
        }

        private string generandoCorrelativos(string cS, string idCo)
        {
            string corr = null;
            int numeroDigitos = cS.Length;
            string identifica = "T" + sesion.DatosRegistro[0] + idCo;

            switch (numeroDigitos)
            {
                case 1:
                    {
                        corr = identifica + "00000" + cS;
                        break;
                    }
                case 2:
                    {
                        corr = identifica + "0000" + cS;
                        break;
                    }
                case 3:
                    {
                        corr = identifica + "000" + cS;
                        break;
                    }
                case 4:
                    {
                        corr = identifica + "00" + cS;
                        break;
                    }
                case 5:
                    {
                        corr = identifica + "0" + cS;
                        break;
                    }
                case 6:
                    {
                        corr = identifica + cS;
                        break;
                    }

            }

            return corr;
        }
    }
}
