USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[ProductsOnlyInStorage]    Script Date: 03.05.2020 15:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ProductsOnlyInStorage]
@CityId int

AS
BEGIN
	select distinct P.Model, P.Brand, P.Price from Storage_Product SP 
	join Product P on SP.ProductId = P.Id
	join Storage S on SP.StorageId = S.Id
	where SP.ProductId not in 
	(select SP.ProductId from Storage_Product SP 
	join Storage S on SP.StorageId = S.Id
	join Representative R on R.Id=S.RepId 
	where R.CityId = @CityId);
END

--exec [ProductsOnlyInStorage] 4