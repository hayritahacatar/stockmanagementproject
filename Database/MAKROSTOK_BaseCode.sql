USE master
GO

CREATE DATABASE MAKROSTOK
GO

USE MAKROSTOK
GO

CREATE SCHEMA STOK
GO

CREATE TABLE STOK.URUNSTOK
(
	UrunID INT IDENTITY(1,1) NOT NULL UNIQUE,
	UrunKodu NVARCHAR(10),
	UrunAdı NVARCHAR(50) NOT NULL,
	UrunBoyutu NVARCHAR(5) NOT NULL,
	CONSTRAINT PK_US PRIMARY KEY (UrunID)
)
GO

CREATE TABLE STOK.URETIM
(
	UretimID INT IDENTITY(1,1) NOT NULL UNIQUE,
	UretimAdı NVARCHAR(50) NOT NULL,
	UretimBoyutu NVARCHAR(5) NOT NULL,
	CONSTRAINT PK_UR PRIMARY KEY (UretimID)
)
GO

CREATE TABLE STOK.URETIMSTOK
(
	UretStokID INT IDENTITY(1,1) NOT NULL UNIQUE,
	UretStokAdı NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_URS PRIMARY KEY (UretStokID)
)
GO

CREATE TABLE STOK.KUTULAMA
(
	UrunnID INT NOT NULL,
	UretimmID INT NOT NULL,
	UrunKutulandı BIT NOT NULL,
	CONSTRAINT PK_KUT PRIMARY KEY (UrunnID, UretimmID),
	CONSTRAINT FK_KUT_US FOREIGN KEY (UrunnID) REFERENCES STOK.URUNSTOK(UrunID) ON DELETE CASCADE,
	CONSTRAINT FK_KUT_UR FOREIGN KEY (UretimmID) REFERENCES STOK.URETIM(UretimID) ON DELETE CASCADE
)
GO

CREATE TABLE STOK.ISLEM
(
	UretimStokkID INT NOT NULL,
	UrettimID INT NOT NULL,
	MalPuntolandı BIT NOT NULL,
	MalKaplandı BIT NOT NULL,
	MalLastiklendi BIT NOT NULL,
	CONSTRAINT PK_IS PRIMARY KEY (UretimStokkID, UrettimID),
	CONSTRAINT FK_IS_URS FOREIGN KEY (UretimStokkID) REFERENCES STOK.URETIMSTOK(UretStokID) ON DELETE CASCADE,
	CONSTRAINT FK_IS_UR FOREIGN KEY (UrettimID) REFERENCES STOK.URETIM(UretimID) ON DELETE CASCADE
)
GO

CREATE TABLE STOK.USERLIST
(
	CompanyID INT NOT NULL UNIQUE,
	Name NVARCHAR(255) NOT NULL,
	Passwordd NVARCHAR(16) NOT NULL,
	UserType NVARCHAR(50) NOT NULL
	CONSTRAINT PK_UL PRIMARY KEY (CompanyID)
)
GO