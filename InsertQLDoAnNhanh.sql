USE BanDoAnNhanh
GO

--------------------------------------------------------------instert

INSERT dbo.FoodCategory VALUES  ( N'Sinh tố')
INSERT dbo.FoodCategory VALUES  ( N'Matcha')
INSERT dbo.FoodCategory VALUES  ( N'Cafe')
INSERT dbo.FoodCategory VALUES  ( N'Soda')
INSERT dbo.FoodCategory VALUES  ( N'Trà')

go
----update foodCategory

go
------Food
INSERT dbo.Food VALUES  ( N'Sinh tố hoa quả', 1, 48000.0 ,'image/001.jpg')
INSERT dbo.Food VALUES  ( N'Sinh tố dâu', 1, 48000.0 ,'image/002.jpg')
INSERT dbo.Food VALUES  ( N'Sinh tố cam', 1, 48000.0 ,'image/003.jpg')
INSERT dbo.Food VALUES  ( N'Sinh tố xoài', 1, 48000.0 ,'image/004.jpg')



INSERT dbo.Food VALUES  ( N'Matcha trà xanh', 2, 48000.0 ,'image/005.jpg')
INSERT dbo.Food VALUES  ( N'Matcha chocolate', 2, 48000.0 ,'image/006.jpg')
INSERT dbo.Food VALUES  ( N'Matcha cam', 2, 48000.0 ,'image/007.jpg')
INSERT dbo.Food VALUES  ( N'Matcha dâu', 2, 48000.0,'image/008.jpg' )
INSERT dbo.Food VALUES  ( N'Matcha bạc hà', 2, 48000.0 ,'image/009.jpg')


INSERT dbo.Food VALUES  ( N'Cafe Nâu', 3, 48000.0,'image/010.jpg' )
INSERT dbo.Food VALUES  ( N'Cafe Đen', 3, 48000.0 ,'image/011.jpg')
INSERT dbo.Food VALUES  ( N'Cafe sữa đá', 3, 48000.0 ,'image/012.jpg')
INSERT dbo.Food VALUES  ( N'Cafe Nóng', 3, 48000.0,'image/013.jpg' )


INSERT dbo.Food VALUES  ( N'Trà thái', 5, 48000.0 ,'image/014.jpg')
INSERT dbo.Food VALUES  ( N'Trà Lipton', 5, 48000.0,'image/015.jpg' )
INSERT dbo.Food VALUES  ( N'Trà gừng', 5, 48000.0,'image/016.jpg' )
INSERT dbo.Food VALUES  ( N'Trà mạn', 5, 48000.0 ,'image/017.jpg')

INSERT dbo.Food VALUES  ( N'Soda Chanh', 4, 48000.0 ,'image/018.jpg')
INSERT dbo.Food VALUES  ( N'Soda Đào', 4, 48000.0,'image/019.jpg' )

go


GO
INSERT dbo.Login
  
VALUES  ( 'admin', -- Name - varchar(50)
          '123',
		  'admin'  -- Pass - varchar(50)
          )
GO
INSERT dbo.Login
    
VALUES  ( 'emp', -- Name - varchar(50)
          '123',
		  'emp'  -- Pass - varchar(50)
          )
GO


INSERT dbo.Coupon
        ( id, description, valueCoupon )
VALUES  ( 'C1', -- id - varchar(50)
          N'Khuyễn mãi 10%', -- description - nvarchar(100)
          '10'  -- valueCoupon - varchar(10)
          )
INSERT dbo.Coupon VALUES  ( 'C2',  N'Khuyễn mãi 20%', '20'  )
GO
INSERT dbo.Coupon VALUES  ( 'C15',  N'Khuyễn mãi 15%', '15'  )
INSERT dbo.Coupon VALUES  ( 'C25',  N'Khuyễn mãi 25%', '25'  )
INSERT dbo.Coupon VALUES  ( 'C35',  N'Khuyễn mãi 35%', '35'  )
GO



INSERT dbo.Employee VALUES  ( N'Hoàng Thanh Thúy', -- name - nvarchar(100)
          '0934234232', -- phone - varchar(11)
          N'Hà nội', -- address - nvarchar(100)
         	  0,
		 
          )

INSERT dbo.Employee
VALUES  ( N'Hoàng Đức Mập', -- name - nvarchar(100)
          '0934234232', -- phone - varchar(11)
          N'Hà nội', -- address - nvarchar(100)
          0,
		 
          )

INSERT dbo.Employee
VALUES  ( N'Nguyễn Thanh Thúy', -- name - nvarchar(100)
          '0934234232', -- phone - varchar(11)
          N'Hà nội', -- address - nvarchar(100)
			  0,
		  
          )

INSERT dbo.Employee
VALUES  ( N'Lưu Thanh Hải', -- name - nvarchar(100)
          '0934234232', -- phone - varchar(11)
          N'Hà nội', -- address - nvarchar(100)
        0,
		 
          )

INSERT dbo.Employee VALUES  ( N'Nguyễn Đức Nhân', '0934244232',N'Hà nội', 1)

GO

-------------------------------------------------------------- insert bill