USE [ShopDB]
GO
/****** Object:  StoredProcedure [dbo].[CategoryProductCount]    Script Date: 03.05.2020 15:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[CategoryProductCount]
	@count int
AS
BEGIN
	select Category.Name, count(model) as Count from Category 
	inner join SubCategory on Category.Id = SubCategory.CategoryId 
	join Product on Product.SubCategoryId = SubCategory.Id 
	group by Category.Name 
	having count(model) >= @count;
END


