IF OBJECT_ID('[dbo].[PRODUCT]', 'U') IS NOT NULL
DROP TABLE [dbo].[PRODUCT]
GO
CREATE TABLE [dbo].[PRODUCT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](50) NULL,
	[PRICE] [decimal](18, 2) NULL,
	[BRAND] [varchar](50) NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PRODUCT] ADD  CONSTRAINT [DF_PRODUCT_createdAt]  DEFAULT (getdate()) FOR [createdAt]
GO
/*
//DADOS PARA INSERCAO TESTE
INSERT INTO DBO.PRODUCT (NAME, PRICE, BRAND)
SELECT 'Galaxy s20', 1999.99, 'Samsung'
UNION
SELECT 'Galaxy s21', 2500.99, 'Samsung'
UNION
SELECT 'Galaxy s22', 2999.99, 'Samsung'
UNION
SELECT 'Galaxy s10', 1500.99, 'Samsung'
UNION
SELECT 'Galaxy s9', 1000.99, 'Samsung'
*/
