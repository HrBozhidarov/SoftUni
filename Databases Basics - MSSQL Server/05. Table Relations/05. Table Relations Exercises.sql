-- 1 ONE TO ONE
CREATE TABLE Passports (
	   PassportID INT NOT NULL,
	   PassportNumber NVARCHAR(32) NOT NULL
)

CREATE TABLE Persons (
	   PersonID INT NOT NULL,
	   FirstName NVARCHAR(50) NOT NULL,
	   Salary DECIMAL(15,2) NOT NULL,
	   PassportID INT NOT NULL UNIQUE
)

INSERT INTO Passports VALUES
       (101,'N34FG21B'),
       (102,'K65LO4R7'),
       (103,'ZE657QP2')

INSERT INTO Persons VALUES
       (1,'Roberto',43300.00,102),
       (2,'Tom',56100.00,103),
       (3,'Yana',60200.00,101)

ALTER TABLE Passports
  ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
  ADD CONSTRAINT PK_Person PRIMARY KEY (PersonID);

ALTER TABLE Persons
  ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);

--2 ONE TO MANY
CREATE TABLE Models (
	   ModelID INT IDENTITY(101,1) NOT NULL,
	   [Name] NVARCHAR(50) NOT NULL,
	   ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers (
	   ManufacturerID INT IDENTITY NOT NULL,
	   [Name] NVARCHAR(50) NOT NULL,
	   EstablishedOn DATETIME2 NOT NULL
)

INSERT INTO Models VALUES
       ('X1',1),
       ('i6',1),
       ('Model S',2),
       ('Model X',2),
       ('Model 3',2),
       ('Nova',3)

INSERT INTO Manufacturers VALUES
       ('BMW','07/03/1916'),
       ('Tesla','01/01/2003'),
       ('Lada','01/05/1966')

ALTER TABLE Manufacturers
  ADD PRIMARY KEY (ManufacturerID)

ALTER TABLE Models
  ADD PRIMARY KEY (ModelID);

ALTER TABLE Models
  ADD FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers (ManufacturerID);

--2
CREATE TABLE Manufacturers (
	   ManufacturerID INT PRIMARY KEY IDENTITY,
	   [Name] NVARCHAR(50) NOT NULL,
	   EstablishedOn DATETIME2 NOT NULL
)

CREATE TABLE Models (
	   ModelID INT PRIMARY KEY IDENTITY(101,1),
	   [Name] NVARCHAR(50) NOT NULL,
	   ManufacturerID INT FOREIGN KEY 
	   REFERENCES Manufacturers (ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers VALUES
       ('BMW','07/03/1916'),
       ('Tesla','01/01/2003'),
       ('Lada','01/05/1966')

INSERT INTO Models VALUES
       ('X1',1),
       ('i6',1),
       ('Model S',2),
       ('Model X',2),
       ('Model 3',2),
       ('Nova',3)

--3 MANY TO MANY
CREATE TABLE Students (
	   StudentID INT IDENTITY PRIMARY KEY,
	   [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams (
	   ExamID INT IDENTITY(101,1) PRIMARY KEY,
	   [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (	
	   StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	   ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
       
	   CONSTRAINT CK_StudentsExams PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO Students VALUES
       ('Mila'),
       ('Toni'),
       ('Ron')

INSERT INTO Exams VALUES
       ('SpringMVC'),
       ('Neo4j'),
       ('Oracle 11g')

INSERT INTO StudentsExams VALUES
       (1,101),
       (1,102),
       (2,101),
       (3,103),
       (2,102),
       (2,103)

--4 SELF REFERENCING
CREATE TABLE Teachers (
	   TeacherID INT PRIMARY KEY IDENTITY(101,1),
	   [Name] NVARCHAR(50) NOT NULL,
	   ManagerID INT FOREIGN KEY REFERENCES Teachers (TeacherID)
)

INSERT Teachers VALUES
       ('John',NULL),
       ('Maya',106),
       ('Silvia',106),
       ('Ted',105),
       ('Mark',101),
       ('Greta',101)


--5
CREATE TABLE Cities (
	   CityID INT PRIMARY KEY IDENTITY,
	   [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers (
	   CustomerID INT PRIMARY KEY,
	   [Name] VARCHAR(50) NOT NULL,
	   Birthday DATE NOT NULL,
	   CityID INT FOREIGN KEY REFERENCES Cities (CityID) NOT NULL
)

CREATE TABLE Orders (
	   OrderID INT PRIMARY KEY IDENTITY,
	   CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID) NOT NULL
)

CREATE TABLE ItemTypes (
	   ItemTypeID INT PRIMARY KEY IDENTITY,
	   [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
	   ItemID INT PRIMARY KEY IDENTITY,
	   [Name] VARCHAR(50) NOT NULL,
	   ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes (ItemTypeID)
)

CREATE TABLE OrderItems (
	   OrderID INT FOREIGN KEY REFERENCES Orders (OrderID),
	   ItemID INT FOREIGN KEY REFERENCES Items (ItemID)
       
	   CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID,ItemID)
)

--6
CREATE TABLE Majors (
	   MajorID INT PRIMARY KEY IDENTITY,
	   [Name] NVARCHAR(50) NOT NULL,
)

CREATE TABLE Students (
	   StudentID INT PRIMARY KEY IDENTITY,
	   StudentNumber NVARCHAR(50) NOT NULL,
	   StudentName NVARCHAR(50) NOT NULL,
	   MajorID INT FOREIGN KEY REFERENCES Majors (MajorID)
)

CREATE TABLE Subjects (
	   SubjectID INT PRIMARY KEY IDENTITY,
	   SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Agenda (
	   StudentID INT FOREIGN KEY REFERENCES Students (StudentId),
	   SubjectID INT FOREIGN KEY REFERENCES Subjects (SubjectID),
       
	   CONSTRAINT PK_Agenda PRIMARY KEY (StudentID,SubjectID)
)

CREATE TABLE Payments (
	   PaymentID INT PRIMARY KEY IDENTITY,
	   PaymentDate DATE NOT NULL,
	   PaymentAmount DECIMAL(10,2) NOT NULL,
	   StudentID INT FOREIGN KEY REFERENCES Students (StudentID)
)

--9
    SELECT m.MountainRange, p.PeakName, p.Elevation 
      FROM Mountains AS m
INNER JOIN Peaks p
        ON p.MountainId = m.Id
     WHERE p.MountainId = 17
  ORDER BY p.Elevation DESC