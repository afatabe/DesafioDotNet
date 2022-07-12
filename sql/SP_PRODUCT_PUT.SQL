CREATE OR ALTER PROCEDURE dbo.SP_PRODUCT_PUT
    @pName VARCHAR(50),
    @pPrice DECIMAL(18, 2),
    @pBrand VARCHAR(50),
    @pId INT 
AS
BEGIN
    UPDATE PRODUCT SET NAME = @pName, PRICE = @pPrice, BRAND = @pBrand, updatedAt = GETDATE() WHERE ID = @pId
END
GO

