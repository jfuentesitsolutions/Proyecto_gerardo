﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace interfaces.ventas.panel
{
    public partial class venta : Form

    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        DataTable productos = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_VENT();
        DataTable pre_pro = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_VENT_X_PRESENTACION();
        DataTable formas_pagos = conexiones_BD.clases.formas_pago.datosTabla();
        DataTable tipo_factura = conexiones_BD.clases.tipos_factura.datosTabla();
        DataTable cliente = conexiones_BD.clases.clientes.datosTabla();
        DataTable vendedor = conexiones_BD.clases.usuarios.datosTabla();
        utilitarios.cargar_tablas tabla;
        string cantiAn, precioAn;
        bool busqueda = false;
        string idticket_Buscado = null;

        DataTable producto_venta = null;
        DataTable pre_producto = null;
        string total = "0.0";
        public venta()
        {
            InitializeComponent();
        }

        private void venta_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 800)
            {
                lblDi.Visible = true;
                txtDireccion.Visible = true;
                lblncr.Visible = true;
                lblven.Visible = true;
                txtncr.Visible = true;
                listaVendedor.Visible = true;

            }
            else
            {
                lblDi.Visible = false;
                txtDireccion.Visible = false;
                lblncr.Visible = false;
                lblven.Visible = false;
                txtncr.Visible = false;
                listaVendedor.Visible = false;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ocultarDetalles();
        }

        private void ocultarDetalles()
        {
            if (Gcliente.Height == 137)
            {
                lblDi.Visible = false;
                lblncr.Visible = false;
                lblven.Visible = false;
                txtDireccion.Visible = false;
                txtncr.Visible = false;
                listaVendedor.Visible = false;
                Gcliente.Height = 75;
                panelInferio.Height = 135;
            }
            else
            {
                lblDi.Visible = true;
                lblncr.Visible = true;
                lblven.Visible = true;
                txtDireccion.Visible = true;
                txtncr.Visible = true;
                listaVendedor.Visible = true;
                Gcliente.Height = 137;
                panelInferio.Height = 198;
            }
        }

        private void cargaListas()
        {
            utilitarios.cargandoListas.cargarLista(formas_pagos, listaFormaPago, "nombre_pago", "idforma_pago");
            listaFormaPago.SelectedValue = "1";
            utilitarios.cargandoListas.cargarLista(tipo_factura, listaTipoFactura, "nombre", "idtipo_factura");
            listaTipoFactura.SelectedValue = "1";
            utilitarios.cargandoListas.cargarLista(cliente, listaClientes, "nom", "idcliente");
            listaClientes.SelectedValue = "1";

            utilitarios.cargandoListas.cargarLista(vendedor, listaVendedor, "usuario", "idusuario");
            listaVendedor.Text = sesion.Datos[0];
            if (!sesion.Datos[3].Equals("Administradores"))
            {
                listaVendedor.Enabled = false;
            }
            nuevoCliente();

        }

        private void cargarTablas()
        {
            tabla = new utilitarios.cargar_tablas(tablad, txtBusqueda, conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_X_SUCURSAL_VENTA(sesion.DatosRegistro[1]), "productoCod");
            tabla.cargarSinContadorRegistros();
        }

        private void cargarListaProductos()
        {
            
            if (chkCod.Checked)
            {
                if (sesion.Datos[3].Equals("Administradores"))
                {
                    utilitarios.cargandoListas.cargarLista(productos, listaControl, "codigo", "idsp");
                }
                else
                {
                    utilitarios.cargandoListas.cargarLista(producto_venta, listaControl, "codigo", "idsp");
                }
                listaControl.Focus();
                //lbltipoBusqueda.Text="Codigo:";
            }
            else if (chkNom.Checked)
            {
                if (sesion.Datos[3].Equals("Administradores"))
                {
                    utilitarios.cargandoListas.cargarLista(productos, listaControl, "nombre", "idsp");
                }
                else
                {
                    utilitarios.cargandoListas.cargarLista(producto_venta, listaControl, "nombre", "idsp");
                }
                listaControl.Focus();
                //lbltipoBusqueda.Text = "Nombre:";
            }
            else if (chkPres.Checked)
            {
                if (sesion.Datos[3].Equals("Administradores"))
                {
                    utilitarios.cargandoListas.cargarLista(pre_pro, listaControl, "prepro", "idsp");
                }
                else
                {
                    utilitarios.cargandoListas.cargarLista(pre_producto, listaControl, "prepro", "idsp");
                }
                listaControl.Focus();
                //lbltipoBusqueda.Text = "Presentación:";
            }

 
            
        }

        private void venta_Load(object sender, EventArgs e)
        {
            producto_venta = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_X_SUCURSAL_VENTA(sesion.DatosRegistro[1]);
            pre_producto = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_X_PRESENTACION_X_SUCURSAL_VENTA(sesion.DatosRegistro[1]);

            btnReimprimir.Enabled = false;
            cargarListaProductos();
            cargaListas();
            cargarTablas();
            activacionCampoDocumento();

        }

        private void chkCod_CheckedChanged(object sender, EventArgs e)
        {
            cargarListaProductos();
        }

        private void chkPres_CheckedChanged(object sender, EventArgs e)
        {
            cargarListaProductos();
        }

        private void chkNom_CheckedChanged(object sender, EventArgs e)
        {
            cargarListaProductos();
        }

        private void venta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                chkCod.Checked = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                chkPres.Checked = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                chkNom.Checked = true;
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnGuardar.PerformClick();
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnBuscar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnReimprimir.PerformClick();
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnCancelar.PerformClick();
            }
        }

        private void listaControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (chkCod.Checked || chkNom.Checked)
                    {
                        cantidadProductos();
                    }else if(chkPres.Checked)
                    {
                        cantidadProductoPrese();
                    } 
                }
                catch
                {

                }

            }
        }

        private void cantidadProductos()
        {
            auxiliares.producto_unica_presentacion pu = new auxiliares.producto_unica_presentacion();
            DataRowView seleccion = (DataRowView)listaControl.SelectedItem;
            auxiliares.productos_mas_presentaciones puu = new auxiliares.productos_mas_presentaciones();

            //si el articulos solo tiene una presentacion
            if (seleccion.Row[3].ToString().Equals("1"))
            {
                pu.Idpresentacion_poroducto = seleccion.Row[8].ToString();
                if (seleccion.Row[11].ToString().Equals("Detalle"))
                {
                    pu.TipoUtilidad = seleccion.Row[9].ToString();
                }
                else
                {
                    pu.TipoUtilidad = seleccion.Row[10].ToString();
                }
                    pu.Sucursal_producto = seleccion.Row[0].ToString();
                    pu.Codigo = seleccion.Row[1].ToString();
                    pu.lblExis.Text = seleccion.Row[6].ToString();
                    pu.lblNombre.Text = seleccion.Row[2].ToString();
                    pu.lblPres.Text = seleccion.Row[7].ToString();
                    pu.lblPrecio.Text = "$" + seleccion.Row[5].ToString();
                    pu.Precio = seleccion.Row[5].ToString();
                    pu.txtCantidad.Value = 1;
                    pu.CantidadInter = "1";

                pu.ShowDialog();
                if (pu.Llenado)
                {
                    //si la tabla esta vacia
                    if (tabla_articulos.Rows.Count == 0)
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.Add(
                        "",
                        pu.Codigo,
                        pu.lblNombre.Text,
                        pu.lblPres.Text,
                        pu.txtCantidad.Value.ToString(),
                        pu.Precio,
                        pu.Total,
                        pu.Idpresentacion_poroducto,
                        pu.Utilidad,
                        "",
                        "1",
                        pu.lblExis.Text,
                        pu.Sucursal_producto
                        );
                        
                    }else
                    {
                        //si el articulo no esta repetido
                        if(!productoRepetido(pu.Idpresentacion_poroducto, pu.txtCantidad.Value.ToString()))
                        {
                            barraDeprogreso(10);
                            tabla_articulos.Rows.Add(
                        "",
                        pu.Codigo,
                        pu.lblNombre.Text,
                        pu.lblPres.Text,
                        pu.txtCantidad.Value.ToString(),
                        pu.Precio,
                        pu.Total,
                        pu.Idpresentacion_poroducto,
                        pu.Utilidad,
                        "",
                        "1",
                        pu.lblExis.Text,
                        pu.Sucursal_producto
                        );
                        }
                        
                    }
                    
                    utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                    cargarListaProductos();
                    calcularTotales();
                }
                //cuando hay mas de dos presentaciones
            }else
            {
                puu.Sucursal_producto = seleccion.Row[0].ToString();
                puu.IdsucursalProducto = seleccion.Row[0].ToString();
                puu.Codigo = seleccion.Row[1].ToString();
                puu.UtilidadD = seleccion.Row[9].ToString();
                puu.UtiliadM = seleccion.Row[10].ToString();
                puu.lblExis.Text = seleccion.Row[6].ToString();
                puu.lblNombre.Text = seleccion.Row[2].ToString();

                puu.ShowDialog();

                if (puu.Llenado)
                {
                    if (tabla_articulos.Rows.Count == 0)
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.Add(
                        "",
                        puu.Codigo,
                        puu.lblNombre.Text,
                        puu.Presentacion,
                        puu.txtCantidad.Value.ToString(),
                        puu.Precio,
                        puu.Total,
                        puu.Idpresentacion_poroducto,
                        puu.Utilidad,
                        "",
                        puu.Cantidad_interna,
                        puu.lblExis.Text,
                        puu.Sucursal_producto
                        );
                    }
                    else
                    {

                        if (!revisarExistencias(puu.IdsucursalProducto, puu.txtCantidad.Value.ToString(), puu.Cantidad_interna))
                        {
                            if (!productoRepetido(puu.Idpresentacion_poroducto, puu.txtCantidad.Value.ToString()))
                            {
                                barraDeprogreso(10);
                                tabla_articulos.Rows.Add(
                            "",
                            puu.Codigo,
                            puu.lblNombre.Text,
                            puu.Presentacion,
                            puu.txtCantidad.Value.ToString(),
                            puu.Precio,
                            puu.Total,
                            puu.Idpresentacion_poroducto,
                            puu.Utilidad,
                            "",
                            puu.Cantidad_interna,
                            puu.lblExis.Text,
                            puu.Sucursal_producto
                            );
                            }
                        }

                        
                          
                    }
                }
                utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                cargarListaProductos();
                calcularTotales();
                
            }
        }

        private void cantidadProductoPrese()
        {
            auxiliares.producto_unica_presentacion pu = new auxiliares.producto_unica_presentacion();
            DataRowView seleccion = (DataRowView)listaControl.SelectedItem;

            pu.Idpresentacion_poroducto = seleccion.Row[6].ToString();
            if (seleccion.Row[9].ToString().Equals("Detalle"))
            {
                pu.TipoUtilidad = seleccion.Row[7].ToString();
            }
            else
            {
                pu.TipoUtilidad = seleccion.Row[8].ToString();
            }
            pu.Sucursal_producto = seleccion.Row[0].ToString();
            pu.Codigo = seleccion.Row[1].ToString();
            pu.lblExis.Text = seleccion.Row[4].ToString();
            pu.lblNombre.Text = seleccion.Row[2].ToString();
            pu.lblPres.Text = seleccion.Row[5].ToString();
            pu.lblPrecio.Text = "$" + seleccion.Row[3].ToString();
            pu.Precio = seleccion.Row[3].ToString();
            pu.txtCantidad.Value = 1;
            pu.CantidadInter= seleccion.Row[10].ToString();

            pu.ShowDialog();
            if (pu.Llenado)
            {
                if (tabla_articulos.Rows.Count == 0)
                {
                    barraDeprogreso(10);
                    tabla_articulos.Rows.Add(
                    "",
                    pu.Codigo,
                    pu.lblNombre.Text,
                    pu.lblPres.Text,
                    pu.txtCantidad.Value.ToString(),
                    pu.Precio,
                    pu.Total,
                    pu.Idpresentacion_poroducto,
                    pu.Utilidad,
                    "",
                    pu.CantidadInter,
                    pu.lblExis.Text,
                    pu.Sucursal_producto
                    );

                }
                else
                {
                    if (!productoRepetido(pu.Idpresentacion_poroducto, pu.txtCantidad.Value.ToString()))
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.Add(
                    "",
                    pu.Codigo,
                    pu.lblNombre.Text,
                    pu.lblPres.Text,
                    pu.txtCantidad.Value.ToString(),
                    pu.Precio,
                    pu.Total,
                    pu.Idpresentacion_poroducto,
                    pu.Utilidad,
                    "",
                    pu.CantidadInter,
                    pu.lblExis.Text,
                    pu.Sucursal_producto
                    );
                    }

                }

                utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                cargarListaProductos();
                calcularTotales();
            }

        }

        private bool productoRepetido(string idpr_pro, string cant)
        {
            bool encontrado = false;
            
                foreach (DataGridViewRow fila in tabla_articulos.Rows)
                {
                    if (fila.Cells[7].Value.Equals(idpr_pro))
                    {
                        Int32 canA = Convert.ToInt32(fila.Cells[4].Value);
                        Int32 canN = Convert.ToInt32(cant);

                        Int32 canInt = Convert.ToInt32(fila.Cells[10].Value);
                        Int32 exis = Convert.ToInt32(fila.Cells[11].Value);

                        Int32 canTN = canA + canN;
                        Int32 tN = (canA * canInt) + (canN * canInt);

                        if (tN > exis)
                        {
                            MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            encontrado = true;
                        }
                        else
                        {
                            fila.Cells[4].Value = canTN.ToString();
                            fila.Cells[6].Value = recalcularTotalProducto(fila.Cells[4].Value.ToString(), fila.Cells[5].Value.ToString());
                            encontrado = true;
                        }
                    }
                }


            

            return encontrado;
        }

        private string recalcularTotalProducto(string canti, string pre)
        {
            string total = "";
            double ca = Convert.ToDouble(canti);
            double prec = Convert.ToDouble(pre);
            double tota = Math.Round(ca * prec, 2);
            Console.WriteLine(ca);
            Console.WriteLine(pre);

            total = tota.ToString();
            
            return total;
        }

        private void calcularTotales()
        {
            double precio = 0;
            foreach(DataGridViewRow fila in tabla_articulos.Rows)
            {
                precio += Convert.ToDouble(fila.Cells[6].Value);
            }

            lblCantidad_de_articulos.Text = "Cantidad de articulos " + tabla_articulos.Rows.Count;
            lblSubt.Text = precio.ToString();
            lblIva.Text = "0.0";
            lblDescuento.Text = "0.0";
            lblTotal.Text = "$ "+ precio.ToString();
            total = precio.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            quitarPestaña();
            tabla_articulos.Rows.Clear();
            tabla_articulos.Enabled = true;
            btnGuardar.Enabled = true;
            btnReimprimir.Enabled = false;
            txtBusqueda.Enabled = true;
            calcularTotales();
        }

        private void quitarPestaña()
        {
            Panel pan = (Panel)this.Parent;
            TabPage pagi = (TabPage)pan.Parent;
            TabControl con = (TabControl)pagi.Parent;

            try
            {
                if (con.TabPages.Count > 1)
                {
                    con.TabPages.Remove(con.SelectedTab);
                }
                
            }
            catch
            {

            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                string correlativo = generaciondecorrelativo();
                string id = IDCorrelativoTicket();
                if (correlativo != null)
                {
                    interfaces.ventas.auxiliares.cobrar cobro = new auxiliares.cobrar();
                    cobro.lblTotala.Text = total;
                    cobro.efec.Text = total;
                    cobro.ShowDialog();
                    if (cobro.Cobrado)
                    {
                        ingresandoVentaTicket(correlativo, cobro.txtefe.Text, cobro.lblCambio.Text, id);
                    }

                }
            }
            
           
        }

        private void ingresandoVentaTicket(string correl, string efec, string cam, string idcorre)
        {
            utilitarios.maneja_fechas fecha = new utilitarios.maneja_fechas();
            conexiones_BD.clases.ventas.tickets ticke = new conexiones_BD.clases.ventas.tickets(
                "0", "0", fecha.fechaMysql(fecha_actual), sesion.DatosRegistro[1], "1", listaFormaPago.SelectedValue.ToString(),
                correl, listaVendedor.SelectedValue.ToString(), lblSubt.Text, lblDescuento.Text,
                this.total, "1", efec, cam, listaClientes.SelectedValue.ToString(), idcorre);

            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            Int32 res = op.transaccionVentasTickets(retornoProductos(), ticke);

            if ( res > 0)
            {
               
                    PrintDocument printDoc = new PrintDocument();
                    string impresora= printDoc.PrinterSettings.PrinterName;
                    
                        conexiones_BD.clases.ventas.impresion_prueba imp = new conexiones_BD.clases.ventas.impresion_prueba();
                        if (imp.impresionTicket(impresora, conexiones_BD.clases.ventas.detalles_productos_venta_ticket.detalle_proTic(res.ToString())))
                        {
                        tabla_articulos.Rows.Clear();
                        calcularTotales();
                        busqueda = false;
                        txtBusqueda.Text = "";
                        txtBusqueda.Focus();
                        tablad.Visible = false;
                        tablad.DataSource = null;
                        cargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al guardar el ticket, pero la venta se guardo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabla_articulos.Rows.Clear();
                        calcularTotales();
                        busqueda = false;
                        txtBusqueda.Text = "";
                        txtBusqueda.Focus();
                        tablad.Visible = false;
                        tablad.DataSource = null;
                        cargarTablas();
                    }
                    
                
            }
            else
            {
                MessageBox.Show("Se produjo un error al guardar el ticket", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validar()
        {
            bool valido = false;
            error.Clear();

            if (listaTipoFactura.SelectedIndex!=0)
            {
                if (txtncr.TextLength == 0)
                {
                    valido = true;
                    error.SetError(txtncr, "Tienes que digitar un numero de documento");
                    if (Gcliente.Height != 137)
                    {
                        ocultarDetalles();
                    }
                }
            }

            if (tabla_articulos.Rows.Count == 0)
            {
                valido = true;
                error.SetError(tabla_articulos, "Tienes que gregar articulos al detalle");
            }

            return valido;
        }

        private List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket> retornoProductos()
        {
            List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket> dp = new List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket>();
            
            foreach (DataGridViewRow fila in tabla_articulos.Rows)
            {
                double cantidad = Convert.ToDouble(fila.Cells[4].Value.ToString()) * Convert.ToDouble(fila.Cells[10].Value.ToString());
                double can = Convert.ToDouble(fila.Cells[4].Value.ToString());
                dp.Add(new conexiones_BD.clases.ventas.detalles_productos_venta_ticket(
                    "0", fila.Cells[7].Value.ToString(), cantidad.ToString(),
                    fila.Cells[5].Value.ToString(), fila.Cells[6].Value.ToString(),
                    fila.Cells[8].Value.ToString(), "0", fila.Cells[12].Value.ToString(),
                    can.ToString()));
            }


            return dp;
        }

        private void tabla_articulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("aqui");
            if (tabla_articulos.Columns[e.ColumnIndex].Name == "canti")
            {
                double canN = 0;
                double canNU = 0;
                int canNuu = 0;

                if (tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString().Equals("0"))
                {
                    
                    try
                    {
                        canN = Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString()) * Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString());
                        canNuu = Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString());
                        Console.WriteLine("Cantida digitada"+canNuu);

                        if (!revisarExistencias2(tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString(), canN.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString()) && canNuu!=0)
                        {
                            Int32 exist = Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[11].Value.ToString());

                            if (canN == exist || canN < exist || canNuu==0)
                            {
                                tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(canNuu.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());
                                calcularTotales();
                                colocarFoco();
                                txtBusqueda.Focus();
                            }
                            else
                            {
                                MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                            }
                        }
                        else
                        {
                            tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                        }
                    } catch{
                        MessageBox.Show("No puedes agregar esa cantidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        canN = Convert.ToInt32(cantiAn);
                        tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                        tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(cantiAn.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());
                        
                    }

                }
                else
                { 
                    try
                    {
                        canN = Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString()) * Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString());
                        canNU = Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString());
                        Console.WriteLine(canN);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Debes ingresar una cantidad valida", "No es numero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        canN = Convert.ToInt32(cantiAn);
                        tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                    }

                    if (!revisarExistencias2(tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString(), canN.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString()) && canNU!=0)
                    {
                        Int32 exist = Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[11].Value.ToString());


                        if (canN == exist || canN < exist || canNU==0)
                        {
                            tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(canNU.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());
                            calcularTotales();
                            colocarFoco();
                            txtBusqueda.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                        }
                    }
                    else
                    {
                        tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                    }
                }
            }else if (tabla_articulos.Columns[e.ColumnIndex].Name == "preci")
            {

                if (MessageBox.Show("¿Deseas cambiar el precio de la presentación?","Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    barraDeprogreso(10);
                    string precioN = tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (!conexiones_BD.clases.presentaciones_productos.cambio_precio(tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[7].Value.ToString()))
                    {
                        
                        tabla_articulos.Rows[e.RowIndex].Cells[5].Value = precioN;
                        calcularTotales();
                        
                    }
                    tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());
                    cargarTablas();
                    colocarFoco();
                    txtBusqueda.Focus();
                    calcularTotales();
                }
                else
                {
                    tabla_articulos.Rows[e.RowIndex].Cells[5].Value = precioAn;
                }
            }
        }

        private void tabla_articulos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tabla_articulos.Rows.Count != 0)
                {
                    if (MessageBox.Show("¿Desea quitar este producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.RemoveAt(tabla_articulos.CurrentRow.Index);
                        calcularTotales();
                    }
                }
            }
            catch
            {

            }
        }

        private void listaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.nuevoCliente();
            }
        }

        private void tabla_articulos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
            if (tabla_articulos.Columns[e.ColumnIndex].Name == "canti")
            {
                cantiAn = tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            else if (tabla_articulos.Columns[e.ColumnIndex].Name == "preci")
            {
                precioAn= tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void nuevoCliente()
        {
            if (listaClientes.SelectedValue == null)
            {
                if (MessageBox.Show("¿Deseas ingresar un nuevo cliente?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    auxiliares.nuevo_cliente_simple cli = new auxiliares.nuevo_cliente_simple();
                    cli.Cli = conexiones_BD.clases.clientes.datosTabla();
                    cli.txtNombres.Text = listaClientes.Text;
                    cli.txtApellidos.Text = "-";
                    cli.txtDire.Text = "-";
                    cli.ShowDialog();
                    if (cli.Ingresado)
                    {
                        listaClientes.DataSource = null;
                        listaClientes.Items.Clear();
                        utilitarios.cargandoListas.cargarLista(conexiones_BD.clases.clientes.datosTabla(), listaClientes, "nom", "idcliente");
                    }
                }
            }else
            {
                DataRowView seleccion = (DataRowView)listaClientes.SelectedItem;
                txtDireccion.Text = seleccion.Row[4].ToString();
                ocultarDetalles();
                listaControl.Focus();
            }
        }

        private void activacionCampoDocumento()
        {
            if (listaTipoFactura.SelectedIndex==0)
            {
                txtncr.Enabled = false;
                txtncr.Text = "";
                if (Gcliente.Height == 137)
                {
                    ocultarDetalles();
                }
            }
            else
            {
                txtncr.Enabled = true;
                txtncr.Text = "";
                txtncr.Focus();
                if(Gcliente.Height != 137)
                {
                    ocultarDetalles();
                }
            }

        }

        private string IDCorrelativoTicket()
        {
            string idcorre = "";
            DataTable correlativos = conexiones_BD.clases.ventas.correlativos_tickets.datosTabla(sesion.DatosRegistro[1]);
            if (correlativos == null)
            {
                idcorre = "0";
            }else
            {
                idcorre = correlativos.Rows[0][0].ToString();
            }

            return idcorre;
        }

        private void listaTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaTipoFactura.SelectedValue != null)
            {
                activacionCampoDocumento();
            }
        }

        private void txtncr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listaControl.Focus();
                ocultarDetalles();
            }
        }

        private void barraDeprogreso(Int32 valorMaximo)
        {
            progreso.Minimum = 1;
            progreso.Maximum = valorMaximo;
            progreso.Value = 1;
            progreso.Step = 1;

            for (int x = 1; x <= valorMaximo; x++)
            {
                    progreso.PerformStep();  
            }
        }

        private string generaciondecorrelativo()
        {
            string corre = null;
            DataTable correlativos = conexiones_BD.clases.ventas.correlativos_tickets.datosTabla(sesion.DatosRegistro[1]);
            Int32 limite = 0;
            Int32 correlativoActual = 0;
            Int32 correlativoSiguiente = 0;

            if (correlativos == null)
            {
                MessageBox.Show("No se han establecido correlativos para esta sucursal", "Error de correlativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                correlativoActual = Convert.ToInt32(correlativos.Rows[0][4].ToString());

                limite= Convert.ToInt32(correlativos.Rows[0][3].ToString());
                if (correlativoActual+1==limite)
                {
                    MessageBox.Show("Ya se alcanso el limite de tickets emitidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    correlativoSiguiente = correlativoActual+1;
                    Console.WriteLine(correlativoSiguiente);
                    if (conexiones_BD.clases.ventas.correlativos_tickets.actualizaCorrelativos(correlativoSiguiente.ToString(), correlativos.Rows[0][0].ToString()))
                    {
                        corre = generandoCorrelativos(correlativoActual.ToString(), correlativos.Rows[0][0].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Setecto un problema al generar el correlativo","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                
            }

            return corre;
        }

        private string generandoCorrelativos(string cS, string idCo)
        {
            string corr = null;
            int numeroDigitos = cS.Length;
            string identifica = "T" + sesion.DatosRegistro[0]+idCo;

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

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            string impresora = printDoc.PrinterSettings.PrinterName;

            if (idticket_Buscado!=null)
            {
                conexiones_BD.clases.ventas.impresion_prueba imp = new conexiones_BD.clases.ventas.impresion_prueba();
                if (imp.impresionTicket(impresora, conexiones_BD.clases.ventas.detalles_productos_venta_ticket.detalle_proTic(idticket_Buscado)))
                {
                    tabla_articulos.Rows.Clear();
                    tabla_articulos.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnReimprimir.Enabled = false;
                    txtBusqueda.Enabled = true;
                    colocarFoco();
                    calcularTotales();
                }
                else
                {

                }
            }
            
        }

        private string cantidadNueva(string exi, string c, string ci)
        {
            Int32 cantiInte = Convert.ToInt32(ci);
            Int32 canti = Convert.ToInt32(c);
            Int32 exis = Convert.ToInt32(exi);

            Int32 cantA = exis - (canti*cantiInte);

            return cantA.ToString();
        }

        private bool revisarExistencias(string idsucur, string canN, string canI)
        {
            bool existen = false;
            int cantidadReg = 0;
            double conte = 0;
            Int32 exis = 0;
            double caN = Convert.ToDouble(canN);
            double caI = Convert.ToDouble(canI);

            foreach (DataGridViewRow fila in tabla_articulos.Rows)
            {
                if (fila.Cells[12].Value.Equals(idsucur))
                {
                    conte += (Convert.ToDouble(fila.Cells[4].Value.ToString())*Convert.ToDouble(fila.Cells[10].Value.ToString()));
                    exis = Convert.ToInt32(fila.Cells[11].Value.ToString());
                    cantidadReg++;
                }
            }

            if (cantidadReg>0)
            {
                conte += (caN * caI);
                Console.WriteLine(conte + "hola");
                Console.WriteLine(exis + "Exist");

                if (conte > exis)
                {
                    MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    existen = true;
                }
                else
                {
                    existen = false;
                }
            }else
            {
                existen = false;
            }
            


            return existen;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (busqueda)
            {
                tablad.Visible = true;
                tabla.FiltrarLocalmenteSinContadorRegistros();
                try
                {
                    if (tablad.Rows.Count != 0)
                    {
                        tablad.CurrentCell = tablad.Rows[0].Cells[1];
                    }
                    
                }
                catch
                {

                }
            }
            
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tablad.Visible = false;
                colocarFoco();
                txtBusqueda.Focus();
            }else if (e.KeyCode == Keys.Down)
            {
                if (txtBusqueda.TextLength!=0)
                {
                    tablad.Focus(); 
                }         
            }else if (e.KeyCode==Keys.Enter)
            {
                if (txtBusqueda.TextLength!=0)
                {
                    if (busqueda)
                    {
                        try
                        {
                            
                            cantidadProductos2();
                            //colocarFoco();
                            txtBusqueda.Text = "";
                            tabla_articulos.Focus();
                            tablad.Visible = false;
                        }
                        catch
                        {

                        }
                    }
                }
                
                
            }
        }

        private bool revisarExistencias2(string idsucur, string canN, string canI)
        {
            bool existen = false;
            int cantidadReg = 0;
            double conte = 0;
            Int32 exis = 0;
            double caN = Convert.ToDouble(canN);
            double caI = Convert.ToDouble(canI);

            foreach (DataGridViewRow fila in tabla_articulos.Rows)
            {
                if (fila.Cells[12].Value.Equals(idsucur))
                {
                    conte += (Convert.ToDouble(fila.Cells[4].Value.ToString()) * Convert.ToDouble(fila.Cells[10].Value.ToString()));
                    exis = Convert.ToInt32(fila.Cells[11].Value.ToString());
                    cantidadReg++;
                }
            }

            if (cantidadReg > 1)
            {
                conte += (caN * caI);
                conte = conte - caN;
                Console.WriteLine(conte + "hola");
                Console.WriteLine(exis + "Exist");

                if (conte > exis)
                {
                    MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    existen = true;
                }
                else
                {
                    existen = false;
                }
            }
            else
            {
                existen = false;
            }



            return existen;
        }

        private void tablad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            busqueda = true;
        }

        private void tablad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                try
                {
                    if (busqueda)
                    {
                        cantidadProductos2();
                        colocarFoco(); 
                    }

                }
                catch
                {

                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                busqueda = false;
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
                tablad.Visible = false;

            }
        }

        private void tabla_articulos_Click(object sender, EventArgs e)
        {
            try
            {
                lblCantidad.Text = tabla_articulos.CurrentRow.Cells[11].Value.ToString();
            }
            catch
            {
                
            }
            
        }

        private void tabla_articulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (tabla_articulos.Columns[e.ColumnIndex].Name == "prese")
            {
                try
                {
                     
                    
                    if (MessageBox.Show("¿Cambiar presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        if (tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString().Equals("0"))
                        {
                            MessageBox.Show("No hay presentaciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        } else
                        {
                            auxiliares.productos_mas_presentaciones puu = new auxiliares.productos_mas_presentaciones();
                            puu.Sucursal_producto = tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString();
                            puu.IdsucursalProducto = tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString();
                            puu.Codigo = tabla_articulos.Rows[e.RowIndex].Cells[1].Value.ToString();
                            puu.UtilidadD = tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString();
                            puu.UtiliadM = tabla_articulos.Rows[e.RowIndex].Cells[14].Value.ToString();
                            puu.lblExis.Text = tabla_articulos.Rows[e.RowIndex].Cells[11].Value.ToString();
                            puu.lblNombre.Text = tabla_articulos.Rows[e.RowIndex].Cells[2].Value.ToString();
                            puu.txtCantidad.Text= tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString();

                            puu.ShowDialog();

                            if (puu.Llenado)
                            {
                                if (tabla_articulos.Rows.Count == 0)
                                {
                                    barraDeprogreso(10);
                                    tabla_articulos.Rows.Add(
                                    "",
                                    puu.Codigo,
                                    puu.lblNombre.Text,
                                    puu.Presentacion,
                                    puu.txtCantidad.Value.ToString(),
                                    puu.Precio,
                                    puu.Total,
                                    puu.Idpresentacion_poroducto,
                                    puu.Utilidad,
                                    "",
                                    puu.Cantidad_interna,
                                    puu.lblExis.Text,
                                    puu.Sucursal_producto,
                                    puu.UtilidadD,
                                    puu.UtiliadM
                                    );

                                    tabla_articulos.Rows.RemoveAt(e.RowIndex);
                                    calcularTotales();
                                    utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                                }
                                else
                                {

                                    if (!revisarExistencias(puu.IdsucursalProducto, puu.txtCantidad.Value.ToString(), puu.Cantidad_interna))
                                    {
                                        if (!productoRepetido(puu.Idpresentacion_poroducto, puu.txtCantidad.Value.ToString()))
                                        {
                                            barraDeprogreso(10);
                                            tabla_articulos.Rows.Add(
                                        "",
                                        puu.Codigo,
                                        puu.lblNombre.Text,
                                        puu.Presentacion,
                                        puu.txtCantidad.Value.ToString(),
                                        puu.Precio,
                                        puu.Total,
                                        puu.Idpresentacion_poroducto,
                                        puu.Utilidad,
                                        "",
                                        puu.Cantidad_interna,
                                        puu.lblExis.Text,
                                        puu.Sucursal_producto,
                                        puu.UtilidadD,
                                        puu.UtiliadM
                                        );
                                            tabla_articulos.Rows.RemoveAt(e.RowIndex);
                                            calcularTotales();
                                            utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tabla_articulos.Rows.Count==0)
            {
                auxiliares.busquedaArticulos frm = new auxiliares.busquedaArticulos();
                frm.ShowDialog();
                if (frm.Elegido)
                {
                    idticket_Buscado = frm.Idventa_tic;
                    btnGuardar.Enabled = false;
                    btnReimprimir.Enabled = true;
                    colocar_productos(frm.Docu);
                    tabla_articulos.Enabled = true;
                }
            }else
            {
                tabla_articulos.Rows.Clear();
                auxiliares.busquedaArticulos frm = new auxiliares.busquedaArticulos();
                frm.ShowDialog();
                if (frm.Elegido)
                {
                    idticket_Buscado = frm.Idventa_tic;
                    tablad.Enabled = false;
                    txtBusqueda.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnReimprimir.Enabled = true;
                    colocar_productos(frm.Docu);
                    tabla_articulos.Enabled = true;
                }
            }
            
        }

        private void colocar_productos(DataTable pr)
        {
            foreach (DataRow fila in pr.Rows)
            {
                tabla_articulos.Rows.Add(
                    "0",
                    fila[16].ToString(),
                    fila[2].ToString(),
                    fila[1].ToString(),
                    fila[0].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString()
                    );
            }
            utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
            calcularTotales();

        }

        private void cantidadProductos2()
        {
            auxiliares.producto_unica_presentacion pu = new auxiliares.producto_unica_presentacion();
            DataGridViewRow seleccion = tablad.CurrentRow;
            auxiliares.productos_mas_presentaciones puu = new auxiliares.productos_mas_presentaciones();

            //si el articulos solo tiene una presentacion
            if (seleccion.Cells[3].Value.ToString().Equals("1"))
            {
                
                pu.Idpresentacion_poroducto = seleccion.Cells[8].Value.ToString();
                if (seleccion.Cells[11].Value.ToString().Equals("Detalle"))
                {
                    pu.TipoUtilidad = seleccion.Cells[9].Value.ToString();
                }
                else
                {
                    pu.TipoUtilidad = seleccion.Cells[10].Value.ToString();
                }
                pu.Sucursal_producto = seleccion.Cells[0].Value.ToString();
                pu.Codigo = seleccion.Cells[1].Value.ToString();
                pu.lblExis.Text = seleccion.Cells[6].Value.ToString();
                pu.lblNombre.Text = seleccion.Cells[2].Value.ToString();
                pu.lblPres.Text = seleccion.Cells[7].Value.ToString();
                pu.lblPrecio.Text = "$" + seleccion.Cells[5].Value.ToString();
                pu.Precio = seleccion.Cells[5].Value.ToString();
                pu.txtCantidad.Value = 1;
                pu.CantidadInter = "1";

                pu.ShowDialog();

                if (pu.Llenado)
                {
                    //si la tabla esta vacia
                    if (tabla_articulos.Rows.Count == 0)
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.Add(
                        "",
                        pu.Codigo,
                        pu.lblNombre.Text,
                        pu.lblPres.Text,
                        pu.txtCantidad.Value.ToString(),
                        pu.Precio,
                        pu.Total,
                        pu.Idpresentacion_poroducto,
                        pu.Utilidad,
                        "",
                        "1",
                        pu.lblExis.Text,
                        pu.Sucursal_producto,
                        "0"
                        );

                        colocarEnelutimoRegistro();
                    }
                    else
                    {
                        //si el articulo no esta repetido
                        if (!productoRepetido(pu.Idpresentacion_poroducto, pu.txtCantidad.Value.ToString()))
                        {
                            barraDeprogreso(10);
                            tabla_articulos.Rows.Add(
                        "",
                        pu.Codigo,
                        pu.lblNombre.Text,
                        pu.lblPres.Text,
                        pu.txtCantidad.Value.ToString(),
                        pu.Precio,
                        pu.Total,
                        pu.Idpresentacion_poroducto,
                        pu.Utilidad,
                        "",
                        "1",
                        pu.lblExis.Text,
                        pu.Sucursal_producto,
                        "0"
                        );
                            colocarEnelutimoRegistro();
                            
                        } 
                    }

                    utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                    //tablad.DataSource = null;
                    cargarTablas();
                    calcularTotales();
                    
                }
                //cuando hay mas de dos presentaciones
            }
            else
            {
                puu.Sucursal_producto = seleccion.Cells[0].Value.ToString();
                puu.IdsucursalProducto = seleccion.Cells[0].Value.ToString();
                puu.Codigo = seleccion.Cells[1].Value.ToString();
                puu.UtilidadD = seleccion.Cells[9].Value.ToString();
                puu.UtiliadM = seleccion.Cells[10].Value.ToString();
                puu.lblExis.Text = seleccion.Cells[6].Value.ToString();
                puu.lblNombre.Text = seleccion.Cells[2].Value.ToString();

                puu.ShowDialog();

                if (puu.Llenado)
                {
                    if (tabla_articulos.Rows.Count == 0)
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.Add(
                        "",
                        puu.Codigo,
                        puu.lblNombre.Text,
                        puu.Presentacion,
                        puu.txtCantidad.Value.ToString(),
                        puu.Precio,
                        puu.Total,
                        puu.Idpresentacion_poroducto,
                        puu.Utilidad,
                        "",
                        puu.Cantidad_interna,
                        puu.lblExis.Text,
                        puu.Sucursal_producto,
                        puu.UtilidadD,
                        puu.UtiliadM
                        );
                        colocarEnelutimoRegistro();
                       
                    }
                    else
                    {

                        if (!revisarExistencias(puu.IdsucursalProducto, puu.txtCantidad.Value.ToString(), puu.Cantidad_interna))
                        {
                            if (!productoRepetido(puu.Idpresentacion_poroducto, puu.txtCantidad.Value.ToString()))
                            {
                                barraDeprogreso(10);
                                tabla_articulos.Rows.Add(
                            "",
                            puu.Codigo,
                            puu.lblNombre.Text,
                            puu.Presentacion,
                            puu.txtCantidad.Value.ToString(),
                            puu.Precio,
                            puu.Total,
                            puu.Idpresentacion_poroducto,
                            puu.Utilidad,
                            "",
                            puu.Cantidad_interna,
                            puu.lblExis.Text,
                            puu.Sucursal_producto,
                            puu.UtilidadD,
                            puu.UtiliadM
                            );
                                colocarEnelutimoRegistro();
                                
                            }
                        }

                    }
                }
                utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                //tablad.DataSource = null;
                cargarTablas();
                calcularTotales();
            }
        }

        private void colocarEnelutimoRegistro()
        {
            if (tabla_articulos.Rows.Count != 0)
            {
                tabla_articulos.CurrentCell = tabla_articulos.Rows[tabla_articulos.Rows.Count-1].Cells[4];
            }
        }

        private void btnAgr_Click(object sender, EventArgs e)
        {
            auxiliares.nuevo_producto_simplificado np = new auxiliares.nuevo_producto_simplificado();
            np.txtCodigo.Text = txtBusqueda.Text;
            np.ShowDialog();

            if (np.Ingresado)
            {
                cargarTablas();
                colocarFoco();
            }
        }

        private void tabla_articulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBusqueda.Focus();
            }
        }

        private void colocarFoco()
        {
            txtBusqueda.Text = "";
            //txtBusqueda.Focus();
            busqueda = false;
            tablad.Visible = false;
            
        }
    }
}

