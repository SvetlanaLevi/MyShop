USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Order_SelectByCustomerId]    Script Date: 03.05.2020 15:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Order_SelectByCustomerId]
    @CustomerId int
as
begin
	select O.[Id]
	  ,[OrderDate]
      ,[CustomerId]
	  ,R.Name as RepName
	  ,V.Id
	from dbo.[Order] O
	inner join dbo.Representative R on R.Id = O.RepId
	inner join dbo.Valute V on V.Id = O.ValuteId
	where O.CustomerId=@CustomerId
end

--exec [Order_SelectByCustomerId] 1;