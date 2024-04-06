CREATE DATABASE historyDB;
GO

USE historyDB;
GO

CREATE TABLE history (
    id INT IDENTITY(1,1) PRIMARY KEY,
    operation NVARCHAR(MAX),
    result NVARCHAR(MAX)
);
GO