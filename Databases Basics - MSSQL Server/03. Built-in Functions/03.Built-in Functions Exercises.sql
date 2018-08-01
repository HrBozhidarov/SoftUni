--USE SoftUni 
--1
SELECT FirstName,LastName 
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

--2
SELECT FirstName,LastName 
  FROM Employees
 WHERE LastName LIKE '%ei%'

--3
SELECT FirstName 
  FROM Employees
 WHERE DepartmentID IN(3,10) AND DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005

--4
SELECT FirstName,LastName 
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

--5
  SELECT Name 
    FROM Towns
   WHERE LEN(Name) IN (5,6)
ORDER BY Name

--6
  SELECT * 
    FROM Towns
   WHERE Name LIKE '[MKBE]%'
ORDER BY Name

--7
  SELECT * 
    FROM Towns
   WHERE Name LIKE '[^RBD]%'
ORDER BY Name
GO

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName FROM Employees
 WHERE DATEPART(YEAR, HireDate) > 2000
GO

--9
SELECT FirstName,LastName 
  FROM Employees
 WHERE LEN(LastName)=5

--USE Geography

--10
  SELECT CountryName,IsoCode 
    FROM Countries
   WHERE CountryName LIKE '%[Aa]%[Aa]%[Aa]%'
ORDER BY IsoCode

--11
   SELECT p.PeakName,r.RiverName, LOWER(p.PeakName+SUBSTRING(r.RiverName,2,LEN(r.RiverName)-1)) 
	      AS Mix FROM Peaks AS p , Rivers AS r
    WHERE LOWER(LEFT(r.RiverName,1))=LOWER(RIGHT(p.PeakName,1))
 ORDER BY Mix

--USE Diablo

--12
  SELECT TOP(50) Name,FORMAT(Start,'yyyy-MM-dd') AS Start 
    FROM Games
   WHERE DATEPART(YEAR,Start) IN (2011,2012)
ORDER BY Start

--13
  SELECT Username,SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)-CHARINDEX('@',Email)) AS [Email Provider] 
    FROM Users
ORDER BY [Email Provider],Username 

--14
  SELECT Username,IpAddress 
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--15
   SELECT Name AS Game, 
	      CASE 
	         WHEN DATEPART(HOUR,Start)>=0 AND DATEPART(HOUR,Start)<12 THEN 'Morning'
		     WHEN DATEPART(HOUR,Start)>=12 AND DATEPART(HOUR,Start)<18 THEN 'Afternoon'
		     WHEN DATEPART(HOUR,Start)>=18 AND DATEPART(HOUR,Start)<24 THEN 'Evening'
		     END AS [Part of the Day],
		  CASE 
	         WHEN Duration<=3 THEN 'Extra Short'
		     WHEN Duration>=4 AND Duration<=6 THEN 'Short'
		     WHEN Duration>=4 THEN 'Long'
		     ELSE 'Extra Long'
		     END AS [Duration]
     FROM Games
 ORDER BY Name,Duration,[Part of the Day]

--USE ORDER DB
--16
SELECT ProductName,OrderDate, 
       DATEADD(DAY,3,OrderDate) AS [Pay Due], 
       DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
  FROM Orders

--17
CREATE TABLE People (
	   Id INT PRIMARY KEY IDENTITY,
	   Name NVARCHAR(50) NOT NULL,
	   Birthdate DATETIME2 NOT NULL
)

INSERT INTO People VALUES
('Victor','2000-12-07 00:00:00.000'),
('Steven','1992-09-10 00:00:00.000'),
('Stephen','1910-09-19 00:00:00.000'),
('Jonh','2010-01-06 00:00:00.000')

SELECT Name,DATEDIFF(YEAR,Birthdate,GETDATE()) AS [Age in Years],
	   DATEDIFF(MONTH,Birthdate,GETDATE()) AS [Age in Mounths],
	   DATEDIFF(DAY,Birthdate,GETDATE()) AS [Age in Days],
	   DATEDIFF(MINUTE,Birthdate,GETDATE()) AS [Age in Minutes]
  FROM People