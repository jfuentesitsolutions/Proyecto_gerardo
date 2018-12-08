load data infile "E:\sucursales_producto.txt"
into table sucursales_productos
fields terminated by '->'
lines terminated by '\r\n'
(idsucursal, idproducto, idutilidadMayoreo, idutilidadDetalles, idestante, existencias, precio_venta, precio_compra, precio_ventaM, precio_compraM, kardex);