USE [CarRentalEnterprise]
GO

INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Contract Type')
GO

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (1
           ,1
           ,'Rental')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (2
           ,1
           ,'Sale')
