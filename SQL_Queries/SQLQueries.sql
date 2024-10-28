-- Creare baza de date
CREATE DATABASE TransportDB;
GO

USE TransportDB;
GO

-- Creare tabel Tip_User
CREATE TABLE Tip_User (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    nume NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel Persoana
CREATE TABLE Persoana (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    tip_persoana INT NOT NULL,
    nume NVARCHAR(100) NOT NULL,
    prenume NVARCHAR(100) NOT NULL,
    CNP CHAR(13) NOT NULL,
    adresa NVARCHAR(200),
    CONSTRAINT FK_TipUser_Persoana FOREIGN KEY (tip_persoana) REFERENCES Tip_User(id_unic)
);
GO

-- Creare tabel User
CREATE TABLE [User] (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL,
    [password] NVARCHAR(50) NOT NULL,
    id_persoana INT NOT NULL,
    CONSTRAINT FK_Persoana_User FOREIGN KEY (id_persoana) REFERENCES Persoana(id_unic)
);
GO

-- Creare tabel Tip_Bilet
CREATE TABLE Tip_Bilet (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    nume NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel Bilet
CREATE TABLE Bilet (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    tip_bilet INT NOT NULL,
    valabilitate DATE NOT NULL,
    id_calator INT NOT NULL,
    CONSTRAINT FK_TipBilet_Bilet FOREIGN KEY (tip_bilet) REFERENCES Tip_Bilet(id_unic),
    CONSTRAINT FK_User_Bilet FOREIGN KEY (id_calator) REFERENCES [User](id_unic)
);
GO

-- Creare tabel Tip_Angajat
CREATE TABLE Tip_Angajat (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    nume NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel Angajat
CREATE TABLE Angajat (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    salariu DECIMAL(10,2) NOT NULL,
    id_persoana INT NOT NULL,
    tip_angajat INT NOT NULL,
    data_angajarii DATE NOT NULL,
    CONSTRAINT FK_Persoana_Angajat FOREIGN KEY (id_persoana) REFERENCES Persoana(id_unic),
    CONSTRAINT FK_TipAngajat_Angajat FOREIGN KEY (tip_angajat) REFERENCES Tip_Angajat(id_unic)
);
GO

-- Creare tabel TipMT
CREATE TABLE TipMT (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    nume NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel Traseu
CREATE TABLE Traseu (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    statie_plecare NVARCHAR(100) NOT NULL,
    statie_sosire NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel MT
CREATE TABLE MT (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    id_tip INT NOT NULL,
    nr_traseu INT NOT NULL,
    nr_inmatriculare NVARCHAR(20) NOT NULL,
    id_sofer INT NOT NULL,
    CONSTRAINT FK_TipMT_MT FOREIGN KEY (id_tip) REFERENCES TipMT(id_unic),
    CONSTRAINT FK_Traseu_MT FOREIGN KEY (nr_traseu) REFERENCES Traseu(id_unic),
    CONSTRAINT FK_Sofer_MT FOREIGN KEY (id_sofer) REFERENCES Angajat(id_unic)
);
GO

-- Creare tabel Statie
CREATE TABLE Statie (
    id_unic INT PRIMARY KEY IDENTITY(1,1),
    id_traseu INT NOT NULL,
    denumire NVARCHAR(100) NOT NULL,
    timp_S_D TIME NOT NULL,
    timp_D_S TIME NOT NULL,
    CONSTRAINT FK_Traseu_Statie FOREIGN KEY (id_traseu) REFERENCES Traseu(id_unic)
);
GO
