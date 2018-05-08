CREATE database BanDoAnNhanh
go
use BanDoAnNhanh
go

-- danh mục như đồ uống, soda, cafe
CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
)
GO

-- bảng thức ăn 
CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL ,
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	image varchar(50)
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO


CREATE TABLE Login(
	Name VARCHAR(50) NOT NULL,
	Pass VARCHAR(50) NOT NULL,
	Authority VARCHAR(10) DEFAULT 'Emp'

);
GO

-- nhân viên 
create table Employee( 
	id int IDENTITY PRIMARY KEY, 
	name NVARCHAR(100) NOT NULL ,
	phone varchar(11) not null,
	address nvarchar(100) not null ,
	sex bit not null
	
);
go

-- khuyến mãi
create table Coupon(
	id VARCHAR(50) PRIMARY KEY, 
	description NVARCHAR(100) NOT NULL , -- mô tả về coupon được áp dụng
	valueCoupon varchar(10) -- giá trị khuyến mãi bao nhiêu phần trăm
);
go
--hóa đơn
create table Bill(
id INT IDENTITY PRIMARY KEY,
idCoupon VARCHAR(50) REFERENCES dbo.Coupon(id) DEFAULT NULL,
cashier int references Employee(id),
paymentTime date  -- thời gian thanh toán
);
GO

CREATE TABLE BillDetails(
	id INT IDENTITY PRIMARY KEY,
	idBill INT REFERENCES dbo.Bill(id),
	idFood INT REFERENCES dbo.Food(id),
	count int
);
GO

-------------------------------------------create proc
CREATE PROC CheckLogin @name VARCHAR(50), @pass VARCHAR(50)
AS
BEGIN
	SELECT * FROM dbo.Login WHERE Name=@name AND Pass=@pass
END
GO

---------------------------------------- delete Coupon
CREATE PROC proc_Del_Coupon @id VARCHAR(50)
AS
BEGIN
	UPDATE dbo.Bill SET idCoupon=NULL WHERE idCoupon=@id
	DELETE dbo.Coupon WHERE id=@id
END
go


---------------------------------------- delete Employee
CREATE PROC proc_Del_Employee @id int
AS
BEGIN
	UPDATE dbo.Bill SET cashier=NULL WHERE cashier=@id
	DELETE dbo.Employee WHERE id=@id
END
go

---------------------------------------- delete FoodCategory
CREATE PROC proc_del_FoodCategory @id INT
AS
BEGIN
	UPDATE dbo.Food SET idCategory=NULL WHERE idCategory=@id
	DELETE dbo.FoodCategory WHERE id=@id
END
go

EXEC dbo.proc_del_FoodCategory @id = 5 -- int
SELECT * FROM dbo.Food

---------------------------------------------------- insert Bill
GO
CREATE PROC InsertBill 
@idCoupon VARCHAR(50), @idEmp INT , @paymentTime DATE
AS
BEGIN
	
	IF NOT EXISTS(SELECT * FROM dbo.Coupon WHERE id=@idCoupon)
	BEGIN 
			INSERT dbo.Bill
        ( idCoupon, cashier, paymentTime )
		VALUES  ( null, -- idCoupon - varchar(50)
         @idEmp, -- cashier - int
         @paymentTime  -- paymentTime - date
          )
	end 
	ELSE
		BEGIN
					INSERT dbo.Bill
			 ( idCoupon, cashier, paymentTime )
				VALUES  ( @idCoupon, -- idCoupon - varchar(50)
				  @idEmp, -- cashier - int
				 @paymentTime  -- paymentTime - date
          )
		end
   
END
GO


---------------------------------------------------- get max bill
SELECT * FROM dbo.Bill
SELECT * FROM dbo.BillDetails
SELECT * FROM dbo.Coupon 
SELECT * FROM dbo.Employee
SELECT * FROM dbo.Food
SELECT * FROM dbo.FoodCategory
SELECT * FROM dbo.Login

-- thống kê nhân viên bán hàng nhiều nhất
-- thức ăn bán chạy nhất

-- showw ra hóa đơn thanh toán
go
SELECT dbo.Bill.id,dbo.Bill.paymentTime,SUM(dbo.Food.price) AS TongTien 
FROM dbo.BillDetails 
INNER JOIN dbo.Bill ON Bill.id = BillDetails.idBill 
INNER JOIN dbo.Food ON Food.id = BillDetails.idFood
--WHERE dbo.Bill.paymentTime BETWEEN '2018-05-04' AND '2018-05-07'
GROUP BY dbo.Bill.id,paymentTime
ORDER BY TongTien DESC

CREATE PROC ShowBillPaid
@start date, @end date
AS
BEGIN
SELECT dbo.Bill.id,dbo.Bill.idCoupon, dbo.Bill.paymentTime,SUM(dbo.Food.price) AS TongTien
FROM dbo.BillDetails
INNER JOIN dbo.Bill ON Bill.id = BillDetails.idBill 
INNER JOIN dbo.Food ON Food.id = BillDetails.idFood
WHERE dbo.Bill.paymentTime BETWEEN @start AND @end
GROUP BY dbo.Bill.id,paymentTime,dbo.Bill.idCoupon
ORDER BY TongTien DESC
END
GO

--------------test proc
exec ShowBillPaid '2018-01-04' ,'2018-05-08'



GO
-- nhân viên bán hàng nhiều nhất
SELECT dbo.Employee.id,dbo.Employee.name, COUNT(dbo.Bill.id) AS SoLuong FROM dbo.Bill INNER JOIN dbo.Employee ON Employee.id = Bill.cashier
WHERE dbo.Bill.paymentTime BETWEEN @start AND @end
GROUP BY dbo.Employee.id,dbo.Employee.name
ORDER BY SoLuong DESC
GO

CREATE PROC BestEmployee
@start date, @end date
AS
BEGIN
SELECT dbo.Employee.id,dbo.Employee.name, COUNT(dbo.Bill.id) AS SoLuong FROM dbo.Bill INNER JOIN dbo.Employee ON Employee.id = Bill.cashier
WHERE dbo.Bill.paymentTime BETWEEN @start AND @end
GROUP BY dbo.Employee.id,dbo.Employee.name
ORDER BY SoLuong DESC
END
GO

EXEC dbo.BestEmployee @start = '2018-05-07 16:10:12', @end = '2018-05-07 16:10:12'


go
-- món ăn được gọi nhiều nhất
SELECT dbo.Food.name,COUNT(dbo.Food.id) AS SoLuong 
FROM dbo.BillDetails 
INNER JOIN dbo.Bill ON Bill.id = BillDetails.idBill 
INNER JOIN dbo.Food ON Food.id = BillDetails.idFood
WHERE dbo.Bill.paymentTime BETWEEN '2018-05-04' AND '2018-05-07'
GROUP BY dbo.Food.name
ORDER BY  SoLuong DESC

GO
CREATE PROC PopularFood
@start date, @end date
AS
BEGIN
SELECT dbo.Food.name,COUNT(dbo.Food.id) AS SoLuong 
FROM dbo.BillDetails 
INNER JOIN dbo.Bill ON Bill.id = BillDetails.idBill 
INNER JOIN dbo.Food ON Food.id = BillDetails.idFood
WHERE dbo.Bill.paymentTime BETWEEN @start AND @end
GROUP BY dbo.Food.name
ORDER BY  SoLuong DESC
END
GO

EXEC dbo.PopularFood @start = '2018-05-07 16:15:28', -- date
    @end = '2018-05-07 16:15:28' -- date
