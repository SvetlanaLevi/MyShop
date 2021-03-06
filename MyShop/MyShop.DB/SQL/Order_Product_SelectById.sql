USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Order_Product_SelectById]    Script Date: 03.05.2020 15:44:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Order_Product_SelectById]
    @Id int
as
begin
	select Order_Product.Id
	  ,[Value]
	  ,[LocalPrice]
	  ,O.Id
	  ,O.OrderDate
	  ,O.CustomerId
	  ,R.Id
	  ,R.Name
	  ,P.Id
	  ,P.Model
	  ,P.Brand
	  ,P.Price


	  from Order_Product
	  inner join Product P on ProductId = P.Id
	  inner join [Order] O on OrderId = O.Id
	  inner join Representative R on RepId = R.Id
	  where Order_Product.Id=@Id
end

 