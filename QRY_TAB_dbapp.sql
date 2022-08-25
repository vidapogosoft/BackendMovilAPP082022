USE dbapp
GO
/****** Object:  Table [dbo].[Registrados]    Script Date: 24/8/2022 19:17:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registrados]') AND type in (N'U'))
DROP TABLE [dbo].[Registrados]
GO
/****** Object:  Table [dbo].[Direcciones]    Script Date: 24/8/2022 19:17:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Direcciones]') AND type in (N'U'))
DROP TABLE [dbo].[Direcciones]
GO
/****** Object:  Table [dbo].[Direcciones]    Script Date: 24/8/2022 19:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direcciones](
	[IdDirecciones] [int] IDENTITY(1,1) NOT NULL,
	[IdRegistrado] [int] NOT NULL,
	[Direccion] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDirecciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrados]    Script Date: 24/8/2022 19:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrados](
	[IdRegistrado] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NULL,
	[Nombres] [varchar](200) NULL,
	[Apellidos] [varchar](200) NULL,
	[NombresCompletos] [varchar](400) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRegistrado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Direcciones] ON 
GO
INSERT [dbo].[Direcciones] ([IdDirecciones], [IdRegistrado], [Direccion]) VALUES (1, 11, N'DIRECCION NORTE - TRABAJO')
GO
INSERT [dbo].[Direcciones] ([IdDirecciones], [IdRegistrado], [Direccion]) VALUES (2, 11, N'DIRECCION SUR - DOMICILIO')
GO
INSERT [dbo].[Direcciones] ([IdDirecciones], [IdRegistrado], [Direccion]) VALUES (3, 1, N'DIRECCION TRABAJO')
GO
INSERT [dbo].[Direcciones] ([IdDirecciones], [IdRegistrado], [Direccion]) VALUES (4, 8, N'DIRECCION DOMICILIO')
GO
INSERT [dbo].[Direcciones] ([IdDirecciones], [IdRegistrado], [Direccion]) VALUES (5, 8, N'DIRECCION AGREGADA DESDE API')
GO
INSERT [dbo].[Direcciones] ([IdDirecciones], [IdRegistrado], [Direccion]) VALUES (6, 11, N'DIRECCION AGREGADA DESDE API')
GO
INSERT [dbo].[Direcciones] ([IdDirecciones], [IdRegistrado], [Direccion]) VALUES (7, 10, N'DIRECCION NORTE - DOMICILIO')
GO
SET IDENTITY_INSERT [dbo].[Direcciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Registrados] ON 
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (1, N'0919172551', N'VPR Victor Portugal', N'vidapogosoft', N'VPR Victor Portugal vidapogosoft')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (5, N'0924258130001', N'Sysnnova', N'Solutions', N'Sysnnova Solutions')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (6, N'0919172551001', N'PORTUGAL', N'S.A', N'PORTUGAL S.A')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (8, N'0924258130', N'Luciana', N'Portugal', N'Luciana Portugal')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (9, N'0919172551', N'VICTOR DANIEL', N'PORTUGAL GOROZABEL', N'VICTOR DANIEL PORTUGAL GOROZABEL')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (10, N'0919172551', N'VPR - 3', N'PORTUGAL', N'VPR - 3 PORTUGAL')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (11, N'0919172551', N'VPR - 4', N'PORTUGAL', N'VPR - 4 PORTUGAL')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (12, N'0924258130', N'Victor - MVC', N'Portugal', N'Victor - MVC Portugal')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (13, N'0919172551', N'MVC Taller', N'Asp Net Core', N'MVC Taller Asp Net Core')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (14, N'0924258131', N'Marla', N'Arellano - MVC', N'Marla Arellano - MVC')
GO
INSERT [dbo].[Registrados] ([IdRegistrado], [Identificacion], [Nombres], [Apellidos], [NombresCompletos]) VALUES (15, N'0924258131002', N'CUVIIIC', N'S.A.S', N'CUVIIIC S.A.S')
GO
SET IDENTITY_INSERT [dbo].[Registrados] OFF
GO
