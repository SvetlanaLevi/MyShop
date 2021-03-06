USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Order_Insert]    Script Date: 03.05.2020 15:43:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Order_Insert]
    @RepId int,
	@CustomerId int,
	@ValuteId varchar(10)
as
begin
	insert into dbo.[Order] 
    (RepId,
	OrderDate,
	CustomerId,
	ValuteId)	
	values 
    (@RepId,
    GETDATE(),
	@CustomerId,
	@ValuteId)

	select SCOPE_IDENTITY()
end
