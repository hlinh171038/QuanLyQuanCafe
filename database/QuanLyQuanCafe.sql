CREATE DATABASE QuanlyQuanCafe
GO

USE QuanlyQuanCafe
GO


DROP TABLE IF EXISTS BillInfo
DROP TABLE IF EXISTS Bill
DROP TABLE IF EXISTS Food
DROP TABLE IF EXISTS FoodCategory
DROP TABLE IF EXISTS tableFood
DROP TABLE IF EXISTS Account

--FOOD
--TABLE
--FOODCATEGORY
--ACCOUNT
--BILL
--BILLINFO


--table
CREATE TABLE tableFood
(
	id int IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL default N'undefined',
	status NVARCHAR(100) default N'Available',  -- adviable || booked
)
GO

--account
CREATE TABLE Account
(
	--id INT IDENTITY PRIMARY KEY, -- is username
	DisplayName NVARCHAR(100) NOT NULL default N'Anonymous',
	UserName NVARCHAR(100) PRIMARY KEY,
	Password NVARCHAR(1000) NOT NULL default 0,
	Type INT NOT NULL default 0 --1:admin || 0: staff,
)
GO

--foodcategory
CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL Default N'Undefined',
	
)
GO

--food
CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL default N'undefined',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL default 0,

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCAtegory(id)
)

-- bill
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn Date,
	DateCheckOut Date,
	idTable INT NOT NULL,
	status INT NOT NULL Default 0 -- 1:paid / 0:unpaid,

	FOREIGN KEY (idTable) REFERENCES dbo.tableFood(id),

)
GO

--billInfo
CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL default 0,

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.TableFood(id),
)
GO

INSERT dbo.FoodCategory (name) VALUES (N'agricultural products')
INSERT dbo.FoodCategory (name) VALUES (N'seafood')
INSERT dbo.FoodCategory (name) VALUES (N'forest product')
INSERT dbo.FoodCategory (name) VALUES (N'water')

--- food
INSERT dbo.Food (name, idCategory, price) VALUES (N'Sun-dried squid', 2, 120000)
INSERT dbo.Food (name, idCategory, price) VALUES (N'hard clam', 2, 50000)
INSERT dbo.Food (name, idCategory, price) VALUES (N'beef steak', 3, 320000)
INSERT dbo.Food (name, idCategory, price) VALUES (N'fried rice', 1, 20000)
INSERT dbo.Food (name, idCategory, price) VALUES (N'stir fried water spinach', 1, 120000)
INSERT dbo.Food (name, idCategory, price) VALUES (N'7 up', 4, 10000)
INSERT dbo.Food (name, idCategory, price) VALUES (N'string', 4, 15000)
INSERT dbo.Food (name, idCategory, price) VALUES (N'coca', 4, 12000)

----bill
INSERT dbo.Bill (DateCheckIn, DateCheckOut, idTable, status) VALUES (GETDATE(), GETDATE(),2, 0)
INSERT dbo.Bill (DateCheckIn, DateCheckOut, idTable, status) VALUES (GETDATE(), NULL,2, 0)
INSERT dbo.Bill (DateCheckIn, DateCheckOut, idTable, status) VALUES (GETDATE(), GETDATE(),2, 1)

---BILL INFO



SELECT * FROM	dbo.Bill
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Food
SELECT * FROM dbo.FoodCategory