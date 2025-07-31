CREATE TABLE [Items] (
    [Id] int NOT NULL IDENTITY,
    [DomainId] uniqueidentifier NOT NULL,
    [OrderId] int NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [DateCreated] datetimeoffset NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Items_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Items_DomainId] ON [Items] ([DomainId]);
GO

CREATE INDEX [IX_Items_OrderId] ON [Items] ([OrderId]);
GO
