USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Product_SelectById]    Script Date: 03.05.2020 15:46:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Product_SelectById]
@Id int
as
begin
	select 
	[Id],
    [Price],
    [Brand],
    [Model]
	from dbo.[Product] 
	where Id=@Id
end
