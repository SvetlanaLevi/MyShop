USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[ProductsOutOfStock]    Script Date: 03.05.2020 15:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ProductsOutOfStock]

AS
BEGIN
	select DISTINCT P.Id, P.Price, P.Brand, P.Model 
	from Order_Product OP
	join Product P on P.Id=OP.ProductId
	left join Storage_Product SP on SP.ProductId = P.Id
END
