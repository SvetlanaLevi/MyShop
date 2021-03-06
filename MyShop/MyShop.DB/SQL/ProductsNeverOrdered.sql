USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[ProductsNeverOrdered]    Script Date: 03.05.2020 15:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ProductsNeverOrdered]

AS
BEGIN
	select P.Model, P.Brand, P.Price from Product P 
	left join Order_Product OP on OP.ProductId=P.Id 
	where OP.ProductId is null;
END