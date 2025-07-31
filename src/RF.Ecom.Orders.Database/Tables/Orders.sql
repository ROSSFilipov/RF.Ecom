CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [DomainId] uniqueidentifier NOT NULL,
    [Reference] nvarchar(50) NOT NULL,
    [Status] int NOT NULL,
    [DateCreated] datetimeoffset NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Orders_DomainId] ON [Orders] ([DomainId]);
GO

CREATE INDEX [IX_Orders_Status] ON [Orders] ([Status]);
GO