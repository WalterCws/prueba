IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AEROLINEAS] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AEROLINEAS] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DEPARTAMENTOS] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DEPARTAMENTOS] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ESTADOSVUELO] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ESTADOSVUELO] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [CIUDADES] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [DepartamentoId] int NOT NULL,
    CONSTRAINT [PK_CIUDADES] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CIUDADES_DEPARTAMENTOS_DepartamentoId] FOREIGN KEY ([DepartamentoId]) REFERENCES [DEPARTAMENTOS] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [VUELOS] (
    [Id] int NOT NULL IDENTITY,
    [FechaSalida] datetime2 NOT NULL,
    [FechaLlegada] datetime2 NOT NULL,
    [CiudadDestinoId] int NOT NULL,
    [CiudadOrigenId] int NOT NULL,
    [NumeroVuelo] int NOT NULL,
    [NuevoVueloId] int NULL,
    CONSTRAINT [PK_VUELOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_VUELOS_CIUDADES_CiudadDestinoId] FOREIGN KEY ([CiudadDestinoId]) REFERENCES [CIUDADES] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_VUELOS_CIUDADES_CiudadOrigenId] FOREIGN KEY ([CiudadOrigenId]) REFERENCES [CIUDADES] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_VUELOS_VUELOS_NuevoVueloId] FOREIGN KEY ([NuevoVueloId]) REFERENCES [VUELOS] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_CIUDADES_DepartamentoId] ON [CIUDADES] ([DepartamentoId]);

GO

CREATE INDEX [IX_VUELOS_CiudadDestinoId] ON [VUELOS] ([CiudadDestinoId]);

GO

CREATE INDEX [IX_VUELOS_CiudadOrigenId] ON [VUELOS] ([CiudadOrigenId]);

GO

CREATE INDEX [IX_VUELOS_NuevoVueloId] ON [VUELOS] ([NuevoVueloId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210422041803_MigracionInicial', N'3.1.14');

GO

