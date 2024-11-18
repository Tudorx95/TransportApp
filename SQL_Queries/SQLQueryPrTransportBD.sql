--drop tables if they exist------------------------------------------------------
DROP TABLE IF EXISTS Statie;
DROP TABLE IF EXISTS MT;
DROP TABLE IF EXISTS Traseu;
DROP TABLE IF EXISTS TipMT;
DROP TABLE IF EXISTS Angajat;
DROP TABLE IF EXISTS Tip_Angajat;
DROP TABLE IF EXISTS Bilet;
DROP TABLE IF EXISTS Tip_Bilet;
DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS Persoana;
DROP TABLE IF EXISTS Tip_User;
-- Creare baza de date-----------------------------------------------------------
CREATE DATABASE TransportDB;
GO

USE TransportDB;
GO

-- Creare tabel Tip_User
CREATE TABLE Tip_User (
    id_unic INT PRIMARY KEY,
    nume NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel Persoana
CREATE TABLE Persoana (
    id_unic INT PRIMARY KEY,
    tip_persoana INT NOT NULL,
    nume NVARCHAR(100) NOT NULL,
    prenume NVARCHAR(100) NOT NULL,
    CNP CHAR(13) NOT NULL,
    adresa NVARCHAR(200),
    CONSTRAINT FK_TipUser_Persoana FOREIGN KEY (tip_persoana) REFERENCES Tip_User(id_unic)
);
GO

ALTER TABLE Persoana
ALTER COLUMN CNP CHAR(13) NULL;
GO
ALTER TABLE Persoana
ADD email NVARCHAR(255);
GO


-- Creare tabel User
CREATE TABLE [User] (
    id_unic INT PRIMARY KEY,
    username NVARCHAR(50) NOT NULL,
    [password] NVARCHAR(50) NOT NULL,
    id_persoana INT NOT NULL,
    CONSTRAINT FK_Persoana_User FOREIGN KEY (id_persoana) REFERENCES Persoana(id_unic)
);
GO

-- Creare tabel Tip_Bilet
CREATE TABLE Tip_Bilet (
    id_unic INT PRIMARY KEY,
    nume NVARCHAR(100) NOT NULL
);
GO

if OBJECT_ID('Bilet','U') is not null
 drop table Bilet; 
-- Creare tabel Bilet
CREATE TABLE Bilet (
    id_unic INT IDENTITY(1,1) PRIMARY KEY,
    tip_bilet INT NOT NULL,
    valabilitate DATE NOT NULL,
    id_calator INT NOT NULL,
    CONSTRAINT FK_TipBilet_Bilet FOREIGN KEY (tip_bilet) REFERENCES Tip_Bilet(id_unic),
    CONSTRAINT FK_User_Bilet FOREIGN KEY (id_calator) REFERENCES [User](id_unic),
	-- Add nr_bilete for the Bilet table
	nr_bilete INT NOT NULL DEFAULT 1
);
GO


ALTER TABLE Bilet
ADD nr_bilete INT NOT NULL DEFAULT 1;
go


-- Creare tabel Tip_Angajat
CREATE TABLE Tip_Angajat (
    id_unic INT PRIMARY KEY,
    nume NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel Angajat
CREATE TABLE Angajat (
    id_unic INT PRIMARY KEY,
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
    id_unic INT PRIMARY KEY,
    nume NVARCHAR(100) NOT NULL
);
GO

-- Create the Complaint table
CREATE TABLE Complaint (
    id_unic INT IDENTITY(1,1) PRIMARY KEY,          -- Auto-incrementing primary key
    id_user INT NOT NULL,                            -- Foreign key to User table
    text_plangere VARCHAR(1200),                     -- Complaint text (varchar with 1200 max length)
    id_tip_MTC INT NOT NULL,                         -- Foreign key to TipMT table
    CONSTRAINT FK_User FOREIGN KEY (id_user) REFERENCES [User](id_unic),  -- Foreign key to User table
    CONSTRAINT FK_TipMT FOREIGN KEY (id_tip_MTC) REFERENCES TipMT(id_unic) -- Foreign key to TipMT table
);

GO

-- Creare tabel Traseu
CREATE TABLE Traseu (
    id_unic INT PRIMARY KEY,
    statie_plecare NVARCHAR(100) NOT NULL,
    statie_sosire NVARCHAR(100) NOT NULL
);
GO

-- Creare tabel MT
CREATE TABLE MT (
    id_unic INT PRIMARY KEY,
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
    id_unic INT PRIMARY KEY,
    id_traseu INT NOT NULL,
    denumire NVARCHAR(100) NOT NULL,
    timp_S_D TIME NOT NULL,
    timp_D_S TIME NOT NULL,
    CONSTRAINT FK_Traseu_Statie FOREIGN KEY (id_traseu) REFERENCES Traseu(id_unic)
);
GO
--pupulari tabele---------------------------------------------------------------------
USE TransportDB;
GO

-- Populate Tip_User table with specified primary keys
INSERT INTO Tip_User (id_unic, nume) VALUES 
(1, 'Calator'), 
(2, 'Angajat');
GO

-- Populate Persoana table with specified primary keys
INSERT INTO Persoana (id_unic, tip_persoana, nume, prenume, CNP, adresa) VALUES 
(1, 1, 'Popescu', 'Ion', '1234567890123', 'Str. Libertatii, Nr. 12'),
(2, 2, 'Ionescu', 'Maria', '2345678901234', 'Str. Independentei, Nr. 8');
GO

-- Populate Tip_Bilet table with specified primary keys
INSERT INTO Tip_Bilet (id_unic, nume) VALUES 
(1, 'Abonament lunar'), 
(2, 'Bilet o calatorie'),
(3, 'Bilet dus-intors'),
(4, 'Abonament 6 luni'),
(5, 'Abonament 1 an');
GO

-- Populate Tip_Angajat table with specified primary keys
INSERT INTO Tip_Angajat (id_unic, nume) VALUES 
(1, 'Sofer'), 
(2, 'Controlor');
GO

-- Populate Angajat table with specified primary keys
INSERT INTO Angajat (id_unic, salariu, id_persoana, tip_angajat, data_angajarii) VALUES 
(1, 3500.00, 2, 1, '2023-01-01'),
(2, 2800.00, 2, 2, '2023-05-10');
GO

-- Populate TipMT table with specified primary keys
INSERT INTO TipMT (id_unic, nume) VALUES 
(1, 'Autobuz'), 
(2, 'Tramvai'), 
(3, 'Troleibuz'),
(4, 'Metrou');
GO

-- Populate Traseu table with specified primary keys
INSERT INTO Traseu (id_unic, statie_plecare, statie_sosire) VALUES 
(1, 'Gara', 'Centru'), 
(2, 'Centru', 'Aeroport'), 
(3, 'Gara', 'Universitate');
GO

-- Populate MT table with specified primary keys
INSERT INTO MT (id_unic, id_tip, nr_traseu, nr_inmatriculare, id_sofer) VALUES 
(1, 1, 1, 'B123ABC', 1), 
(2, 2, 2, 'B456DEF', 1);
GO

-- Populate Statie table with specified primary keys
INSERT INTO Statie (id_unic, id_traseu, denumire, timp_S_D, timp_D_S) VALUES 
(1, 1, 'Gara', '08:00', '18:00'),
(2, 1, 'Centru', '08:30', '18:30'),
(3, 2, 'Centru', '09:00', '19:00'),
(4, 2, 'Aeroport', '09:45', '19:45');
GO
