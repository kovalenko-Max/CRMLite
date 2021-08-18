CREATE TABLE [CRMLite].[Leads] (
    [ID]            UNIQUEIDENTIFIER NOT NULL,
    [LastName]      NVARCHAR (255)   NOT NULL,
    [FirstName]     NVARCHAR (255)   NOT NULL,
    [PassportNumber] NVARCHAR (8)     NOT NULL,
    [TIN]           NVARCHAR (12)    NOT NULL,
    [Email]         NVARCHAR (255)   NOT NULL UNIQUE,
    [Password]      NVARCHAR (255)   NOT NULL,
    [Status]          NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_LEADS] PRIMARY KEY CLUSTERED ([ID] ASC)
);