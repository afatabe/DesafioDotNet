CREATE OR ALTER PROCEDURE dbo.SP_PRODUCT_POST
    @pName VARCHAR(50),
    @pPrice DECIMAL(18, 2),
    @pBrand VARCHAR(50)
AS
BEGIN
    INSERT INTO dbo.PRODUCT (NAME, PRICE, BRAND) values (@pName, @pPrice, @pBrand)
END
GO