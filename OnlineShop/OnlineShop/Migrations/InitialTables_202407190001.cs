﻿using FluentMigrator;

namespace OnlineShop.Data.Migrations
{
    [Migration(202407190001)]
    public class InitialTables_202407190001 : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Execute.Sql(@"
            CREATE PROCEDURE CreateSupplier
              @SupplierName nvarchar(255),
              @SupplierEDRPOU nvarchar(10)
             AS
             BEGIN
              DECLARE @InsertedSupplier TABLE (
               SupplierID int,
               SupplierName nvarchar(255),
               SupplierEDRPOU nvarchar(10)
              );

              INSERT INTO Supplier (SupplierName, SupplierEDRPOU)
              OUTPUT INSERTED.SupplierID, INSERTED.SupplierName, INSERTED.SupplierEDRPOU
              INTO @InsertedSupplier
              VALUES (@SupplierName, @SupplierEDRPOU);

              SELECT * FROM @InsertedSupplier;
            END;
            GO

            CREATE PROCEDURE GetSupplierByID
              @SupplierID int
             AS
            BEGIN
              SELECT SupplierID, SupplierName, SupplierEDRPOU
              FROM Supplier
              WHERE SupplierID = @SupplierID;
            END;
            GO

            CREATE PROCEDURE DeleteSupplierByID
              @SupplierID int
            AS
            BEGIN
              IF EXISTS (SELECT 1 FROM Supplier WHERE SupplierID = @SupplierID)
              DELETE FROM Supplier
              WHERE SupplierID = @SupplierID;
            END;
            GO

            CREATE PROCEDURE GetManufacturerById
              @ManufacturerID int
             AS
            BEGIN
              SELECT ManufacturerID, ManufacturerName, ManufacturerEDRPOU
              FROM Manufacturer
              WHERE ManufacturerID = @ManufacturerID;
            END;
            GO

            CREATE PROCEDURE GetAllManufacturersWithProducts
            AS
            BEGIN
              SELECT m.*, p.* FROM Manufacturer m
              JOIN Product p ON p.ManufacturerID=m.ManufacturerID
            END
            GO
        ");
        }

    }
}