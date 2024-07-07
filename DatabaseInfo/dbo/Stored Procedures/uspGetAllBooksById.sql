-- =============================================              
-- Description: Retrieves all books from the Books table
-- EXEC [dbo].[uspGetAllBooks]
-- =============================================    
CREATE PROC [dbo].[uspGetAllBooksById]
@Id int = 1
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Status BIT = 0;
    DECLARE @Msg NVARCHAR(500);

    BEGIN TRY
        BEGIN
            SELECT 
			BookID
			,Title
			,Author
			,Genre
			,PublishedYear
			,Quantity
			FROM [dbo].[tblBooks]
			WHERE BookID = @Id AND IsDeleted = 0

            --SET @Status = 1;
            --SET @Msg = 'Books retrieved successfully';
        END
    END TRY
    BEGIN CATCH
        SET @Msg = ERROR_MESSAGE();

        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@Msg, @ErrorSeverity, @ErrorState);

        SELECT @Status AS [Status], @Msg AS [Message];
    END CATCH

   -- SELECT @Status AS [Status], @Msg AS [Message];
END