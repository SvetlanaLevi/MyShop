USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Order_Product_SelectByOrderId]    Script Date: 03.05.2020 15:45:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Order_Product_SelectByOrderId]
    @orderId int
as
begin
	select Order_Product.Id
	  ,[Value]
	  ,[LocalPrice]
	  ,Product.Id
	  ,Product.Model
	  ,Product.Brand
	  from Order_Product
	  inner join Product on ProductId = Product.Id
	  inner join [Order] on OrderId = [Order].Id
	  where [Order].Id=@orderId
end

--exec [Order_Product_SelectByOrderId] 5
 