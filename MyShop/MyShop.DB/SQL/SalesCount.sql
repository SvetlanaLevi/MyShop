USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[SalesCount]    Script Date: 03.05.2020 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SalesCount]
@CountryId int
AS
BEGIN
	select SUM(P.Price) from [Order_Product] OP 
	join [Order] O on OP.OrderId = O.Id 
	join Product P on P.Id = OP.ProductId 
	join Representative R on R.Id = O.RepId
	join City C on R.CityId = C.Id
	join Country Con on C.CountryId = Con.Id
	where Con.Id = @CountryId;
	--Ты хочешь узнать сумму заказов в определенной стране
END
