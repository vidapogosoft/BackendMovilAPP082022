
select * from dbapp..Registrados
select * from dbapp..Direcciones

exec dbapp..ConRegistradoDirecciones

exec dbapp..ConRegistradoDireccion '0919172551'

exec dbapp..InsRegistrado '0924258131', 'Marla', 'Arellano 2'


use dbapp
go
alter proc ConRegistradoDirecciones
as
begin
		
		
	select 
	b.IdDirecciones
	,a.IdRegistrado
	, a.Identificacion
	, a.NombresCompletos
	, b.Direccion 
	from dbapp..Registrados a
	join dbapp..Direcciones b on b.IdRegistrado = a.IdRegistrado


end
go

use dbapp
go
create proc ConRegistradoDireccion
@identificacion varchar(max)
as
begin
		
		
	select 
	b.IdDirecciones
	,a.IdRegistrado
	, a.Identificacion
	, a.NombresCompletos
	, b.Direccion 
	from dbapp..Registrados a
	join dbapp..Direcciones b on b.IdRegistrado = a.IdRegistrado
	where a.Identificacion = @identificacion

end
go

use dbapp
go
alter proc InsRegistrado
@identificacion varchar(20),
@Nombres varchar(200),
@Apellidos varchar(200)
as
begin
		
		
	INSERT INTO [dbo].[Registrados]
           ([Identificacion]
           ,[Nombres]
           ,[Apellidos]
           ,[NombresCompletos]
           ,[FechaRegistro])
     VALUES
           (
		   @Identificacion
           ,@Nombres
           ,@Apellidos
           ,CONCAT (@Nombres, space(1), @Apellidos)
           ,getdate())

		select 1 as IdTran, 'EXITO' as Mensaje
end
go
