-- DROP DATABASE IF EXISTS
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'TransportDB')
BEGIN
    ALTER DATABASE TransportDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE TransportDB;
END
GO

-- Creare baza de date-----------------------------------------------------------
CREATE DATABASE TransportDB;
GO
USE TransportDB;
GO

--drop tables if they exist------------------------------------------------------
DROP TABLE IF EXISTS Coordonate_Statie;
DROP TABLE IF EXISTS Statie;
DROP TABLE IF EXISTS Tip_Statie;
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
DROP TABLE IF EXISTS Complaint;


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
    CNP CHAR(13) NULL,
    adresa NVARCHAR(200),
	email NVARCHAR(255),
    CONSTRAINT FK_TipUser_Persoana FOREIGN KEY (tip_persoana) REFERENCES Tip_User(id_unic)
);
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

-- Creare tabel Bilet
CREATE TABLE Bilet (
    id_unic INT IDENTITY(1,1) PRIMARY KEY,
    tip_bilet INT NOT NULL,
    valabilitate DATE NOT NULL,
    id_calator INT NOT NULL,
    CONSTRAINT FK_TipBilet_Bilet FOREIGN KEY (tip_bilet) REFERENCES Tip_Bilet(id_unic),
    CONSTRAINT FK_User_Bilet FOREIGN KEY (id_calator) REFERENCES [User](id_unic),
);
GO

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
    nume NVARCHAR(255) NOT NULL
);
GO

-- Creare tabel MT
CREATE TABLE MT (
    id_unic INT PRIMARY KEY,
    id_tip INT NOT NULL,
    nr_traseu INT NOT NULL,
    nr_inmatriculare NVARCHAR(20) NOT NULL,
    id_sofer INT NOT NULL,
	numar_mt INT NOT NULL,
    CONSTRAINT FK_TipMT_MT FOREIGN KEY (id_tip) REFERENCES TipMT(id_unic),
    CONSTRAINT FK_Traseu_MT FOREIGN KEY (nr_traseu) REFERENCES Traseu(id_unic),
    CONSTRAINT FK_Sofer_MT FOREIGN KEY (id_sofer) REFERENCES Angajat(id_unic)
);
GO


-- Creare Tip_Statie
create table Tip_Statie(
	id_unic int primary key,
	nume varchar(100) not null,
);


-- Creare Statie
CREATE TABLE Statie (
    id_unic INT PRIMARY KEY, -- Primary Key
    id_traseu INT NOT NULL, -- Foreign Key referencing Traseu(id_unic)
    id_tip_statie int not null,
    ore VARCHAR(255) NOT NULL, -- Arrival times or schedule
    CONSTRAINT FK_Traseu_Statie FOREIGN KEY (id_traseu) REFERENCES Traseu(id_unic), -- Foreign Key Constraint
	constraint FK_Traseu_Tip_Statie foreign key (id_tip_statie) references Tip_Statie(id_unic),
);

-------------------modificare noua cu coord statii-------------------------------------
CREATE TABLE Coordonate_Statie (
    id_unic INT identity(1,1) PRIMARY KEY ,  -- Unique identifier for each record
    id_statie INT,                           -- Foreign key referencing Tip_Statie
    coord_X INT NOT NULL,                    -- X coordinate as an integer
    coord_Y INT NOT NULL,                    -- Y coordinate as an integer
    FOREIGN KEY (id_statie) REFERENCES Tip_Statie(id_unic)  -- Foreign key constraint
);

--suplimentare
delete from TipMT;
delete from Traseu;
delete from Angajat;
delete from Statie;


---------------------------inserturi tabele------------------------------------
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

-- Populate MT table with specified primary keys
INSERT INTO MT (id_unic, id_tip, nr_traseu, nr_inmatriculare, id_sofer) VALUES 
(1, 1, 1, 'B123ABC', 1), 
(2, 2, 2, 'B456DEF', 1);
GO



insert into TipMT(id_unic, nume)
values
	(1, 'Autobuz'),
	(2, 'Tramvai'),
	(3, 'Metro');

INSERT INTO Angajat (id_unic, salariu, id_persoana, tip_angajat, data_angajarii)
VALUES 
    (1, 3500.50, 1, 2, '2022-01-15'),
    (2, 4200.75, 2, 1, '2021-03-10'),
    (3, 3000.00, 3, 2, '2023-07-01'),
    (4, 5000.00, 4, 1, '2020-09-05');


insert into MT(id_unic, id_tip, nr_traseu, nr_inmatriculare, id_sofer, numar_mt)
values
	(1, 1, 1, 'AAX345', 1, 101),
	(2, 1, 2, 'ABX345', 2, 102),
	(3, 1, 3, 'ACX345', 3, 103),
	(4, 2, 4, 'ADX345', 1, 10),
	(5, 2, 5, 'AEX345', 2, 11),
	(6, 2, 6, 'AFX345', 3, 12),
	(7, 3, 7, 'AGX345', 4, 1);

insert into Traseu(id_unic, nume)
values
	(1, 'Autobuz nr. 101'),
	(2, 'Autobuz nr. 102'),
	(3, 'Autobuz nr. 103'),
	(4, 'Tramvai nr. 10'),
	(5, 'Tramvai nr. 11'),
	(6, 'Tramvai nr. 12'),
	(7, 'Metrou');
	

insert into Tip_Statie(id_unic, nume)
values
	(1, 'Biblioteca Publica'),
	(2, 'Cartierul Tineretului'),
	(3, 'Universitatea'),
	(4, 'Statia Centrala'),
	(5, 'Statia Centrala 2'),
	(6, 'Shopping Mall'),
	(7, 'Parcul Verde'),
	(8, 'Gara Mare'),
	(9, 'Piata Mica'),
	(10, 'Speranta'),
	(11, 'Giurgiului'),
	(12, 'Piata Unirii'),
	(13, 'Spitalul Municipal');

insert into Statie(id_unic, id_traseu, id_tip_statie, ore)
values
	(1, 1, 1, '08:15 10:45 12:50 17:25 22:00'),
	(2, 1, 2, '08:20 10:30 12:30 17:05 22:30'),
	(3, 1, 3, '08:45 10:30 12:30 17:10 22:30'),
	(4, 1, 4, '08:20 10:45 12:30 17:15 22:05'),
	(5, 1, 5, '08:20 10:30 12:30 17:05 22:30'),
	(6, 2, 7, '07:10 11:45 14:30 19:05'),
	(7, 2, 5, '07:15 11:50 14:45 19:55'),
	(8, 2, 4, '07:00 11:30 14:35 19:10'),
	(9, 2, 6, '07:15 11:30 14:25 19:00'),
	(10, 3, 7, '06:10 11:45 23:30'),
	(11, 3, 1, '06:00 12:45 00:05'),
	(12, 3, 5, '06:20 11:55 00:30'),
	(13, 4, 3, '06:30 11:50 16:30 22:30'),
	(14, 4, 8, '06:45 11:55 16:35 22:35'),
	(15, 4, 5, '06:55 11:55 16:35 22:40'),
	(16, 4, 9, '06:55 11:55 16:45 22:50'),
	(17, 5, 6, '05:30 11:50 22:30'),
	(18, 5, 8, '05:55 11:55 22:45'),
	(19, 5, 5, '05:55 11:50 22:50'),
	(20, 6, 3, '05:30 11:50 22:30'),
	(22, 6, 6, '05:35 11:55 22:35'),
	(23, 6, 8, '05:40 11:55 22:45'),
	(24, 7, 10, '05:35 11:55 16:00 22:35'),
	(25, 7, 11, '05:40 11:55 16:05 22:40'),
	(26, 7, 13, '05:45 11:55 16:10 22:40'),
	(27, 7, 12, '05:40 11:55 16:05 22:40');


insert into Coordonate_Statie(id_statie, coord_X, coord_Y)
values
	(1, 516, 683),
	(2, 237, 708),
	(3, 47, 536),
	(4, 78, 311),
	(5, 408, 301),
	(6, 147, 199),
	(7, 658, 230),
	(8, 228, 404),
	(9, 707, 527),
	(10, 438, 741),
	(11, 370, 498),
	(12, 729, 363),
	(13, 322, 160);
