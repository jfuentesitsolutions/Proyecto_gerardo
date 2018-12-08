use bd_facturacion;
select * from detalle_productos_traslados;
select * from traslados;
select * from detalles_ventas_ticket;
select * from productos;
select * from sucursales_productos;
select * from detalles_ventas_ticket;
select * from presentaciones_productos;

select sp.idsucursal, sp.idproducto, sp.idutilidadMayoreo, sp.idutilidadDetalles, sp.idestante, sp.existencias, sp.precio_venta, sp.precio_compra, sp.precio_ventaM, sp.precio_compraM, sp.kardex from sucursales_productos sp;

select p.cod_producto, p.nom_producto, p.fecha_ingreso,p.idcategoria,p.idmarca,p.idestante from productos p where idproducto>3404;

select  p.nombre_control
from permisos_grupos pg, grupos g, permisos p
where pg.idgrupo = g.idgrupo and pg.idpermiso = p.idpermiso and pg.idgrupo = '1' and p.nombre_control like 'nego%'; 

ALTER TABLE `bd_facturacion`.`detalles_compras` 
ADD COLUMN `precio_venta_m` DOUBLE(6,2) NOT NULL AFTER `idutilidadDetalle`,
ADD COLUMN `precio_venta_d` DOUBLE(6,2) NOT NULL AFTER `precio_venta_m`,
ADD COLUMN `cantidad_paquete` DOUBLE(6,2) NOT NULL AFTER `precio_venta_d`;

select  p.nombre_control
from permisos_grupos pg, grupos g, permisos p
where pg.idgrupo = g.idgrupo and pg.idpermiso = p.idpermiso and pg.idgrupo = '1' and p.nombre_control like 'nego%'
;

select pp.idsucursal_producto as idsp ,pr.cod_producto as codigo, pr.nom_producto as nombre, count(*) as cantipre, concat(pr.cod_producto,' < -|-> ',pr.nom_producto) as productoCod,
pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
pp.tipo, concat('$',pp.precio) as pre, u.idutilidad_compra as idud, uu.idutilidad_compra as idum
from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu
where pp.idsucursal_producto = sp.idsucursal_producto and pp.idpresentacion = p.idpresentacion and sp.idproducto = pr.idproducto and
sp.idsucursal = '6' and sp.idutilidadDetalles = u.idutilidad_compra and sp.idutilidadMayoreo = uu.idutilidad_compra
group by pr.nom_producto
; 

/*presentaciones de productos por id*/
select *
from presentaciones_productos pp
where pp.idsucursal_producto='10175'
;


