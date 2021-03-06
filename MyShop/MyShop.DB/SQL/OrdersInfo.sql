USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[OrdersInfo]    Script Date: 03.05.2020 15:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[OrdersInfo] 
@startDate date,
@endDate date
AS
BEGIN
	select City.Name as City, Model, Sum([Value]) as [Value], Sum(Price*Value) as Amount from [Order] 
	join Order_Product on OrderId = [Order].Id 
	join Product P on ProductId = P.Id
	join Representative on RepId = Representative.Id
	join City on CityId = City.Id
	where [OrderDate] Between @startDate AND @endDate
	group by City.Name, Model
	order by City.Name;
/*Ты хочешь увидеть информацию о продажах за определённый период времени:
в таком-то городе было куплено столько то единиц такого-то товара за такую-то сумму.*/
END

--exec [dbo].[OrdersInfo] '01.01.2011''01.01.2012'
