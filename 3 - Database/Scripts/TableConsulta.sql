USE [AgendaMedica]
GO

/****** Object:  Table [dbo].[Consulta]    Script Date: 26/01/2020 04:21:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Consulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataHoraInicio] [datetime2](7) NOT NULL,
	[DataHoraFinal] [datetime2](7) NOT NULL,
	[Observacoes] [varchar](500) NULL,
	[IdPessoa] [int] NOT NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Pessoa] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO

ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Pessoa]
GO


