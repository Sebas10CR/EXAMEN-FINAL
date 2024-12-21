CREATE TABLE Categoria (
    Id int primary key identity(1,1),
    Nombre varchar(50) NOT NULL UNIQUE
);

insert into Categoria values ( 'Administrador')
insert into Categoria values ( 'Operario')
insert into Categoria values ( 'Peón')
select *from Categoria

CREATE TABLE Empleados (
    Id int primary key identity(1,1),
    NumeroCarnet varchar(50) unique not null,
    Nombre varchar(50) not null,
    FechaNacimiento date not null,
    Categoria varchar(50) foreign key references Categoria(Nombre) not null,
    Salario decimal(10,2) check (Salario BETWEEN 250000 AND 500000) NOT NULL DEFAULT 250000,
    Direccion varchar(100) DEFAULT 'San José',
    Telefono varchar(15),
    Correo varchar(100) UNIQUE NOT NULL
);

CREATE TABLE Proyectos (
    Id int primary key identity(1,1),
    Codigo varchar(50) unique not null,
    Nombre varchar(100) unique not null,
    FechaInicio date not null,
    FechaFin DATE 
);

CREATE TABLE Asignaciones (
    Id int primary key identity(1,1),
    EmpleadoId int not null foreign key references Empleados(Id),
    ProyectoId int not null foreign key references Proyectos(Id),
    FechaAsignacion date not null
);


--PROCESOS

--EMPLEADOS
--AGREGAR

create procedure IngresarEmpleado
 @NumeroCarnet varchar(50),
 @Nombre varchar(100),
 @FechaNacimiento date,
 @Categoria varchar(50),
 @Salario decimal(10, 2),
 @Direccion varchar(100),
 @Telefono varchar(15),
 @Correo varchar(100)
as
begin
insert into Empleados values (@NumeroCarnet, @Nombre, @FechaNacimiento, @Categoria, @Salario, @Direccion, @Telefono, @Correo)
end

---Borrar
create procedure BorrarEmpleado
@Id int

as
begin
delete Empleados where Id=@Id
end

--PROYECTOS
--AGREGAR
create procedure IngresarProyecto
 @Codigo varchar(50),
 @Nombre varchar(100),
 @FechaInicio date,
 @FechaFin date
 
 as
begin
insert into Proyectos values (@Codigo, @Nombre, @FechaInicio, @FechaFin)
end

---Borrar
create procedure BorrarProyecto
@Id int

as
begin
delete Proyectos where Id=@Id
end

--ASIGNACIONES
--AGREGAR
create procedure IngresarAsignacion
 @EmpleadoId int,
 @ProyectoId int,
 @FechaAsignacion date
 
 as
begin
insert into Asignaciones values (@EmpleadoId, @ProyectoId, @FechaAsignacion)
end

---Borrar
create procedure BorrarAsignacion
@Id int

as
begin
delete Asignaciones where Id=@Id
end
