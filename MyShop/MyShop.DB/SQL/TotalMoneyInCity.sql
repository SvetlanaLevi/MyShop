USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[TotalMoneyInCity]    Script Date: 03.05.2020 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[TotalMoneyInCity] 
@CityId int
AS
BEGIN
	select SUM(SP.[Value]*P.Price) as [Money]
	from Storage_Product SP
	join Product P on P.Id = SP.ProductId 
	join Storage S on S.Id = SP.StorageId
	join Representative R on S.RepId = R.Id 
	join City C on R.CityId = C.Id  
	where C.Id = @CityId
END
