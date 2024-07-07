-- =============================================        
       
-- Description: Updates an existing book in the Books table
-- EXEC [dbo].[uspBookUpdate] @BookID = 1, @Title = 'Updated Title', @Author = 'Updated Author', @Genre = 'Updated Genre', @PublishedYear = 2022, @Quantity = 5, @UpdatedBy = '153B64E7-06BC-4FDE-8E55-BAA6A4263B57'
-- =============================================    
CREATE PROC [dbo].[uspBookUpdate] (
    @BookID INT,
    @Title NVARCHAR(100),
    @Author NVARCHAR(100),
    @Genre NVARCHAR(50),
    @PublishedYear INT,
    @Quantity INT,
    @UpdatedBy VARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Status BIT = 0;
    DECLARE @Msg NVARCHAR(500);

    BEGIN TRY
        BEGIN
            UPDATE [dbo].[tblBooks]
            SET Title = @Title,
                Author = @Author,
                Genre = @Genre,
                PublishedYear = @PublishedYear,
                Quantity = @Quantity,
                UpdatedBy = @UpdatedBy,
                UpdatedOn = GETDATE()
            WHERE BookID = @BookID;

            SET @Status = 1;
            SET @Msg = 'Book updated successfully';
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