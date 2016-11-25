USE [CarRentalEnterprise]
GO
--  contract type
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Contract Type')

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

-- status
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Status')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (3
           ,2
           ,'Active')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (4
           ,2
           ,'Inactive')

--  contract frequency
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Contract Frequency')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (5
           ,3
           ,'Weekly')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (6
           ,3
           ,'Monthly')

--  contract late fee type
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Contract Late Fee Type')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (7
           ,4
           ,'Late fee type 1')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (8
           ,4
           ,'Late fee type 2')

-- SYSTEM USER
INSERT INTO [dbo].[SystemUser]
           ([first_name]
           ,[last_name]
           ,[user_name]
           ,[user_pwd]
           ,[status_id]
           ,[created_on]
           ,[created_by]
           ,[modified_on]
           ,[modified_by])
     VALUES
           ('Jorge'
           ,'Peralta'
           ,'jorge'
           ,'tmp'
           ,3
           ,GETDATE()
           ,1
           ,GETDATE()
           ,1)



-- OWNERS

INSERT INTO [dbo].[Owner]
           ([first_name]
           ,[last_name]
           ,[created_on]
           ,[created_by]
           ,[modified_on]
           ,[modified_by])
     VALUES
           ('Jorge'
           ,'Peralta'
           ,GETDATE()
           ,1
           ,GETDATE()
           ,1)

-- DRIVER

INSERT INTO [dbo].[Driver]
           ([first_name]
           ,[last_name]
           ,[phone]
           ,[address]
           ,[ssn]
           ,[created_on]
           ,[created_by]
           ,[modified_on]
           ,[modified_by])
     VALUES
           ('Pedro'
           ,'Palencia'
           ,'929-499-2967'
           ,'1950 DALY AVE., 5K, BRONX, NY 10460'
           ,'unknown'
           ,GETDATE()
           ,1
           ,GETDATE()
           ,1)


