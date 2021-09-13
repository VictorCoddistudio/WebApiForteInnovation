IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Permisos] (
    [Id] int NOT NULL IDENTITY,
    [NombreEmpleado] nvarchar(max) NULL,
    [ApellidosEmpleado] nvarchar(max) NULL,
    [FechaPermiso] datetime2 NOT NULL,
    CONSTRAINT [PK_Permisos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoPermisos] (
    [IdTipoPermiso] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(max) NULL,
    [PermisoMId] int NULL,
    CONSTRAINT [PK_TipoPermisos] PRIMARY KEY ([IdTipoPermiso]),
    CONSTRAINT [FK_TipoPermisos_Permisos_PermisoMId] FOREIGN KEY ([PermisoMId]) REFERENCES [Permisos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_TipoPermisos_PermisoMId] ON [TipoPermisos] ([PermisoMId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210912033654_addPermisosToDatabase', N'5.0.9');
GO

COMMIT;
GO

