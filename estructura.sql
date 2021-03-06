USE [master]
GO
/****** Object:  Database [Negocio]    Script Date: 30/12/2019 12:04:48 p.m. ******/
CREATE DATABASE [Negocio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Negocio', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Negocio.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Negocio_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Negocio_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Negocio] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Negocio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Negocio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Negocio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Negocio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Negocio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Negocio] SET ARITHABORT OFF 
GO
ALTER DATABASE [Negocio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Negocio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Negocio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Negocio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Negocio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Negocio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Negocio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Negocio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Negocio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Negocio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Negocio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Negocio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Negocio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Negocio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Negocio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Negocio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Negocio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Negocio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Negocio] SET  MULTI_USER 
GO
ALTER DATABASE [Negocio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Negocio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Negocio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Negocio] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Negocio] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Negocio]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[id_usuario] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NULL,
	[mail] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[fecha_alta] [datetime] NULL,
	[usuario_alta] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[observacion] [varchar](200) NULL,
	[fecha_alta] [datetime] NULL,
	[precio_compra] [decimal](10, 2) NULL,
	[precio_venta] [decimal](10, 2) NULL,
	[usuario_alta] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoXProveedor]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoXProveedor](
	[id_proveedor] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[codigo_producto] [varchar](70) NULL,
	[fecha_alta] [datetime] NULL,
	[usuario_alta] [int] NULL,
 CONSTRAINT [PK_ProductoXProveedor] PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC,
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NULL,
	[observacion] [varchar](100) NULL,
	[mail] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[calle] [varchar](100) NULL,
	[nro_calle] [int] NULL,
	[fecha_alta] [datetime] NULL,
	[usuario_alta] [int] NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[mail] [varchar](100) NULL,
	[telefono] [varchar](50) NULL,
	[habilitado] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[usuario_vendedor] [int] NULL,
	[id_cliente] [int] NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta_Detalle]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta_Detalle](
	[id_venta] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NULL,
	[precio_venta] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Venta_Detalle] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC,
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductoXProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ProductoXProveedor_Producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[ProductoXProveedor] CHECK CONSTRAINT [FK_ProductoXProveedor_Producto]
GO
ALTER TABLE [dbo].[ProductoXProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ProductoXProveedor_Proveedor] FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[Proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[ProductoXProveedor] CHECK CONSTRAINT [FK_ProductoXProveedor_Proveedor]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([usuario_vendedor])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Usuario]
GO
ALTER TABLE [dbo].[Venta_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Detalle_Producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[Venta_Detalle] CHECK CONSTRAINT [FK_Venta_Detalle_Producto]
GO
ALTER TABLE [dbo].[Venta_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Detalle_Venta] FOREIGN KEY([id_venta])
REFERENCES [dbo].[Venta] ([id_venta])
GO
ALTER TABLE [dbo].[Venta_Detalle] CHECK CONSTRAINT [FK_Venta_Detalle_Venta]
GO
/****** Object:  StoredProcedure [dbo].[clienteGetById]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 12/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[clienteGetById]
	@id_cliente int
AS
BEGIN
	SELECT c.*, u.nombre_usuario, u.mail FROM Cliente c inner join Usuario u on u.id_usuario = c.usuario_alta where id_cliente = @id_cliente
END
GO
/****** Object:  StoredProcedure [dbo].[clienteGetExistente]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 14/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[clienteGetExistente]
	@descripcion varchar(200),
	@mail varchar(100),
	@telefono varchar(20)
AS
BEGIN
	SELECT * 
	FROM Cliente
	WHERE
	descripcion = @descripcion
	and mail = @mail
	and telefono = @telefono
END


GO
/****** Object:  StoredProcedure [dbo].[clienteInsert]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 14/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[clienteInsert]
	@descripcion varchar(200),
	@mail varchar(100),
	@telefono varchar(20),
	@fecha_alta datetime,
	@usuario_alta int
AS
BEGIN
	INSERT INTO Cliente
	(descripcion, mail, telefono, fecha_alta, usuario_alta)
	VALUES
	(@descripcion, @mail, @telefono, @fecha_alta, @usuario_alta)

	select @@IDENTITY
END


GO
/****** Object:  StoredProcedure [dbo].[productosGetAll]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 14/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[productosGetAll]

AS
BEGIN
	SELECT *
	FROM Producto
END


GO
/****** Object:  StoredProcedure [dbo].[productosGetByNombre]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 14/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[productosGetByNombre]
	@nombre varchar(100)
AS
BEGIN
	SELECT *
	FROM Producto
	WHERE nombre like '%' + @nombre + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[productosGetByNombreObservacion]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 14/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[productosGetByNombreObservacion]
	@nombre varchar(100),
	@observacion varchar(200)
AS
BEGIN
	SELECT *
	FROM Producto
	WHERE nombre = @nombre
	and observacion = @observacion

END


GO
/****** Object:  StoredProcedure [dbo].[productosInsert]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 14/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[productosInsert]
	@nombre varchar(100),
	@observacion varchar(200),
	@precio_compra decimal(10,2),
	@precio_venta decimal(10,2),
	@fecha_alta datetime,
	@usuario_alta int
AS
BEGIN
	
INSERT INTO [dbo].[Producto]
           ([nombre]
           ,[observacion]
           ,[fecha_alta]
           ,[precio_compra]
           ,[precio_venta]
           ,[usuario_alta])
     VALUES
           (@nombre
           ,@observacion
           ,@fecha_alta
           ,@precio_compra
           ,@precio_venta
           ,@usuario_alta)

END


GO
/****** Object:  StoredProcedure [dbo].[proveedorGetById]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 14/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[proveedorGetById]
	@id_proveedor int
AS
BEGIN
	SELECT *
	FROM Proveedor
	WHERE id_proveedor = @id_proveedor

END


GO
/****** Object:  StoredProcedure [dbo].[usuarioGetByLogin]    Script Date: 30/12/2019 12:04:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brizuela Marcelo
-- Create date: 09/12/2019
-- =============================================
CREATE PROCEDURE [dbo].[usuarioGetByLogin]
	@nombre_usuario varchar(100),
	@password varchar(100)
AS
BEGIN
	SELECT *, 
		case 
			when a.id_usuario is null then 0
			when a.id_usuario  is not null then 1
		end administrador
	FROM Usuario u
	left join Administrador a on a.id_usuario = u.id_usuario
	where 
		nombre_usuario = RTRIM(@nombre_usuario)
	and
		password = @password
	and
		habilitado = 1

END
GO
USE [master]
GO
ALTER DATABASE [Negocio] SET  READ_WRITE 
GO
