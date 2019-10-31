USE [Farm]
GO

/****** Object:  Table [dbo].[Produce]    Script Date: 10/30/2019 7:37:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produce](
	[ProduceID] [int] IDENTITY(1,1) NOT NULL,
	[ProduceName] [varchar](40) NULL,
	[StockQuantity] [int] NULL,
	[CartQuantity] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[InSeason] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProduceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

