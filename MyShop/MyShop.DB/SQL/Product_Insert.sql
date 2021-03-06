USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Product_Insert]    Script Date: 03.05.2020 15:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Product_Insert]
    @Price money,
    @Brand varchar(50),
    @Model varchar(100),
    @SubCategoryId int
as
begin
	insert into dbo.[Product] 
    ([Price],
    [Brand],
    [Model],
    [SubCategoryId])
	
	values 
    (@Price,
    @Brand,
    @Model,
    @SubCategoryId)

	select SCOPE_IDENTITY()
end
