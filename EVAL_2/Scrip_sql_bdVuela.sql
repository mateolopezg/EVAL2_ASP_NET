USE [bd_vuela]
GO
/****** Object:  Table [dbo].[avion]    Script Date: 29-05-2021 6:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[avion](
	[id_avion] [int] NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[vuelo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_avion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pasajero]    Script Date: 29-05-2021 6:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pasajero](
	[id_pasajero] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[pasaje] [int] NOT NULL,
	[vuelo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pasajero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pasajes]    Script Date: 29-05-2021 6:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pasajes](
	[id_pasajes] [int] NOT NULL,
	[lugar_despegue] [varchar](50) NOT NULL,
	[lugar_arribo] [varchar](50) NOT NULL,
	[vuelo] [int] NULL,
	[fecha_despegue] [date] NULL,
	[fecha_arribo] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pasajes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vuelo]    Script Date: 29-05-2021 6:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vuelo](
	[id_vuelo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_vuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[avion]  WITH CHECK ADD FOREIGN KEY([vuelo])
REFERENCES [dbo].[vuelo] ([id_vuelo])
GO
ALTER TABLE [dbo].[pasajero]  WITH CHECK ADD FOREIGN KEY([pasaje])
REFERENCES [dbo].[pasajes] ([id_pasajes])
GO
ALTER TABLE [dbo].[pasajero]  WITH CHECK ADD FOREIGN KEY([vuelo])
REFERENCES [dbo].[vuelo] ([id_vuelo])
GO
ALTER TABLE [dbo].[pasajes]  WITH CHECK ADD FOREIGN KEY([vuelo])
REFERENCES [dbo].[vuelo] ([id_vuelo])
GO
/****** Object:  StoredProcedure [dbo].[SP_consultaIdVuelos]    Script Date: 29-05-2021 6:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_consultaIdVuelos]
	@vuelo INT
AS

BEGIN
	SET NOCOUNT ON;
	Select * from pasajes where vuelo = @vuelo;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_consultaRut]    Script Date: 29-05-2021 6:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Mateo López
-- Create date: 24-05-2021
-- Description: Obtener por ID o rut datos del vuelo totales
-- =============================================

CREATE PROCEDURE [dbo].[SP_consultaRut]
	@id INT
AS

BEGIN
	SET NOCOUNT ON;
	select * FROM pasajero e 
		JOIN pasajes j ON e.pasaje = j.id_pasajes 
		JOIN vuelo v ON v.id_vuelo = j.vuelo
		JOIN avion a ON a.vuelo = v.id_vuelo
		WHERE e.id_pasajero = @id;
END
GO
