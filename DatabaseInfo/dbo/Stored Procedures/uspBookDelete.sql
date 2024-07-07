-- =============================================        
      
-- Description: Deletes an existing book from the Books table
-- EXEC [dbo].[uspBookDelete] @BookID = 1, @UpdatedBy = '153B64E7-06BC-4FDE-8E55-BAA6A4263B57'
-- =============================================    
CREATE PROC [dbo].[uspBookDelete] (
    @BookID INT
   -- @DeletedBy VARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Status BIT = 0;
    DECLARE @Msg NVARCHAR(500);

    BEGIN TRY
        BEGIN
            UPDATE [dbo].[tblBooks]
			SET IsDeleted = 1,
			DeletedBy = 'backend',
			DeletedOn = GetutcDate()
			
            WHERE BookID = @BookID;

            SET @Status = 1;
            SET @Msg = 'Book deleted successfully';
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