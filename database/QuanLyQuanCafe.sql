CREATE DATABASE QuanlyQuanCafe
GO

USE QuanlyQuanCafe
GO

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
	status NVARCHAR(100) default N'advilabel',  -- adviable || booked
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