DROP TABLE Towns
DROP TABLE Minions
--1
CREATE DATABASE Minions
GO

USE Minions
GO

--2
CREATE TABLE Minions (
	   Id INT NOT NULL,
	   [Name] NVARCHAR(50) NOT NULL,
	   Age INT,
	   CONSTRAINT PK_Minion PRIMARY KEY (Id) 
)
GO

CREATE TABLE Towns (
	   Id INT NOT NULL,
	   [Name] NVARCHAR(50) NOT NULL,
	   CONSTRAINT PK_Towns PRIMARY KEY (Id)
)
GO

--3
ALTER TABLE Minions 
        ADD TownId INT NOT NULL
        CONSTRAINT FK_TownId FOREIGN KEY REFERENCES Towns(Id)

--4
INSERT INTO Towns(Id,Name)
       VALUES(1,'Sofia'),
	         (2,'Plovdiv'),
			 (3,'Varna')

INSERT INTO Minions(Id,Name,Age,TownId)
	   VALUES(1,'Kevin',22,1),
			 (2,'Bob',15,3),
			 (3,'Steward',NULL,2)
GO

--5
TRUNCATE TABLE Minions

--6
DROP TABLE Minions
DROP TABLE Towns

--7
CREATE TABLE People(
	   Id INT PRIMARY KEY IDENTITY NOT NULL,
	   [Name] NVARCHAR(200) NOT NULL,
	   Picture VARBINARY,
	   Height DECIMAL(18,2),
	   Weight DECIMAL(18,2),
	   Gender NVARCHAR(1) NOT NULL,
	   BirthDate DATETIME2 NOT NULL,
	   Biography NVARCHAR(MAX),
       CONSTRAINT CHK_GenderCharacter CHECK(Gender = 'm' OR Gender = 'f'), 
       CONSTRAINT CK_CheckPictureSize CHECK(DATALENGTH(Picture)<2*1048576) 
)

INSERT INTO People (Name,Height,Weight,Gender,BirthDate)
	   VALUES('Name1',23,2,'m','09-02-2004'),
	   	     ('Name2',24,3,'f','10-03-2005'),
	   	     ('Name3',13,7,'f','12-05-2006'),
	   	     ('Name4',4,5,'m','03-04-2006'),
	   	     ('Name5',1,2,'m','01-02-2007')

--8
CREATE TABLE Users (
	   Id BIGINT PRIMARY KEY IDENTITY,
	   UserName VARCHAR(30) NOT NULL,
	   Password VARCHAR(26) NOT NULL,
	   ProfilePicture VARBINARY(MAX),
	   LastLoginTime DATETIME2,
	   IsDeleted NVARCHAR(5) NOT NULL,
       CONSTRAINT uq_UserName UNIQUE(UserName),
       CONSTRAINT CHK_IsDeleted CHECK(IsDeleted='true' OR IsDeleted='false'),
       CONSTRAINT CHK_ProfilePicture CHECK(DATALENGTH(ProfilePicture)<900*1024)
)

INSERT INTO Users(UserName,Password,IsDeleted)
	   VALUES('NamWQ','2323QW','false'),
			 ('NamE','1223323','true'),
			 ('NameE','1223233','false'),
			 ('NameEE','124243','false'),
			 ('NameEEE','1244223','false')


--9
ALTER TABLE Users
 DROP CONSTRAINT PK__Users__3214EC072EFD2989

ALTER TABLE Users
  ADD CONSTRAINT Pk_IdUsers PRIMARY KEY(Id,UserName)

--10
ALTER TABLE Users
  ADD CONSTRAINT CHK_Passwor CHECK (LEN(Password) > 5)

--11
ALTER TABLE Users
  ADD CONSTRAINT DF_LastLogingTime DEFAULT GETDATE()
  FOR LastLoginTime

--12
ALTER TABLE Users
 DROP CONSTRAINT [Pk_IdUsers]

ALTER TABLE Users
  ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
  ADD CONSTRAINT CHK_UserNameLenght CHECK(LEN(UserName)>3)

--13
CREATE DATABASE Movies

CREATE TABLE Directors (
	   Id INT PRIMARY KEY IDENTITY,
	   DirectorName NVARCHAR(70) NOT NULL,
	   Notes NVARCHAR(250)
)

CREATE TABLE Genres (
	   Id INT NOT NULL IDENTITY,
	   GenreName NVARCHAR(30) NOT NULL,
	   Notes NVARCHAR(250),
	   CONSTRAINT PK_Id PRIMARY KEY (Id)
)

CREATE TABLE Categories (
	   Id INT PRIMARY KEY IDENTITY,
	   CategoryName NVARCHAR(50) NOT NULL,
	   Notes NVARCHAR(250)
)

CREATE TABLE Movies (
	   Id INT PRIMARY KEY IDENTITY,
	   Title NVARCHAR(50) NOT NULL,
	   DirectorId INT NOT NULL CONSTRAINT FK_DirectorId_Movies FOREIGN KEY REFERENCES Directors(Id),
	   CopyrightYear NVARCHAR(20) NOT NULL,
	   [Length] NVARCHAR(30) NOT NULL,
	   GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres(Id),
	   CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id), 
	   Rating DECIMAL(2,1) NOT NULL,
	   Notes NVARCHAR(250)
)

INSERT INTO Directors(DirectorName,Notes)
       VALUES('DIRECTOR1',NULL),
       	     ('DIRECTOR2',NULL),
       	     ('DIRECTOR3',NULL),
       	     ('DIRECTOR4',NULL),
       	     ('DIRECTOR5',NULL)

INSERT INTO Genres(GenreName,Notes)
       VALUES('GenreName1',NULL),
       	     ('GenreName2',NULL),
       	     ('GenreName3',NULL),
       	     ('GenreName4',NULL),
       	     ('GenreName5',NULL)

INSERT INTO Categories(CategoryName,Notes)
	   VALUES('CategoryName1',NULL),
	  	     ('CategoryName2',NULL),
	  	     ('CategoryName3',NULL),
	  	     ('CategoryName4',NULL),
	  	     ('CategoryName5',NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
	   VALUES('Titl1',1,'1992','02:31:24',2,1,2.2,'Note'),
			 ('Titl1',1,'1994','01:31:14',2,1,4.2,'Note'),
			 ('Titl1',1,'1992','02:31:14',2,1,2.2,'Note'),
			 ('Titl1',1,'1996','03:21:24',2,1,6.2,'Note'),
			 ('Titl1',1,'1999','01:11:14',2,1,9.2,'Note')

--14
CREATE DATABASE CarRental

CREATE TABLE Categories (
	   Id INT PRIMARY KEY IDENTITY,
	   CategoryName NVARCHAR(50) NOT NULL,
	   DailyRate DECIMAL(8,2) NOT NULL,
	   WeeklyRate DECIMAL(8,2) NOT NULL,
	   MonthlyRate DECIMAL(8,2) NOT NULL,
	   WeekendRate DECIMAL(8,2) NOT NULL,
)

CREATE TABLE Cars (
	   Id INT PRIMARY KEY IDENTITY,
	   PlateNumber NVARCHAR(12) NOT NULL,
	   Manufacturer NVARCHAR(20) NOT NULL,
	   Model NVARCHAR(30) NOT NULL,
	   CarYear INT NOT NULL,
	   CategoryId INT FOREIGN KEY REFERENCES Categories (Id) NOT NULL,
	   Doors INT NOT NULL,
	   Picture VARBINARY,
	   Condition NVARCHAR(30) NOT NULL,
	   Available BIT NOT NULL
)

CREATE TABLE Employees (
	   Id INT PRIMARY KEY IDENTITY,
	   FirstName NVARCHAR(30) NOT NULL,
	   LastName NVARCHAR(30) NOT NULL,
	   Title NVARCHAR(30),
	   Notes NVARCHAR(250)
)

CREATE TABLE Customers (
	   Id INT PRIMARY KEY IDENTITY,
	   DriverLicenseNumber NVARCHAR(50) NOT NULL,
	   FullName NVARCHAR(60) NOT NULL,
	   Address NVARCHAR(50) NOT NULL,
	   City NVARCHAR(30) NOT NULL,
	   ZIPCode NVARCHAR(10),
	   Notes NVARCHAR(250)
)

CREATE TABLE RentalOrders (
	   Id INT PRIMARY KEY IDENTITY,
	   EmployeeId INT FOREIGN KEY REFERENCES Employees (Id) NOT NULL,
	   CustomerId INT FOREIGN KEY REFERENCES Customers (Id),
	   CarId INT FOREIGN KEY REFERENCES Cars (Id),
	   TankLevel INT,
	   KilometrageStart INT NOT NULL,
	   KilometrageEnd INT NOT NULL,
	   TotalKilometrage AS KilometrageEnd - KilometrageStart,
	   StartDate DATE NOT NULL,
	   EndDate DATE NOT NULL,
	   TotalDays AS DATEDIFF(DAY,StartDate,EndDate),
	   RateApplied INT NOT NULL,
	   TaxRate AS RateApplied * 0.2,
	   OrderStatus BIT NOT NULL,
	   Notes NVARCHAR(250)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
       ('Sedans',100,350,1500,130),
       ('hatchback',70,290,1200,100),
       ('Limousine',300,900,3000,350)

INSERT INTO Cars VALUES
       ('PlateNumber1', 'Manufacturer1', 'Model1', 2014, 1, 4, NULL, 'Good', 0),
       ('PlateNumber2', 'Manufacturer2', 'Model2', 2015, 2, 2, NULL, 'Bad', 0),
       ('PlateNumber3', 'Manufacturer3', 'Model3', 2017, 3, 4, NULL, 'Very-Good', 1)

INSERT INTO Employees (FirstName,LastName) VALUES
       ('FName1','LName1'),
       ('FName2','LName2'),
       ('FName3','LName3')

INSERT INTO Customers(DriverLicenseNumber,FullName,Address,City) VALUES
       ('1','Some name 1','Some address 1','City1'),
       ('2','Some name 2','Some address 2','City2'),
       ('3','Some name 3','Some address 3','City3')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, KilometrageStart, KilometrageEnd, 
			StartDate, EndDate, RateApplied, OrderStatus) VALUES
			(1,2,3,10000,10900,'2018-05-12','2018-05-24',250,1),
			(2,3,1,10300,11900,'2018-03-01','2018-05-24',120,0),
			(3,1,2,19000,20900,'2018-01-04','2018-05-24',1500,1)

--15
CREATE DATABASE Hotel

CREATE TABLE Employees (
	   Id INT PRIMARY KEY IDENTITY,
	   FirstName NVARCHAR(30) NOT NULL,
	   LastName NVARCHAR(30) NOT NULL,
	   Title NVARCHAR(40),
	   Notes NVARCHAR(250) 
)

CREATE TABLE Customers (
	   AccountNumber INT PRIMARY KEY IDENTITY,
	   FirstName NVARCHAR(30) NOT NULL,
	   LastName NVARCHAR(30) NOT NULL,
	   PhoneNumber NVARCHAR(20) NOT NULL,
	   EmergencyName NVARCHAR(50),
	   EmergencyNumber NVARCHAR(20),
	   Notes NVARCHAR(250)
)

CREATE TABLE RoomStatus (
	   RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	   Notes NVARCHAR(250)
)

CREATE TABLE RoomTypes (
	   RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	   Notes NVARCHAR(250) 
)

CREATE TABLE BedTypes (
	   BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	   Notes NVARCHAR(250)
)

CREATE TABLE Rooms (
	   RoomNumber INT PRIMARY KEY NOT NULL,
	   RoomType NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES RoomTypes (RoomType),
	   BedType NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES BedTypes (BedType),
	   Rate DECIMAL(6,2) NOT NULL,
       RoomStatus BIT NOT NULL,
	   Notes NVARCHAR(250)
)

CREATE TABLE Payments (
	   Id INT PRIMARY KEY IDENTITY,
	   EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees (Id),
	   PaymentDate DATETIME2 NOT NULL,
	   AccountNumber INT NOT NULL FOREIGN KEY REFERENCES Customers (AccountNumber),
	   FirstDateOccupied DATETIME2 NOT NULL,
	   LastDateOccupied DATETIME2 NOT NULL,
	   TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	   AmountCharged DECIMAL(10,2) NOT NULL,
	   TaxRate DECIMAL(10,2) NOT NULL,
	   TaxAmount AS AmountCharged*TaxRate,
	   PaymentTotal AS AmountCharged + (AmountCharged*TaxRate),
	   Notes NVARCHAR(250)
)

CREATE TABLE Occupancies (
	   Id INT PRIMARY KEY IDENTITY,
	   EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees (Id),
	   DateOccupied DATETIME2 NOT NULL,
	   AccountNumber INT NOT NULL FOREIGN KEY REFERENCES Customers (AccountNumber),
	   RoomNumber INT NOT NULL FOREIGN KEY REFERENCES Rooms (RoomNumber),
	   RateApplied DECIMAL(7, 2) NOT NULL,
	   PhoneCharge DECIMAL(8, 2) NOT NULL,
	   Notes NVARCHAR(250)
)

INSERT INTO Employees(FirstName, LastNAme) VALUES
       ('Galin', 'Zhelev'),
       ('Stoyan', 'Ivanov'),
       ('Petar', 'Ikonomov')

INSERT INTO Customers(FirstName, LastName, PhoneNumber) VALUES
       ('Monio', 'Ushev', '+359888666555'),
       ('Gancho', 'Stoykov', '+359866444222'),
       ('Genadi', 'Dimchov', '+35977555333')

INSERT INTO RoomStatus(RoomStatus) VALUES
       ('occupied'),
       ('non occupied'),
       ('repairs')

INSERT INTO RoomTypes(RoomType) VALUES
       ('single'),
       ('double'),
       ('appartment')

INSERT INTO BedTypes(BedType) VALUES
       ('single'),
       ('double'),
       ('couch')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
       (201, 'single', 'single', 40.0, 1),
       (205, 'double', 'double', 70.0, 0),
       (208, 'appartment', 'double', 110.0, 1)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate) VALUES
	   (1, '2011-11-25', 2, '2017-11-30', '2017-12-04', 250.0, 0.2),
	   (3, '2014-06-03', 3, '2014-06-06', '2014-06-09', 340.0, 0.2),
	   (3, '2016-02-25', 2, '2016-02-27', '2016-03-04', 500.0, 0.2)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) VALUES
	   (2, '2011-02-04', 3, 205, 70.0, 12.54),
	   (2, '2015-04-09', 1, 201, 40.0, 11.22),
	   (3, '2012-06-08', 2, 208, 110.0, 10.05)

--16
CREATE DATABASE SoftUni

CREATE TABLE Towns (
	   Id INT PRIMARY KEY IDENTITY,
	   Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
	   Id INT PRIMARY KEY IDENTITY,
	   AddressText NVARCHAR(50) NOT NULL,
	   TownId INT FOREIGN KEY REFERENCES Towns (Id)
)

CREATE TABLE Departments (
	   Id INT PRIMARY KEY IDENTITY,
	   Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	   Id INT PRIMARY KEY IDENTITY,
	   FirstName NVARCHAR(50) NOT NULL,
	   MiddleName NVARCHAR(50),
	   LastName NVARCHAR(50) NOT NULL,
	   JobTitle NVARCHAR(50) NOT NULL,
	   DepartmentId INT FOREIGN KEY REFERENCES Departments (Id) NOT NULL,
	   HireDate DATE NOT NULL,
	   Salary DECIMAL(12,2) NOT NULL,
	   AddressId INT FOREIGN KEY REFERENCES Addresses (Id)
)

--18
INSERT INTO Towns VALUES 
	   ('Sofia'),
	   ('Plovdiv'),
	   ('Varna'),
	   ('Burgas')

INSERT INTO Departments VALUES
	   ('Engineering'),
	   ('Sales'),
	   ('Marketing'),
	   ('Software Development'),
	   ('Quality Assurance')

INSERT INTO Employees VALUES
       ('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00,NULL),
       ('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00,NULL),
       ('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25,NULL),
       ('Georgi','Teziev','Ivanov','CEO',2,'2007-12-09',3000.00,NULL),
       ('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88,NULL)

--19
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20
SELECT * FROM Towns
ORDER BY Name ASC

  SELECT * 
    FROM Departments
ORDER BY Name ASC

  SELECT * 
    FROM Employees
ORDER BY Salary DESC

--21
  SELECT Name 
    FROM Towns
ORDER BY Name ASC

  SELECT Name 
    FROM Departments
ORDER BY Name ASC

  SELECT FirstName,LastName,JobTitle,Salary 
    FROM Employees
ORDER BY Salary DESC

--22
UPDATE Employees
   SET Salary*=1.1

SELECT Salary 
  FROM Employees

--23
--USE HOTEL 
UPDATE Payments
   SET TaxRate -= TaxRate*0.03

SELECT TaxRate 
  FROM Payments

--24
--USE HOTEL 
TRUNCATE TABLE Occupancies

