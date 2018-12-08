use bd_facturacion;
select * from presentaciones_productos;

SELECT g.nombre, p.nombre FROM grupos g
INNER JOIN permisos_grupos pu ON g.idgrupo = pu.idgrupo
INNER JOIN permisos p ON p.idpermiso = pu.idpermiso 
;

/*Para mostrar los permisos asignado a un grupos*/
select g.nombre, p.idpermiso, p.nombre as nombreP, p.nombre_control, pg.idpermiso_usuario
from permisos_grupos pg, grupos g, permisos p
where pg.idgrupo=g.idgrupo and pg.idpermiso=p.idpermiso and pg.idgrupo='25'
;

/*Para mostrar los permisos que no han sido asigandos a los grupos*/
select p.idpermiso, p.nombre, p.nombre_control
from permisos p
where p.idpermiso not in (select pg.idpermiso from permisos_grupos pg where pg.idgrupo='24')
;

/*Para mostrar el nosbres de los controles*/
select  p.nombre_control
from permisos_grupos pg, grupos g, permisos p
where pg.idgrupo=g.idgrupo and pg.idpermiso=p.idpermiso and pg.idgrupo='1' and p.nombre_control like "btn%"
;

/*Para mostrar las sucursales*/
select s.idsucursal, s.numero_de_sucursal, s.direccion, s.telefono, s.idencargado, concat(e.nombres,' ',e.apellidos) as Nencargado
from sucursales s, empleados e
where s.idencargado=e.idempleado
;

/*Para mostrar los empleados*/
select e.idempleado ,e.nombres, e.apellidos, e.dui, e.nit, e.idcargo, c.nombre_cargo, e. telefono, e.correo, 
e.genero, s.numero_de_sucursal, es.idempleado_sucursal, s.idsucursal
from  empleados_sucursales es, sucursales s ,empleados e, cargos c
where es.idempleado=e.idempleado and es.idsucursal=s.idsucursal and e.idcargo=c.idcargo
;

/*Para mostrar los datos de los usuarios*/
select u.idusuario, u.usuario, u.idempleado_sucursal, concat(e.nombres," ", e.apellidos) as nombres,
u.idgrupo, u.estado, g.nombre
from usuarios u, empleados_sucursales es, empleados e, sucursales s, grupos g
where u.idempleado_sucursal=es.idempleado_sucursal and u.idgrupo=g.idgrupo
and es.idempleado=e.idempleado and es.idsucursal=s.idsucursal
;

/*Para mostrar los empleados por sucursal*/
select es.idempleado_sucursal, concat(e.nombres, ' ',e.apellidos) as nombres
from empleados_sucursales es, empleados e, sucursales s
where es.idempleado=e.idempleado and es.idsucursal=s.idsucursal
;
/*Mostrar los datos de los usuarios validados*/
select u.usuario, concat(e.nombres, ' ', e.apellidos) as nomEmplea, e.genero, g.nombre, c.nombre_cargo, g.idgrupo 
from usuarios u, empleados_sucursales es, grupos g, sucursales s, empleados e, cargos c
where u.idempleado_sucursal=es.idempleado_sucursal and u.idgrupo=g.idgrupo and
es.idsucursal=s.idsucursal and es.idempleado=e.idempleado and e.idcargo=c.idcargo and u.usuario='jfuentes' and u.contraseña=md5('1') and u.estado=1
;

/*Para mostrar los datos de las utilidades*/
select uc.idutilidad_compra, uc.nombre, uc.porcentaje*100 as porcen, uc.porcentaje, uc.idtipo_compra, tc.nombre as nombreT
from utilidades_compras uc, tipo_compras tc
where uc.idtipo_compra=tc.idtipo_compra
;

/*Para mostrar los datos de las utilidades por tipo de compra*/
select uc.idutilidad_compra, uc.nombre, uc.porcentaje*100 as porcen, uc.porcentaje, uc.idtipo_compra, tc.nombre as nombreT
from utilidades_compras uc, tipo_compras tc
where uc.idtipo_compra=tc.idtipo_compra and tc.idtipo_compra='1'
;

/*Cargar cuentas de bancos de los proveedores*/
select  cp.idcuenta_proveedor, b.nombre, cp.numero_cuenta, p.idproveedor, b.idbanco
from cuentas_proveedores cp, proveedores p, bancos b
where cp.idproveedor=p.idproveedor and cp.idbanco=b.idbanco and cp.idproveedor='2'
;

/*Cargando productos por sucursal*/
select sp.idsucursal_producto as idSp, p.idproducto as idP ,p.cod_producto as codP,p.nom_producto as nombreP,
c.idcategoria as idC, c.nombre_categoria as nombreC, m.idmarca as idM, m.nombre as nombreM,
s.idsucursal as idS, s.numero_de_sucursal as numeroS, e.idestante as idE, e.nombre as nombreE,
p.fecha_ingreso as fechaI, ucc.idtipo_compra as idUtiM, ucc.nombre as UtiM, ucc.porcentaje as PUtiM,
uc.idutilidad_compra as idUtiD, uc.nombre as UtiD, uc.porcentaje as PUtiD,
sp.precio_compraM as precioCM, sp.precio_compra as precioCD, sp.precio_ventaM as precioVM, sp.precio_venta as precioVD, sp.existencias as exis
from sucursales_productos sp, sucursales s, productos p, utilidades_compras uc, utilidades_compras ucc ,estantes e, categorias c, marcas m
where sp.idsucursal=s.idsucursal 
and sp.idproducto=p.idproducto 
and sp.idutilidadDetalles=uc.idutilidad_compra 
and sp.idutilidadMayoreo=ucc.idutilidad_compra
and sp.idestante=e.idestante and sp.idsucursal='5'
and p.idcategoria=c.idcategoria
and p.idmarca=m.idmarca
;

/*Todos lo productos de las sucursales*/
select sp.idsucursal_producto as idSp, p.idproducto as idP ,p.cod_producto as codP,p.nom_producto as nombreP,
c.idcategoria as idC, c.nombre_categoria as nombreC, m.idmarca as idM, m.nombre as nombreM,
s.idsucursal as idS, s.numero_de_sucursal as numeroS, e.idestante as idE, e.nombre as nombreE,
p.fecha_ingreso as fechaI, ucc.idutilidad_compra as idUtiM, ucc.nombre as UtiM, ucc.porcentaje as PUtiM,
uc.idutilidad_compra as idUtiD, uc.nombre as UtiD, uc.porcentaje as PUtiD,
sp.precio_compraM as precioCM, sp.precio_compra as precioCD, sp.precio_ventaM as precioVM, sp.precio_venta as precioVD, sp.existencias as exis
from sucursales_productos sp, sucursales s, productos p, utilidades_compras uc, utilidades_compras ucc ,estantes e, categorias c, marcas m
where sp.idsucursal=s.idsucursal 
and sp.idproducto=p.idproducto 
and sp.idutilidadDetalles=uc.idutilidad_compra 
and sp.idutilidadMayoreo=ucc.idutilidad_compra
and sp.idestante=e.idestante
and p.idcategoria=c.idcategoria
and p.idmarca=m.idmarca
;

/*Para mostrar las presentaciones por producto*/
select pp.idpresentacion_producto, pp.idpresentacion, p.nombre_presentacion, pp.cantidad_unidades, pp.precio, pp.tipo
from presentaciones_productos pp, sucursales_productos sp, presentaciones p
where pp.idsucursal_producto=sp.idsucursal_producto and pp.idpresentacion=p.idpresentacion and sp.idsucursal_producto='8611'
;

/*Para mostrar los productos por proveedores*/
select pp.idproveedor_producto, pp.idproveedor, p.nombre_proveedor, pr.idproducto
from proveedores_productos pp, proveedores p, productos pr
where pp.idproveedor=p.idproveedor and pp.idproducto=pr.idproducto and pp.idproducto='3039';


/*Para mostrar todos los clientes*/
select *, d.tipo_descuento as nombres_des
from clientes c, descuentos d
where c.iddescuento=d.iddescuento
;

/*Para las consultas de los productos por presentaciones*/
select pp.idsucursal_producto as idsp ,pr.cod_producto as codigo, pr.nom_producto as nombre, count(*) as cantipre, concat(pr.cod_producto," <-|-> ",pr.nom_producto) as productoCod,
pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
pp.tipo, u.idutilidad_compra as idud, uu.idutilidad_compra as idum
from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu
where pp.idsucursal_producto=sp.idsucursal_producto and pp.idpresentacion=p.idpresentacion and sp.idproducto=pr.idproducto
and sp.idutilidadDetalles=u.idutilidad_compra and sp.idutilidadMayoreo=uu.idutilidad_compra
group by pr.nom_producto
;

/*Para las consultas de los productos por presentaciones y por sucursal*/
select pp.idsucursal_producto as idsp ,pr.cod_producto as codigo, pr.nom_producto as nombre, count(*) as cantipre, concat(pr.cod_producto," <-|-> ",pr.nom_producto) as productoCod,
pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
pp.tipo, concat('$',pp.precio) as pre, u.idutilidad_compra as idud, uu.idutilidad_compra as idum
from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu
where pp.idsucursal_producto=sp.idsucursal_producto and pp.idpresentacion=p.idpresentacion and sp.idproducto=pr.idproducto and
sp.idsucursal='5' and sp.idutilidadDetalles=u.idutilidad_compra and sp.idutilidadMayoreo=uu.idutilidad_compra
group by pr.nom_producto
;

/*Para mostrar todas presentaciones de todos los productos*/
select pp.idsucursal_producto as idsp ,pr.cod_producto as codigo, pr.nom_producto as nombre, 
pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
pp.tipo, pp.cantidad_unidades as cin
from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu
where pp.idsucursal_producto=sp.idsucursal_producto and pp.idpresentacion=p.idpresentacion and sp.idproducto=pr.idproducto
and sp.idutilidadDetalles=u.idutilidad_compra and sp.idutilidadMayoreo=uu.idutilidad_compra
;

/*Para mostrar todas presentaciones de todos los productos X sucursal*/
select pp.idsucursal_producto as idsp ,pr.cod_producto as codigo, pr.nom_producto as nombre,
pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
pp.tipo, pp.cantidad_unidades as cin
from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu
where pp.idsucursal_producto=sp.idsucursal_producto and pp.idpresentacion=p.idpresentacion and sp.idproducto=pr.idproducto and
sp.idsucursal='5' and sp.idutilidadDetalles=u.idutilidad_compra and sp.idutilidadMayoreo=uu.idutilidad_compra
;

/*Para mostrar en el ticket*/
select dvt.cantidad_paquete, p.nombre_presentacion, pr.nom_producto,  pp.precio, dvt.total, vt.fecha, vt.correlativo, 
vt.monto_total_neto, vt.efectivo, vt.cambio, ci.contenido, concat(cll.nombre_cliente,' ',cll.apellidos_cliente) as nombre,
cll.direccion, corr.inicio, corr.final, vt.idcorrelativo, pr.cod_producto, sp.kardex
from ventas v, ventas_tickets vt, detalles_ventas_ticket dvt, presentaciones_productos pp, sucursales_productos sp, presentaciones p,
productos pr, citas ci, clientes cll, correlativos_ticket corr
where v.idventa_ticket=vt.idventa_ticket 
and dvt.idventa_ticket=vt.idventa_ticket 					
and dvt.idpresentacion_producto=pp.idpresentacion_producto
and pp.idsucursal_producto=sp.idsucursal_producto
and sp.idproducto=pr.idproducto
and pp.idpresentacion=p.idpresentacion
and dvt.idventa_ticket='70'
and vt.idcita=ci.idcita
and vt.idcliente=cll.idcliente
and vt.idcorrelativo=corr.idcorrelativo_ticket
;

/*Para mostrar los ticket en que ya han sido ingresados*/
select vt.idventa_ticket, vt.correlativo, vt.fecha, concat(c.nombre_cliente,' ',c.apellidos_cliente) as nombre, v.idventa
from ventas v, ventas_tickets vt, clientes c
where v.idventa_ticket=vt.idventa_ticket and vt.idcliente=c.idcliente
and v.anulacion=1 and v.fecha>='2018-06-25 00:00:00' and v.fecha<='2018-06-25 23:60:00'
order by vt.fecha desc 
;

/*Para mostrar la venta del dia*/
select concat('T',v.idventa_ticket) as ticket, vt.correlativo, vt.fecha, vt.monto_total
from ventas v, ventas_tickets vt
where v.idventa_ticket=vt.idventa_ticket and v.fecha>='2018-06-22 00:00:00' and v.fecha<='2018-06-22 23:60:00'
union
select concat('F',v.idventa_factura) as ticket, vf.numero_factura, vf.fecha, vf.monto_total
from ventas v, ventas_factura vf
where v.idventa_factura=vf.idventa and v.fecha>='2018-06-22 00:00:00' and v.fecha<='2018-06-22 23:60:00'
;

/*Para mostrar los clientes*/
select *, d.tipo_descuento as nombres_des, concat(c.nombre_cliente, " ", c.apellidos_cliente) as nom
from clientes c, descuentos d
where c.iddescuento = d.iddescuento
;

/*Ingreso de correlativos de ticket*/
select ct.idcorrelativo_ticket as idc, s.numero_de_sucursal as nus, ct.numero_siguiente as ns, ct.final as f, ct.activos as act
from correlativos_ticket ct, sucursales s
where ct.idsucursal=s.idsucursal
;

/*Para la anulacion de tickets*/
select vt.correlativo, v.fecha, concat(c.nombre_cliente," ",c.apellidos_cliente) as nom, p.nom_producto, pre.nombre_presentacion,
dvt.cantidad_paquete, dvt.precio_venta, dvt.total, vt.monto_total_neto, vt.efectivo, vt.cambio, u.usuario, fp.nombre_pago
from ventas v, ventas_tickets vt, detalles_ventas_ticket dvt, sucursales_productos sp, presentaciones_productos pp,
clientes c, productos p, presentaciones pre, usuarios u, formas_pagos fp
where v.idventa_ticket=vt.idventa_ticket
and vt.idcliente=c.idcliente
and dvt.idventa_ticket=vt.idventa_ticket
and vt.idusuario=u.idusuario
and vt.idforma_pago=fp.idforma_pago
and dvt.idsucursal_producto=sp.idsucursal_producto
and dvt.idpresentacion_producto=pp.idpresentacion_producto
and sp.idproducto=p.idproducto
and pp.idpresentacion=pre.idpresentacion
and v.idventa='109'
;

/*mostrar las existencias por idventa*/
select sp.existencias, sp.idsucursal_producto, dvt.cantidad
from ventas v, detalles_ventas_ticket dvt, sucursales_productos sp
where v.idventa_ticket=dvt.idventa_ticket
and dvt.idsucursal_producto=sp.idsucursal_producto
and v.anulacion=1
and v.idventa='109'
;

/*Para la presentancion mas grande*/
select pp.idsucursal_producto as idsp, concat(p.nombre_presentacion,"x",pp.cantidad_unidades) as nombre, pp.cantidad_unidades, pp.idpresentacion_producto
from presentaciones_productos pp, presentaciones p
where pp.idpresentacion=p.idpresentacion and pp.idsucursal_producto='8915' order by pp.cantidad_unidades desc
;

select pp.idsucursal_producto as idsp, pp.cantidad_unidades, concat(p.nombre_presentacion,"x",pp.cantidad_unidades) as nombre
from presentaciones_productos pp, presentaciones p
where pp.cantidad_unidades=(select max(cantidad_unidades) from presentaciones_productos where idsucursal_producto='8915') and pp.idpresentacion=p.idpresentacion
;

/*Para mostrar las compras por numero de factura*/
select c.fecha_ingreso, fc.numero_factura, tf.nombre, u.usuario, p.nombre_proveedor, fc.monto_total_neto,
fc.descuento_iva, fc.monto_total, prese.nombre_presentacion, pp.nom_producto, dt.cantidad, dt.cantidad_paquete,
dt.precio_compra_m, dt.precio_compra_d, sp.idsucursal_producto, s.numero_de_sucursal, dt.total, sp.existencias, c.idcompra
from compras c, facturas_compras fc, detalles_compras dt, tipos_facturas tf, usuarios u,
proveedores p, sucursales_productos sp, productos pp, presentaciones_productos prp, presentaciones prese,
sucursales s
where c.idfactura=fc.idfactura_compra and dt.idfactura_compra=fc.idfactura_compra
and fc.idtipofactura=tf.idtipo_factura and fc.idusuario=u.idusuario
and fc.idproveedor=p.idproveedor and dt.idsucursal_producto=sp.idsucursal_producto
and sp.idproducto=pp.idproducto and dt.presentacion_producto=prp.idpresentacion_producto
and prp.idpresentacion=prese.idpresentacion and c.idsucursal=s.idsucursal
and c.anulacion=1 and fc.numero_factura='1997' and c.idsucursal='6'
;

/*Para mostrar los datos de la facturas por dias*/	
select fc.numero_factura
from compras c, facturas_compras fc
where c.idfactura=fc.idfactura_compra and c.anulacion=1
and c.fecha_ingreso>='2018-07-11 00:00:00' and c.fecha_ingreso<='2018-07-11 23:60:00'
;

/*Presentaciones por id*/
select p.nombre_presentacion
from presentaciones p
where p.idpresentacion='1'
;

/*Presentaciones por codigo del productos*/
select p.nombre_presentacion, p.idpresentacion, pp.precio, pp.idpresentacion_producto
from presentaciones_productos pp, presentaciones p, sucursales_productos sp
where pp.idpresentacion=p.idpresentacion and pp.idsucursal_producto=sp.idsucursal_producto
and pp.idsucursal_producto=(select sspp.idsucursal_producto from sucursales_productos sspp, productos p where sspp.idproducto=p.idproducto and p.cod_producto='7401005912016');
;


/*buscar traslado por correlativo*/
select t.idtraslado
from traslados t
where t.correlativos_traslados='TR31000014'
;

show variables like 'max_allowed_packet';

set global max_allowed_packet=33554432;
