CREATE TABLE [CRMLite].[Leads] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Lastname]      NVARCHAR (255)   NOT NULL,
    [Firstname]     NVARCHAR (255)   NOT NULL,
    [PasportNumber] NVARCHAR (8)     NOT NULL,
    [TIN]           NVARCHAR (12)    NOT NULL,
    [Email]         NVARCHAR (255)   NOT NULL,
    [Password]      NVARCHAR (255)   NOT NULL,
    [Role]          NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_LEADS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

