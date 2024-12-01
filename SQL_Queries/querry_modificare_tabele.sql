alter table Traseu drop constraint FK_TipMT_Traseu

if object_id('Tip_Statie', 'U') is not null
begin
	drop table Tip_Statie
end

create table Tip_Statie(
	id_unic int primary key,
	nume varchar(100) not null,
);

if object_id('Statie', 'U') is not null
begin
	drop table Statie
end

-- Create the table
CREATE TABLE Statie (
    id_unic INT PRIMARY KEY, -- Primary Key
    id_traseu INT NOT NULL, -- Foreign Key referencing Traseu(id_unic)
    id_tip_statie int not null,
    ore VARCHAR(255) NOT NULL, -- Arrival times or schedule
    CONSTRAINT FK_Traseu_Statie FOREIGN KEY (id_traseu) REFERENCES Traseu(id_unic), -- Foreign Key Constraint
	constraint FK_Traseu_Tip_Statie foreign key (id_tip_statie) references Tip_Statie(id_unic),
);

ALTER TABLE Traseu
DROP COLUMN nume_statie;

ALTER TABLE Traseu
DROP COLUMN ore;

ALTER TABLE Traseu
DROP COLUMN tip_mt;

ALTER TABLE Traseu
ADD nume NVARCHAR(255);

alter table MT
add numar_mt int not null

--suplimentare
delete from TipMT;
delete from Traseu;
delete from Angajat;
delete from Statie;
---------------------------inserturi tabele------------------------------------

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





-------------------modificare noua cu coord statii-------------------------------------
CREATE TABLE Coordonate_Statie (
    id_unic INT identity(1,1) PRIMARY KEY ,  -- Unique identifier for each record
    id_statie INT,                           -- Foreign key referencing Tip_Statie
    coord_X INT NOT NULL,                    -- X coordinate as an integer
    coord_Y INT NOT NULL,                    -- Y coordinate as an integer
    FOREIGN KEY (id_statie) REFERENCES Tip_Statie(id_unic)  -- Foreign key constraint
);

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








