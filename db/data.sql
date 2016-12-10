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


--  vehicle body hull
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Body Hull')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (9
           ,5
           ,'Sedan')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (10
           ,5
           ,'Van')


--  colors
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Color')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (11
           ,6
           ,'White')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (12
           ,6
           ,'Silver')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (13
           ,6
           ,'Black')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (14
           ,6
           ,'Grey')


INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (15
           ,6
           ,'Blue')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (16
           ,6
           ,'Red')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (17
           ,6
           ,'Brown')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (18
           ,6
           ,'Green')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (19
           ,6
           ,'Yellow')

-- Fuel
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Fuel')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (20
           ,7
           ,'Gas')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (21
           ,7
           ,'Hybrid')

-- Vehicle Type
INSERT INTO [dbo].[GeneralCatalog]
           ([title])
     VALUES
           ('Vehicle Type')

INSERT INTO [dbo].[GeneralCatalogValue]
           ([id]
           ,[catalog_id]
           ,[title])
     VALUES
           (22
           ,8
           ,'Vehicle')

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


-- VEHICLE BRANDS  (MAKE)

INSERT INTO [dbo].[VehicleMake] ([name])  VALUES ('Audi')
INSERT INTO [dbo].[VehicleMake] ([name])  VALUES ('Chevrolet')
INSERT INTO [dbo].[VehicleMake] ([name])  VALUES ('Ford')
INSERT INTO [dbo].[VehicleMake] ([name])  VALUES ('Mercedes Benz')
INSERT INTO [dbo].[VehicleMake] ([name])  VALUES ('Renault')
INSERT INTO [dbo].[VehicleMake] ([name])  VALUES ('Toyota')

GO

--SELECT * FROM VehicleMake

INSERT INTO [dbo].[VehicleMakeModel] ([make_id],[name]) VALUES (6,'Camry SE')
INSERT INTO [dbo].[VehicleMakeModel] ([make_id],[name]) VALUES (6,'Camry')
INSERT INTO [dbo].[VehicleMakeModel] ([make_id],[name]) VALUES (6,'Camry XSE')
INSERT INTO [dbo].[VehicleMakeModel] ([make_id],[name]) VALUES (6,'Avalon XLE')
GO

