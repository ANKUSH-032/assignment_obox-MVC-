CREATE TABLE [dbo].[tblUsers] (
    [UserID]    INT            IDENTITY (1, 1) NOT NULL,
    [Username]  NVARCHAR (50)  NOT NULL,
    [Password]  NVARCHAR (50)  NOT NULL,
    [Role]      NVARCHAR (50)  NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (50)  NOT NULL,
    [Gender]    NVARCHAR (10)  NOT NULL,
    [Email]     NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

