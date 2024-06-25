CREATE DATABASE OnlineShop
GO

CREATE TABLE DiscountCards(
CardId int IDENTITY NOT NULL PRIMARY KEY,
--BuyerId int FOREIGN KEY(Buyer) REFERENCES Buyers(BuyerId),
PecantageDiscount float
)
GO

CREATE TABLE Stocks(
--ProductId int FOREIGN KEY(Product) REFERENCES Product(ProductId),
ProductAmount int,
StockId int IDENTITY NOT NULL PRIMARY KEY,
)
GO

CREATE TABLE OrderSupply(
OrderId int IDENTITY NOT NULL PRIMARY KEY,
--ProductId int FOREIGN KEY(Product) REFERENCES Product(ProductId),
ProductAmount int,
OrderTime datetime,
--BuyerId int FOREIGN KEY(Buyer) REFERENCES Buyers(BuyerId),
)
GO



