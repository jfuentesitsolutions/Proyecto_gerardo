use bd_facturacion;
select * from ventas;
select * from sucursales_productos; 
SET SQL_SAFE_UPDATES = 0;

update productos set existencias=1000 where existencias is null;
update sucursales_productos sp, productos p set sp.codigo=p.cod_producto where sp.idproducto=p.idproducto and sp.idsucursal=5;

ALTER TABLE `bd_facturacion`.`presentaciones_productos` 
ADD COLUMN `prioridad` INT NULL AFTER `tipo`;

update presentaciones_productos set prioridad=2 where tipo=2;

select dvt.idsucursal_producto
from ventas v, detalles_ventas_ticket dvt  
where v.idventa_ticket=dvt.idventa_ticket and v.idventa=68 and v.anulacion=1;

DROP TRIGGER IF EXISTS disminuye_producto;


DELIMITER @
CREATE TRIGGER disminuye_producto 
BEFORE INSERT ON detalles_ventas_ticket
FOR EACH ROW
BEGIN
update sucursales_productos set existencias=existencias-new.cantidad where idsucursal_producto=new.idsucursal_producto;
END; @ 
DELIMITER;



