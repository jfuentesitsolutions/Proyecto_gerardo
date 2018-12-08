use  base_productos;
use bd_facturacion;
select * from productos;

SET SQL_SAFE_UPDATES = 0;

/*Para pasar las categorias de una tabla a otra*/
insert into bd_facturacion.categorias (idcategoria, nombre_categoria, descripcion)
select ca.idcategoria, ca.nombre_categoria, ca.descripcion
from base_productos.categorias ca;

/*Para pasar los estantes*/
insert into bd_facturacion.estantes (idestante, nombre, descripcion)
select ca.idestante, ca.numero_estante, ca.ubicacion
from base_productos.estantes ca;

/*Para pasar las marcas*/
insert into bd_facturacion.marcas (idmarca, nombre, descripcion)
select ca.idmarca, ca.nombre_marca, ca.decripcion
from base_productos.marcas ca;

/*Para las presentaciones*/
insert into bd_facturacion.presentaciones (idpresentacion, nombre_presentacion)
select ca.idpresentacion, ca.nombre_presentacion
from base_productos.presentaciones ca;

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
