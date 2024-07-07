-- =============================================               
-- Description: Inserts a new book into the Books table
-- EXEC [dbo].[uspBookCreate] @Title = 'Sample Title', @Author = 'Sample Author', @Genre = 'Sample Genre', @PublishedYear = 2021, @Quantity = 10, @CreatedBy = '153B64E7-06BC-4FDE-8E55-BAA6A4263B57'
-- =============================================    
CREATE PROC [dbo].[uspBookCreate] (
    @Title NVARCHAR(100),
    @Author NVARCHAR(100),
    @Genre NVARCHAR(50),
    @PublishedYear INT,
    @Quantity INT
   -- @CreatedBy VARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Status BIT = 0;
    DECLARE @Msg NVARCHAR(500);

    BEGIN TRY
        BEGIN
            INSERT INTO [dbo].[tblBooks] (Title, Author, Genre, PublishedYear, Quantity)
            VALUES (@Title, @Author, @Genre, @PublishedYear, @Quantity)

            SET @Status = 1;
            SET @Msg = 'Book created successfully';
        END
    END TRY
    BEGIN CATCH
        SET @Msg = ERROR_MESSAGE();

        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@Msg, @ErrorSeverity, @ErrorState);

        SELECT @Status AS [Status], @Msg AS [Message];
    END CATCH

    SELECT @Status AS [Status], @Msg AS [Message];
END