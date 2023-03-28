CREATE DATABASE nauciProgramiranje;

USE nauciProgramiranje;

CREATE TABLE Lekcija(
    Lekcija_ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    VideoURL NVARCHAR(255) NOT NULL,
    Naslov NVARCHAR(255) NOT NULL,
)