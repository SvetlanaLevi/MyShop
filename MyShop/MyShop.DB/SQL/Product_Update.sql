USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[Product_Update]    Script Date: 03.05.2020 15:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Product_Update]
	@Id int,
    @Price money,
    @Brand varchar(50),
    @Model varchar(100),
    @SubCategoryId int
as
begin
	update dbo.[Product] 
	set 
    [Price]=@Price,
    [Brand]=@Brand,
    [Model]=@Model,
    [SubCategoryId]=@SubCategoryId
	where Id = @Id
end
