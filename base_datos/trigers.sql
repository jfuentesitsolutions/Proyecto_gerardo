select * from detalle_productos_traslados;

drop trigger traslados;


DELIMITER @
CREATE TRIGGER sumas_producto 
BEFORE INSERT ON detalles_compras
FOR EACH ROW
BEGIN
update sucursales_productos set existencias=existencias+new.cantidad, precio_venta=new.precio_venta_d, precio_compra=new.precio_compra_d,
precio_ventaM=new.precio_venta_m, precio_compraM=new.precio_compra_m, idutilidadMayoreo=new.idutilidadMayoreo, idutilidadDetalles=new.idutilidadDetalle where idsucursal_producto=new.idsucursal_producto;
END;
@ DELIMITER 

DELIMITER @
CREATE TRIGGER traslados 
BEFORE INSERT ON detalle_productos_traslados
FOR EACH ROW
BEGIN
if new.recibido > 1 then
update sucursales_productos set existencias=existencias-new.cantidad where idsucursal_producto=new.idsucursal_producto;
else update sucursales_productos set existencias=existencias+new.cantidad where idsucursal_producto=new.idsucursal_producto;
end if;
END;
@ DELIMITER 

CREATE DEFINER=`jfuentes`@`%` TRIGGER `aumenta_producto` BEFORE INSERT ON `detalles_ventas_ticket` FOR EACH ROW BEGIN
update sucursales_productos set existencias=existencias-new.cantidad where idsucursal_producto=new.idsucursal_producto;
END

