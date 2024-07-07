CREATE TABLE [dbo].[tblBooks] (
    [BookID]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]         NVARCHAR (100) NULL,
    [Author]        NVARCHAR (100) NULL,
    [Genre]         NVARCHAR (50)  NULL,
    [PublishedYear] INT            NULL,
    [Quantity]      INT            NULL,
    [IsDeleted]     BIT            NULL,
    [CreatedBy]     VARCHAR (50)   NULL,
    [CreatedOn]     DATETIME       NULL,
    [UpdatedBy]     VARCHAR (50)   NULL,
    [UpdatedOn]     DATETIME       NULL,
    [DeletedBy]     VARCHAR (50)   NULL,
    [DeletedOn]     DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([BookID] ASC)
);

