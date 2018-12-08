use bd_facturacion;
select * from citas;

select s.identrada, s.fecha_entrada,  s.id_tipo_documento, td.nombre_documento, s.numero_documento, s.precio_total, s.descuento, s.precio_con_descuento,
p.nombre_comercial, s.idproveedor
from entradas s, tipos_documentos td, proveedores p
where s.id_tipo_documento = td.idtipo_documento and s.idproveedor = p.idproveedor and s.anulado = 2 and s.aprovacion = 1 order by s.fecha_entrada desc
; 

select ass.idanulacion_salida, s.numero_requisicion, uu.nombre, u.usuario, ass.fecha, ass.justificacion
from anulaciones_salidas ass, salidas s, usuarios u, unidades uu
where ass.idsalida=s.idsalida and s.idunidad=uu.idunidad and ass.idusuario=u.idusuario order by ass.fecha desc
;

select ae.idanulacion_entrada,e.numero_documento,p.nombre_comercial,u.usuario,ae.fecha, ae.justificacion 
from anulaciones_entradas ae, entradas e, usuarios u, proveedores p
where ae.identrada=e.identrada and ae.idusuario=u.idusuario and e.idproveedor=p.idproveedor
order by ae.fecha desc                        
;

select e.numero_documento, td.nombre_documento, e.precio_total as total, e.fecha_entrada as fecha, p.nombre_comercial
from entradas e, tipos_documentos td, proveedores p
where e.id_tipo_documento=td.idtipo_documento
and e.idproveedor=p.idproveedor
and e.anulado=2
and e.fecha_entrada>='2018-06-01 00:00:00' 
and e.fecha_entrada<='2018-06-25 23:60:00' 
order by e.fecha_entrada asc
;

select p.cod_proveedor as cod, p.nombre_comercial as nombre, p.telefono as tel, p.direccion as direc, p.nit
from proveedores_categorias pc, proveedores p, categorias c
where pc.idproveedor=p.idproveedor and pc.idcategoria=c.idcategoria
and pc.idcategoria=5	
;

select e.numero_documento as nd, e.precio_total as total, e.fecha_entrada as fecha, td.nombre_documento as docu,
pp.nombre_comercial as nomp, p.cod_producto as cod, p.nombre_producto as nompp, ep.cantidad, ep.precio_compra, ep.precio_total
from entradas_productos ep, entradas e, productos p, tipos_documentos td, proveedores pp
where ep.identrada=e.identrada and ep.idproducto=p.idproducto and e.id_tipo_documento=td.idtipo_documento
and e.idproveedor=pp.idproveedor
and ep.identrada='2'
;

/*Para la anulaciones de ventas*/


