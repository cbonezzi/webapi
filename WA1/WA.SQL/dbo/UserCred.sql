CREATE TABLE [dbo].[UserCred] (
    [UserId]   UNIQUEIDENTIFIER NOT NULL,
    [Expire] VARCHAR(8)              NOT NULL,
    [Username]   VARCHAR (20)     NOT NULL,
    CONSTRAINT [PK_UserCred] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

