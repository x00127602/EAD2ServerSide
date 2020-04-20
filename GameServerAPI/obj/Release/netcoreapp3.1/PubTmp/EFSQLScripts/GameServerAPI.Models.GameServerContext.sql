IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200420135700_InitialMigrationScript')
BEGIN
    CREATE TABLE [GameServerItem] (
        [Id] bigint NOT NULL IDENTITY,
        [GameName] nvarchar(max) NULL,
        [Playstation4] nvarchar(max) NULL,
        [XboxOne] nvarchar(max) NULL,
        [Switch] nvarchar(max) NULL,
        [PC] nvarchar(max) NULL,
        [Rating] float NOT NULL,
        CONSTRAINT [PK_GameServerItem] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200420135700_InitialMigrationScript')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200420135700_InitialMigrationScript', N'3.1.3');
END;

GO

