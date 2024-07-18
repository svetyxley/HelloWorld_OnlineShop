-- Make sure the database is not in use
USE master;
GO

-- Close all active connections to the OnlineShop database
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'OnlineShop')
BEGIN
    ALTER DATABASE OnlineShop SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END
GO


-- Delete the database
DROP DATABASE IF EXISTS OnlineShop;
GO

CREATE DATABASE OnlineShop
GO

USE OnlineShop;
GO

CREATE TABLE DiscountCards(
CardId int IDENTITY NOT NULL PRIMARY KEY,
--BuyerId int FOREIGN KEY REFERENCES Buyers(BuyerId),
PecantageDiscount float
)
GO

CREATE TABLE Manufacturer(
ManufacturerID int IDENTITY PRIMARY KEY,
ManufacturerName nvarchar (255),
ManufacturerEDRPOU nvarchar (10)
)
GO

CREATE TABLE Supplier(
SupplierID int IDENTITY PRIMARY KEY,
SupplierName nvarchar (255),
SupplierEDRPOU nvarchar (10)
)
GO

CREATE TABLE Product(
ProductID int IDENTITY PRIMARY KEY,
ProductName nvarchar (255),
--ProductCategoryID int FOREIGN KEY REFERENCES Category(Category_Id),
ProductCategoryID int,
ManufacturerID int FOREIGN KEY REFERENCES Manufacturer(ManufacturerID),
SupplierID int FOREIGN KEY REFERENCES Supplier(SupplierID),
ProductPrice DECIMAL (10,2)
)
GO

CREATE TABLE Stocks(
ProductAmount int,
StockId int IDENTITY NOT NULL PRIMARY KEY,
ProductId int FOREIGN KEY REFERENCES Product(ProductID)
)
GO

CREATE TABLE OrderSupply(
OrderId int IDENTITY NOT NULL PRIMARY KEY,
ProductId int FOREIGN KEY REFERENCES Product(ProductID),
ProductAmount int,
OrderTime datetime,
--BuyerId int FOREIGN KEY REFERENCES Buyers(BuyerId),
)
GO

-- N is used before string values ​​to indicate that it is a Unicode string
INSERT INTO Manufacturer (ManufacturerName, ManufacturerEDRPOU) VALUES
(N'Norven', '1234567890'),
(N'Хладик', '2345678901'),
(N'Hankey Bannister', '3456789012'),
(N'Ariel', '4567890123'),
(N'Philadelphia', '5678901234')
GO

INSERT INTO Supplier (SupplierName, SupplierEDRPOU) VALUES
(N'Supplier A', '1234509876'),
(N'Supplier B', '2345609871'),
(N'Supplier C', '3456709812'),
(N'Supplier D', '4567809123'),
(N'Supplier E', '5678901230');
GO

INSERT INTO Product (ProductName, ProductCategoryID, ManufacturerID, SupplierID, ProductPrice) VALUES
(N'Сьомга Norven філе слабосолена', 1, 1, 1, 10.50),
(N'Морозиво «Хладик»', 2, 2, 2, 15.99),
(N'Віскі Hankey Bannister Original', 1, 3, 3, 299.00),
(N'Гель для прання Ariel Color', 2, 4, 4, 289.00),
(N'Сир Philadelphia оригінальний', 1, 5, 5, 99.00);
GO

INSERT INTO DiscountCards (PecantageDiscount) VALUES
(8.5),
(5.5),
(15.5),
(50),
(3.5);
GO

INSERT INTO Stocks(ProductAmount, ProductId) VALUES
(15, 1),
(10, 3),
(31, 5),
(2, 2),
(12, 4);
GO

INSERT INTO OrderSupply(ProductId, ProductAmount, OrderTime) VALUES
(2, 15, '2024-06-26 18:05:23'),
(3, 10, '2024-06-29 19:07:23'),
(1, 12, '2024-06-30 12:07:35'),
(2, 95, '2024-07-4 13:09:32'),
(5, 45, '2024-06-9 21:10:39');
GO

-- Stored Procedures creation
CREATE PROCEDURE CreateSupplier
    @SupplierName nvarchar(255),
    @SupplierEDRPOU nvarchar(10)
AS
BEGIN
  
    INSERT INTO Supplier (SupplierName, SupplierEDRPOU)
    VALUES (@SupplierName, @SupplierEDRPOU);    
    -- Повернення ідентифікатора нового запису
    SELECT SCOPE_IDENTITY() AS NewSupplierID;
END;
GO

CREATE PROCEDURE GetSupplierByID
    @SupplierID int
AS
BEGIN
    -- Отримання запису з таблиці Supplier
    SELECT SupplierID, SupplierName, SupplierEDRPOU
    FROM Supplier
    WHERE SupplierID = @SupplierID;
END;
GO

CREATE PROCEDURE DeleteSupplierByID
    @SupplierID int
AS
BEGIN
    -- Перевірка, чи існує запис з вказаним SupplierID
    IF EXISTS (SELECT 1 FROM Supplier WHERE SupplierID = @SupplierID)
    -- Видалення запису
    DELETE FROM Supplier
    WHERE SupplierID = @SupplierID;
END;
GO

CREATE PROCEDURE GetManufacturerById
    @ManufacturerID int
AS
BEGIN
    -- Отримання запису з таблиці Supplier
    SELECT ManufacturerID, ManufacturerName, ManufacturerEDRPOU
    FROM Manufacturer
    WHERE ManufacturerID = @ManufacturerID;
END;
GO
