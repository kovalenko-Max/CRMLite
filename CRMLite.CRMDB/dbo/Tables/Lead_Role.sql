CREATE TABLE [CRMLite].[Lead_Role]
(
    [LeadID] UNIQUEIDENTIFIER NOT NULL,
    [RoleID] INT NOT NULL,
    PRIMARY KEY([LeadID], [RoleID]),
    CONSTRAINT [Lead_Role_fk0] FOREIGN KEY ([LeadID]) REFERENCES [CRMLite].[Leads] ([ID]),
    CONSTRAINT [Lead_Role_fk1] FOREIGN KEY ([RoleID]) REFERENCES [CRMLite].[Roles] ([ID])
)
