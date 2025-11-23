-- Cria o banco e as tabelas conforme o esquema do enunciado.
IF DB_ID(N'aulajava') IS NOT NULL
    DROP DATABASE aulajava;
GO

CREATE DATABASE aulajava;
GO

USE aulajava;
GO

IF OBJECT_ID(N'dbo.tbfuncs', N'U') IS NOT NULL DROP TABLE dbo.tbfuncs;
IF OBJECT_ID(N'dbo.tbcargos', N'U') IS NOT NULL DROP TABLE dbo.tbcargos;
GO

CREATE TABLE dbo.tbcargos (
    cod_cargo SMALLINT NOT NULL PRIMARY KEY,
    ds_cargo  CHAR(20) NOT NULL UNIQUE
);
GO

CREATE TABLE dbo.tbfuncs (
    cod_func  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nome_func CHAR(25) NOT NULL,
    sal_func  DECIMAL(10,2) NOT NULL,
    cod_cargo SMALLINT NOT NULL,
    CONSTRAINT FK_tbfuncs_tbcargos FOREIGN KEY (cod_cargo) REFERENCES dbo.tbcargos(cod_cargo)
);
GO

INSERT INTO dbo.tbcargos (cod_cargo, ds_cargo) VALUES
    (1, 'Administrativo'),
    (2, 'Financeiro'),
    (3, 'TI');
GO

INSERT INTO dbo.tbfuncs (nome_func, sal_func, cod_cargo) VALUES
    ('Marcelo', 2000.00, 1),
    ('Marcia',  3200.50, 2),
    ('Marcos',  4100.00, 3),
    ('Ana',     2500.00, 1),
    ('Bruna',   2800.00, 2);
GO
