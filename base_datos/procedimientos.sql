CREATE PROCEDURE ingresando_proveedores_nuevos()
BEGIN
	load data infile "E:\proveedore.txt"
	into table proveedores
	fields terminated by '->'
	lines terminated by '\r\n'
	(cod_proveedor, nombre_proveedor, dui, nit, ncr,direccion,telefono,email)
END;

drop database inventario_amsa;