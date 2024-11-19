//Codigo SQL
```sql
create database JQ4B;

use JQ4B;

create table Categorias
(
    Id               tinyint auto_increment primary key,
    Nombre_Categoria varchar(100) not null
);

create table Roles
(
    Id  tinyint auto_increment primary key,
    Rol varchar(100) unique not null
);

create table EncargadoTienda
(
    Id       smallint auto_increment primary key,
    Nombre   varchar(100) not null,
    Apepat   varchar(100) not null,
    Apemat   varchar(100) not null,
    Telefono varchar(15)  not null,
    Correo   varchar(15)  not null,
    Usuario  varchar(50)  not null unique,
    Pwd      varchar(100) not null,
    IdRol    tinyint      not null,
    constraint fk_encargado_rol foreign key (IdRol) references Roles (Id)
);

create table Tiendas
(
    Id            smallint auto_increment primary key,
    Nombre_Tienda varchar(100) not null,
    Direccion     varchar(200) not null,
    Latitud       decimal(18, 2),
    Longitud      decimal(18, 2),
    Telefono      varchar(15)  not null,
    IdEncargado   smallint     not null,
    constraint fk_tiendas_encargados foreign key (IdEncargado) references EncargadoTienda (Id)
);


create table Productos
(
    Id              int auto_increment primary key,
    Nombre_Producto varchar(100)        not null,
    Stock           int     default (1) not null,
    Precio          decimal default (0) not null,
    IdCategoria     tinyint             not null,
    constraint fk_productos_categorias foreign key (IdCategoria) references Categorias (Id)
);

create table ProductosTienda
(
    Id         int auto_increment primary key,
    IdTienda   smallint not null,
    IdProducto int      not null,
    constraint fk_pt_tienda foreign key (IdTienda) references Tiendas (Id),
    constraint fk_pt_prod foreign key (IdProducto) references Productos (Id)
);

create table Clientes
(
    Id       int auto_increment primary key,
    Nombre   varchar(100) not null,
    Apepat   varchar(100) not null,
    Apemat   varchar(100) not null,
    Telefono varchar(15)  not null,
    Correo   varchar(15)  not null,
    Usuario  varchar(50)  not null unique,
    Pwd      varchar(100) not null
);

create table Ventas
(
    Id        int auto_increment primary key,
    Fecha     date not null,
    Hora      time not null,
    IdCliente int  not null,
    constraint fk_ventas_cliente foreign key (IdCliente) references Clientes (Id)
);

create table DetalleVentas
(
    Id         int auto_increment primary key,
    Precio     decimal(18, 2)  not null,
    Cantidad   int default (1) not null,
    IdVenta    int             not null,
    IdProducto int             not null,
    constraint fk_dv_v foreign key (IdVenta) references Ventas (Id),
    constraint fk_dv_p foreign key (IdProducto) references Productos (Id)
);

insert into Categorias (Nombre_Categoria)
values ('Electrodomesticos');
insert into Categorias (Nombre_Categoria)
values ('Electronica');
insert into Categorias (Nombre_Categoria)
values ('Ropa');
insert into Categorias (Nombre_Categoria)
values ('Calzado');
insert into Categorias (Nombre_Categoria)
values ('Hogar');

insert into Roles (Rol)
values ('Administrador');
insert into Roles (Rol)
values ('Encargado');
insert into Roles (Rol)
values ('Cliente');

insert into EncargadoTienda (Nombre, Apepat, Apemat, Telefono, Correo, Usuario, Pwd, IdRol)
values ('Juan', 'Perez', 'Gomez', '1234567890', 'juan@gmail.com', 'juan123', '123456', 2);
insert into EncargadoTienda (Nombre, Apepat, Apemat, Telefono, Correo, Usuario, Pwd, IdRol)
values ('Maria', 'Gomez', 'Perez', '0987654321', 'maria@gmail.com', 'maria123', '123456', 2);

insert into Tiendas (Nombre_Tienda, Direccion, Latitud, Longitud, Telefono, IdEncargado)
values ('Tienda 1', 'Calle 1', 12.123, 12.123, '1234567890', 1);
insert into Tiendas (Nombre_Tienda, Direccion, Latitud, Longitud, Telefono, IdEncargado)
values ('Tienda 2', 'Calle 2', 12.123, 12.123, '0987654321', 2);

insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Lavadora', 10, 1000, 1);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Refrigeradora', 10, 2000, 1);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Televisor', 10, 3000, 2);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Laptop', 10, 4000, 2);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Camisa', 10, 50, 3);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Pantalon', 10, 100, 3);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Zapatos', 10, 150, 4);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Zapatillas', 10, 200, 4);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Cama', 10, 500, 5);
insert into Productos (Nombre_Producto, Stock, Precio, IdCategoria)
values ('Sofa', 10, 1000, 5);

insert into ProductosTienda (IdTienda, IdProducto)
values (1, 1);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 2);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 3);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 4);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 5);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 6);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 7);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 8);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 9);
insert into ProductosTienda (IdTienda, IdProducto)
values (1, 10);
insert into ProductosTienda (IdTienda, IdProducto)
values (2, 1);
insert into ProductosTienda (IdTienda, IdProducto)
values (2, 2);
insert into ProductosTienda (IdTienda, IdProducto)
values (2, 3);
insert into ProductosTienda (IdTienda, IdProducto)
values (2, 4);
insert into ProductosTienda (IdTienda, IdProducto)
values (2, 5);
insert into ProductosTienda (IdTienda, IdProducto)
values (2, 6);

insert into Clientes (Nombre, Apepat, Apemat, Telefono, Correo, Usuario, Pwd)
values ('Pedro', 'Gomez', 'Perez', '1234567890', 'pedro@gmail.com', 'pedro123', '123456');
insert into Clientes (Nombre, Apepat, Apemat, Telefono, Correo, Usuario, Pwd)
values ('Ana', 'Perez', 'Gomez', '0987654321', 'ana@gmail.com', 'ana123', '123456');

insert into Ventas (Fecha, Hora, IdCliente)
values ('2021-01-01', '12:00:00', 1);
insert into Ventas (Fecha, Hora, IdCliente)
values ('2021-01-02', '12:00:00', 2);

insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (1000, 1, 1, 1);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (2000, 1, 1, 2);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (3000, 1, 1, 3);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (4000, 1, 1, 4);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (50, 1, 1, 5);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (100, 1, 1, 6);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (150, 1, 1, 7);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (200, 1, 1, 8);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (500, 1, 1, 9);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (1000, 1, 1, 10);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (1000, 1, 2, 1);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (2000, 1, 2, 2);
insert into DetalleVentas (Precio, Cantidad, IdVenta, IdProducto)
values (3000, 1, 2, 3);
```