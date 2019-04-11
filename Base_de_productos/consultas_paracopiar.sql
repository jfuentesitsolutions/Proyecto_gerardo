
create database bd_facturacion;
use bd_facturacion;
select cod_producto, count(nom_producto) as numero from productos group by cod_producto;
delete from codigos where codigo is not null;
use bd_facturacion2;
select * from productos;
select * from detalles_ventas_ticket;

SET SQL_SAFE_UPDATES = 0;

/*Ajustes*/
insert into bd_facturacion2.ajustes (idajuste, idusuario, idsucursales_productos, justificacion, cantidad, tipo_ajuste, fecha_ajuste)
select a.idajuste, a.idusuario, a.idsucursales_productos, a.justificacion, a.cantidad, a.tipo_ajuste, a.fecha_ajuste
from bd_facturacion.ajustes a
;

/*anulaciones_compras*/
insert into bd_facturacion2.anulaciones_compras (idanulacion_compra, idcompra, justificacion, idusuario, fecha)
select a.idanulacion_compra, a.idcompra, a.justificacion, a.idusuario, a.fecha
from bd_facturacion.anulaciones_compras a
;

/*anulaciones_ventas*/
insert into bd_facturacion2.anulaciones_ventas (idventa, justificicacion, idusuario, fecha)
select a.idventa, a.justificicacion, a.idusuario, a.fecha
from bd_facturacion.anulaciones_ventas a
;

/*bancos*/
insert into bd_facturacion2.bancos (idbanco, nombre, telefono_banco)
select a.idbanco, a.nombre, a.telefono_banco
from bd_facturacion.bancos a
;

/*cargos*/
insert into bd_facturacion2.cargos (idcargo, nombre_cargo, descripcion)
select a.idcargo, a.nombre_cargo, a.descripcion
from bd_facturacion.cargos a
;

/*categorias*/
insert into bd_facturacion2.categorias (idcategoria, nombre_categoria, descripcion)
select a.idcategoria, a.nombre_categoria, a.descripcion
from bd_facturacion.categorias a
;

/*citas*/
insert into bd_facturacion2.citas (idcita, contenido, titulo)
select a.idcita, a.contenido, a.titulo
from bd_facturacion.citas a
;

/*descuentos*/
insert into bd_facturacion2.descuentos (iddescuento, tipo_descuento, descuento)
select a.iddescuento, a.tipo_descuento, a.descuento
from bd_facturacion.descuentos a
;

/*clientes*/
insert into bd_facturacion2.clientes (idcliente, cod_cliente, nombre_cliente, apellidos_cliente, direccion, dui, nit, ncr, razon_social, telefono, correo, iddescuento, fecha_ingreso, genero)
select a.idcliente, a.cod_cliente, a.nombre_cliente, a.apellidos_cliente, a.direccion, a.dui, a.nit,a.ncr,a.razon_social,a.telefono,a.correo,a.iddescuento,a.fecha_ingreso,a.genero
from bd_facturacion.clientes a
;

/*codigos*/
insert into bd_facturacion2.codigos (codigo, estado)
select a.cod_producto, 1
from bd_facturacion.productos a
;

/*compras*/
insert into bd_facturacion2.compras (idcompra, idfactura, idsucursal, fecha_ingreso, anulacion)
select a.idcompra, a.idfactura, a.idsucursal, a.fecha_ingreso, a.anulacion
from bd_facturacion.compras a
;

/*sucursales*/
insert into bd_facturacion2.sucursales (idsucursal, numero_de_sucursal, direccion, telefono, encargado)
select a.idsucursal, a.numero_de_sucursal, a.direccion, a.telefono, a.encargado
from bd_facturacion.sucursales a
;

/*correlativos*/
insert into bd_facturacion2.correlativos_ticket (idcorrelativo_ticket, idsucursal, inicio, final, numero_siguiente, fecha_ultimo, descripcion, activos)
select a.idcorrelativo_ticket, a.idsucursal, a.inicio, a.final, a.numero_siguiente, a.fecha_ultimo, a.descripcion,a.activos
from bd_facturacion.correlativos_ticket a
;

/*correlativos para traslados*/
insert into bd_facturacion2.correlativos_traslados (idcorrelativo_traslado, idsucursal, inicio, final, numero_siguiente, fecha_ultimo, descripcion, activos)
select a.idcorrelativo_traslado, a.idsucursal, a.inicio, a.final, a.numero_siguiente, a.fecha_ultimo, a.descripcion,a.activos
from bd_facturacion.correlativos_traslados a
;

/*cortes diarios*/
insert into bd_facturacion2.cortes_diarios (idcorte_diario, total, total_anulado,total_ganancia,idusuario,gastos_operativos)
select a.idcorte_diario, a.total, a.total_anulado,a.total_ganancia,a.idusuario,a.gastos_operativos
from bd_facturacion.cortes_diarios a
;

/*cortes sucursales*/
insert into bd_facturacion2.cortes_sucursales (idcorte_sucursal, idsucursal, idcorte_diario,fecha)
select a.idcorte_sucursal, a.idsucursal, a.idcorte_diario,a.fecha
from bd_facturacion.cortes_sucursales a
;

/*proveedores*/
insert into bd_facturacion2.proveedores (idproveedor, cod_proveedor, nombre_proveedor,dui,nit,ncr,direccion,telefono,email)
select a.idproveedor, a.cod_proveedor, a.nombre_proveedor,a.dui,a.nit,a.ncr,a.direccion,a.telefono,a.email
from bd_facturacion.proveedores a
;

/*cuentas proveedores*/
insert into bd_facturacion2.cuentas_proveedores (idcuenta_proveedor, idproveedor, idbanco,numero_cuenta)
select a.idcuenta_proveedor, a.idproveedor, a.idbanco,a.numero_cuenta
from bd_facturacion.cuentas_proveedores a
;

/*Descuentos*/
insert into bd_facturacion2.descuentos (iddescuento, tipo_descuento, descuento)
select a.iddescuento, a.tipo_descuento, a.descuento
from bd_facturacion.descuentos a
;

/*detalles_traslados*/
insert into bd_facturacion2.detalle_productos_traslados (idproducto_traslado, idsucursal_producto, cantidad,recibido,idtraslado,cantidad_presentacion,nombre_presentacion,cod_producto)
select a.idproducto_traslado, a.idsucursal_producto, a.cantidad,a.recibido,a.idtraslado,a.cantidad_presentacion,a.nombre_presentacion,a.cod_producto
from bd_facturacion.detalle_productos_traslados a
;

/*detalles_ventas*/
insert into bd_facturacion2.detalles_compras (iddetalle_compra, idsucursal_producto, cantidad,precio_compra_m,precio_compra_d,total,porcentaje_utilidad_M,porcentaje_utilidad_D,idfactura_compra,idutilidadMayoreo,idutilidadDetalle,precio_venta_m,precio_venta_d,cantidad_paquete,presentacion_producto)
select a.iddetalle_compra, a.idsucursal_producto, a.cantidad,a.precio_compra_m,a.precio_compra_d,a.total,a.porcentaje_utilidad_M,a.porcentaje_utilidad_D,a.idfactura_compra,a.idutilidadMayoreo,a.idutilidadDetalle,a.precio_venta_m,a.precio_venta_d,a.cantidad_paquete,a.presentacion_producto
from bd_facturacion.detalles_compras a
;

/*detalle_ventas_factura*/
insert into bd_facturacion2.detalles_ventas_factura (idpresentacion_producto, cantidad, precio_venta,total,utilidad,idventa_factura,iddetalle)
select a.idpresentacion_producto, a.cantidad, a.precio_venta,a.total,a.utilidad,a.idventa_factura,a.iddetalle_venta
from bd_facturacion.detalles_ventas_factura a
;


/*detalle_ventas_tickets*/
insert into bd_facturacion2.detalles_ventas_ticket (iddetalle,idpresentacion_producto, cantidad, precio_venta,total,utilidad,idventa_ticket,idsucursal_producto,cantidad_paquete)
select a.iddetalle_ventas_ticket, a.idpresentacion_producto, a.cantidad,a.precio_venta,a.total,a.utilidad, vt.correlativo,idsucursal_producto,cantidad_paquete
from bd_facturacion.detalles_ventas_ticket a, bd_facturacion.ventas_tickets vt
where a.idventa_ticket=vt.idventa_ticket
;

select * from detalles_ventas_ticket;

/*empleados*/
insert into bd_facturacion2.empleados (idempleado, nombres, apellidos,dui,nit,genero,idcargo,telefono,correo)
select a.idempleado, a.nombres, a.apellidos,a.dui,a.nit,a.genero,a.idcargo,a.telefono,a.correo
from bd_facturacion.empleados a
;

/*empleados*/
insert into bd_facturacion2.presentaciones_productos (idpresentacion_producto, idsucursal_producto, idpresentacion,cantidad_unidades,precio,tipo,prioridad,estado)
select a.idpresentacion_producto, a.idsucursal_producto, a.idpresentacion,a.cantidad_unidades,a.precio,a.tipo,a.prioridad,1
from bd_facturacion.presentaciones_productos a
;

/*empleados_sucursales*/
insert into bd_facturacion2.empleados_sucursales (idempleado_sucursal, idsucursal, idempleado)
select a.idempleado_sucursal, a.idsucursal, a.idempleado
from bd_facturacion.empleados_sucursales a
;

/*estantes*/
insert into bd_facturacion2.estantes (idestante, nombre, descripcion)
select a.idestante, a.nombre, a.descripcion
from bd_facturacion.estantes a
;

/*grupos*/
insert into bd_facturacion2.grupos (idgrupo, nombre, descripcion)
select a.idgrupo, a.nombre, a.descripcion
from bd_facturacion.grupos a
;

/*marcas*/
insert into bd_facturacion2.marcas (idmarca, nombre, descripcion)
select a.idmarca, a.nombre, a.descripcion
from bd_facturacion.marcas a
;

/*marcas*/
insert into bd_facturacion2.permisos (idpermiso, nombre, descripcion,nombre_control)
select a.idpermiso, a.nombre, a.descripcion,a.nombre_control
from bd_facturacion.permisos a
;

/*permisos_grupos*/
insert into bd_facturacion2.permisos_grupos (idpermiso_usuario, idgrupo, idpermiso)
select a.idpermiso_usuario, a.idgrupo, a.idpermiso
from bd_facturacion.permisos_grupos a
;

/*marcas*/
insert into bd_facturacion2.presentaciones (idpresentacion, nombre_presentacion, descripcion,estado)
select a.idpresentacion, a.nombre_presentacion, a.descripcion,1
from bd_facturacion.presentaciones a
;

/*productos*/
insert into bd_facturacion2.productos (idproducto, nom_producto, fecha_ingreso,idcategoria,idmarca,idestante)
select a.idproducto, a.nom_producto,a.fecha_ingreso,a.idcategoria,a.idmarca,a.idestante
from bd_facturacion.productos a
;

/*productos_codigos*/
insert into bd_facturacion2.productos_codigos (idproducto, idcodigo)
select a.idproducto, codi.idcodigo
from bd_facturacion.productos a, bd_facturacion2.codigos codi
where a.cod_producto=codi.codigo
;

/*proveedores_productos*/
insert into bd_facturacion2.proveedores_productos (idproveedor_producto, idproveedor, idproducto)
select a.idproveedor_producto, a.idproveedor, a.idproducto
from bd_facturacion.proveedores_productos a
;

/*sucursales_productos*/
insert into bd_facturacion2.sucursales_productos (idsucursal_producto, idsucursal, idproducto,idutilidadMayoreo,idutilidadDetalles,idestante,existencias,precio_venta,precio_compra,precio_ventaM,precio_compraM,kardex)
select a.idsucursal_producto, a.idsucursal,a.idproducto,a.idutilidadMayoreo,a.idutilidadDetalles,a.idestante,a.existencias,a.precio_venta,a.precio_compra,a.precio_ventaM,a.precio_compraM,a.kardex
from bd_facturacion.sucursales_productos a
;

/*tipos de compras*/
insert into bd_facturacion2.tipo_compras (idtipo_compra, nombre, descripcion)
select a.idtipo_compra, a.nombre, a.descripcion
from bd_facturacion.tipo_compras a
;

/*tipos de factura*/
insert into bd_facturacion2.tipos_facturas (idtipo_factura, nombre)
select a.idtipo_factura, a.nombre
from bd_facturacion.tipos_facturas a
;

/*formas de pago*/
insert into bd_facturacion2.formas_pagos (idforma_pago, nombre_pago)
select a.idforma_pago, a.nombre_pago
from bd_facturacion.formas_pagos a
;


/*Usuarios*/
insert into bd_facturacion2.usuarios (idusuario, usuario,contrasena,idempleado_sucursal,idgrupo,fecha_creacion,estado)
select a.idusuario, a.usuario,a.contrasena,a.idempleado_sucursal,a.idgrupo,a.fecha_creacion,a.estado
from bd_facturacion.usuarios a
;

/*utilidades_compras*/
insert into bd_facturacion2.utilidades_compras (idutilidad_compra, nombre,porcentaje,idtipo_compra)
select a.idutilidad_compra, a.nombre,a.porcentaje,a.idtipo_compra
from bd_facturacion.utilidades_compras a
;

/*ventas_ticket*/
insert into bd_facturacion2.ventas_tickets (correlativo, idforma_pago, idsucursal,fecha,idusuario,monto_total_neto,descuentos,monto_total,idcita,efectivo,cambio,idcliente,idcorrelativo)
select a.correlativo, a.idforma_pago,a.idsucursal,a.fecha,a.idusuario,a.monto_total_neto,a.descuentos,a.monto_total,a.idcita,a.efectivo,a.cambio,a.idcliente,a.idcorrelativo
from bd_facturacion.ventas_tickets a
;

/*ventas*/
insert into bd_facturacion2.ventas (idventa, num_ticket,fecha,idsucursal,anulacion)
select a.idventa, vt.correlativo,a.fecha,a.idsucursal,a.anulacion
from bd_facturacion.ventas a, bd_facturacion.ventas_tickets vt
where a.idventa_ticket=vt.idventa_ticket
;















/*Para pasar los estantes*/
insert into bd_facturacion2.sucursales_productos (idsucursal_producto, idsucursal, idproducto, idutilidadMayoreo, idutilidadDetalles, idestante, existencias, precio_venta, precio_compra, precio_ventaM, precio_compraM, kardex)
select ca.idsucursal_producto, ca.idsucursal, ca.idproducto, ca.idutilidadMayoreo, ca.idutilidadDetalles, ca.idestante, ca.existencias, ca.precio_venta, ca.precio_compra, ca.precio_ventaM, ca.precio_compraM, kardex
from bd_facturacion.sucursales_productos ca;

/*Para pasar las marcas*/
insert into bd_facturacion2.presentaciones_productos (idpresentacion_producto, idsucursal_producto, idpresentacion, cantidad_unidades, precio, tipo, prioridad)
select ca.idpresentacion_producto, ca.idsucursal_producto, ca.idpresentacion, ca.cantidad_unidades, ca.precio, ca.tipo, ca.prioridad
from bd_facturacion.presentaciones_productos ca;

/*Para las presentaciones*/
insert into bd_facturacion2.detalles_ventas_ticket (iddetalle, idpresentacion_producto, cantidad, precio_venta, total, utilidad, idventa_ticket, idsucursal_producto, cantidad_paquete )
select iddetalle_ventas_ticket, ca.idpresentacion_producto, ca.cantidad, ca.precio_venta, ca.total, ca.utilidad, vt.correlativo, ca.idsucursal_producto, ca.cantidad_paquete
from bd_facturacion.detalles_ventas_ticket ca, bd_facturacion.ventas_tickets vt
where ca.idventa_ticket=vt.idventa_ticket
;

/*Eliminar los productos que no tienen codigo*/
delete from estantes where descripcion='-';

/*Eliminar los productos de tabla sucursales productos*/
delete from productos where idestante is null;

/*Para los productos*/
insert into bd_facturacion.productos (idproducto, cod_producto, nom_producto, idcategoria, idmarca, idestante)
select ca.idproducto, ca.cod_producto, ca.nombre_producto, ca.idcategoria, ca.idmarca, ca.idestante
from base_productos.productos ca;

/*Agregar productos a las sucursales*/
insert into bd_facturacion.sucursales_productos (idsucursal, idproducto, idestante, idutilidadMayoreo, idutilidadDetalles, existencias, precio_venta, precio_compra, precio_ventaM, precio_compraM)
select "1", p.idproducto, p.idestante,"2", "4", "0", "0.0","0.0","0.0","0.0"
from bd_facturacion.productos p;

/*Agregar estantes a los productos de las sucursales*/
insert into bd_facturacion.sucursales_productos(idutilidadMayoreo, idutilidadDetalles, existencias, precio_venta, precio_compra, precio_ventaM, precio_compraM)
select "1","2", "4", "0", "0.0","0.0","0.0","0.0"
from bd_facturacion.productos p;
