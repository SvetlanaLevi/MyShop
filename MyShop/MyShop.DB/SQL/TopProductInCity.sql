USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[TopProductInCity]    Script Date: 03.05.2020 16:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[TopProductInCity]

AS
BEGIN
select c.Name as City, 
(select top 1 model from Product 
join Order_Product on [Order_Product].ProductId = Product.Id
join [Order] on OrderId = [Order].Id 
join Representative on RepId = Representative.Id
join City on CityId = City.Id 
where City.Id  = c.Id
group by model 
order by SUM(value) DESC) as Product
from City c;

END

--exec [dbo].[TopProductInCity]