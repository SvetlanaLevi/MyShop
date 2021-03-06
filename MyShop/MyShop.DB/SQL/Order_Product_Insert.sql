USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Order_Product_Insert]    Script Date: 03.05.2020 15:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Order_Product_Insert]
    @ProductId int,
	@OrderId int,
	@Value int,
	@LocalPrice money
as
begin
	insert into dbo.[Order_Product] 
    (ProductId,
	OrderId,
	Value,
	LocalPrice)	
	values 
    (@ProductId,
	@OrderId,
	@Value,
	@LocalPrice)

	select SCOPE_IDENTITY()
end
