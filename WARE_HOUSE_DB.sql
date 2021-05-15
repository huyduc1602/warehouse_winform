CREATE DATABASE WARE_HOUSE_DB
USE WARE_HOUSE_DB
GO
CREATE TABLE Unit(
	Id INT PRIMARY KEY IDENTITY,
	DisplayName NVARCHAR(255) NOT NULL
)
GO
CREATE TABLE Suplier(
	Id INT PRIMARY KEY IDENTITY,
	DisplayName NVARCHAR(255) NOT NULL,
	TaxCode  NVARCHAR(255) NOT NULL,
	AcountNumber  NVARCHAR(255) NOT NULL,
	Phone NVARCHAR(50) NOT NULL,
	Email NVARCHAR(255) NOT NULL,
	Adress NVARCHAR(255) NOT NULL,
	ContractDate DATETIME DEFAULT(GETDATE()) NOT NULL,
	MoreInfo NVARCHAR(2500),
	Status BIT DEFAULT(0) NOT NULL
)
CREATE TABLE Brand(
	Id INT PRIMARY KEY IDENTITY,
	DisplayName NVARCHAR(255) NOT NULL,
	MoreInfo NVARCHAR(2500),
	Status BIT DEFAULT(0) NOT NULL
)
GO
CREATE TABLE Category(
	Id INT PRIMARY KEY IDENTITY,
	DisplayName NVARCHAR(255) NOT NULL,
	MoreInfo NVARCHAR(2500),
	Status BIT DEFAULT(0) NOT NULL
)
GO

CREATE TABLE Product(
	Id INT PRIMARY KEY IDENTITY,
	Sku VARCHAR(255) NOT NULL,
	DisplayName NVARCHAR(255) NOT NULL,
	Quantity INT DEFAULT(0),
	PurchasePrice float NOT NULL,
	Price float,
	IdUnit INT NOT NULL,
	IdSupplier INT NOT NULL,
	IdBrand INT NOT NULL,	
	IdCategory INT NOT NULL,
	CreatedDate DATETIME DEFAULT(GETDATE()) NOT NULL,
	UpdatedDate DATETIME DEFAULT(GETDATE()),
	Image NVARCHAR(255) NOT NULL,
	MoreInfo  NVARCHAR(255),	
	FOREIGN KEY (IdSupplier)  REFERENCES Suplier(Id),
	FOREIGN KEY (IdBrand)  REFERENCES Brand(Id),
	FOREIGN KEY (IdUnit)  REFERENCES Unit(Id),
	FOREIGN KEY (IdCategory)  REFERENCES Category(Id),
)
GO

CREATE TABLE Customer(
	Id INT PRIMARY KEY IDENTITY,
	DisplayName NVARCHAR(255) NOT NULL,
	Phone NVARCHAR(50),
	Email NVARCHAR(255),
	Adress NVARCHAR(255),	
	ContractDate DATETIME DEFAULT(GETDATE()),
	MoreInfo NVARCHAR(2500),
	Status bit default(0) NOT NULL
)
GO
CREATE TABLE Input(
	Id INT PRIMARY KEY IDENTITY,
	DisplayName NVARCHAR(255) NOT NULL,
	InputDate DATETIME DEFAULT(GETDATE()) NOT NULL,
	TotalQuantity INT DEFAULT(0),
	TotalPrice FLOAT DEFAULT(0),
	Status bit default(0) NOT NULL

)
GO
CREATE TABLE Output(
	Id INT PRIMARY KEY IDENTITY,
	CustomerId INT NOT NULL,
	DisplayName NVARCHAR(255) NOT NULL,
	OutputDate DATETIME DEFAULT(GETDATE()) NOT NULL,
	TotalQuantity INT DEFAULT(0),
	TotalPrice FLOAT DEFAULT(0),
	FOREIGN KEY (CustomerId)  REFERENCES Customer(Id),
	Status bit default(0) NOT NULL
)
GO
CREATE TABLE InputDetail(
	Id INT PRIMARY KEY IDENTITY,
	ProductId INT NOT NULL,
	InputId INT NOT NULL,
	Quantity INT DEFAULT(1) NOT NULL,
	Price FLOAT DEFAULT(0) NOT NULL,
	Status BIT DEFAULT(0) NOT NULL,
	FOREIGN KEY (ProductId)  REFERENCES Product(Id),
	FOREIGN KEY (InputId)  REFERENCES Input(Id),
)
GO
CREATE TABLE OutputDetail(
	Id INT PRIMARY KEY IDENTITY,
	ProductId INT NOT NULL,
	OutputId INT NOT NULL,
	Quantity INT DEFAULT(1) NOT NULL,
	Price FLOAT DEFAULT(0) NOT NULL,
	Status BIT DEFAULT(0) NOT NULL,
	FOREIGN KEY (ProductId)  REFERENCES Product(Id),
	FOREIGN KEY (OutputId)  REFERENCES Output(Id),
	
)
CREATE TABLE Report(
	Id INT PRIMARY KEY IDENTITY,
	ProductId INT NOT NULL,
	InputId INT NOT NULL,
	OutputId INT NOT NULL,
	ReportDate DATETIME DEFAULT(GETDATE())
	FOREIGN KEY (ProductId)  REFERENCES Product(Id),
	FOREIGN KEY (InputId)  REFERENCES Input(Id),
	FOREIGN KEY (OutputId)  REFERENCES Output(Id)
)
GO
INSERT INTO Category(DisplayName,Status) 
VALUES(N'Điện thoại',1),
(N'Laptop',1),
(N'Phụ kiện',0),
(N'Điện thoại',1),
(N'Đồng hồ',1),
(N'Tai nghe',1)
GO
INSERT INTO Unit(DisplayName) 
VALUES (N'Cái'),
(N'Chiếc'),
('Kilogram')

GO

INSERT INTO Suplier
VALUES(N'Công ty TNHH Thái Sơn','22333225',
'235552488','02225256652','thaison@gmail.com'
,N'Hà Tây, Hà Nội',GETDATE(),N'Thái Sơn Group',1),
(N'Công ty TNHH TSG','95624588',
'52255888','09625633282','tsg@gmail.com'
,N'Cầu Giấy, Hà Nội',GETDATE(),N'Công ty phần mềm TSG Việt Nam',1),
(N'Tập đoàn FPT','33658632',
'23366525899','01255563325','fpt@gmail.com'
,N'Cầu Giấy, Hà Nội',GETDATE(),N'Tập đoàn FPT Việt Nam',1)

GO

INSERT INTO Brand 
VALUES ('Samsung',N'Sản phẩm hãng Samsung',1),
('Lenovo',N'Sản phẩm hãng Lenovo',1),
('Apple',N'Sản phẩm hãng Apple',1),
('Acer',N'Sản phẩm hãng Acer',1),
('Panasonic',N'Sản phẩm hãng Panasonic',1)

GO

INSERT INTO Product 
VALUES('PB205215','Máy tính Lenovo 15 2019',15,13000000,20000000,1,2,2,2,GETDATE(),GETDATE(),'pro1.jpg','Bảo hành 12 tháng'),
('PB205215','Máy tính Acer 13 2016',20,8000000,15000000,1,1,3,2,GETDATE(),GETDATE(),'pro2.jpg','Bảo hành 24 tháng'),
('PB205215','Máy tính Macbook 15 2019',35,25000000,30000000,1,1,3,2,GETDATE(),GETDATE(),'pro3.jpg','Bảo hành 36 tháng')


