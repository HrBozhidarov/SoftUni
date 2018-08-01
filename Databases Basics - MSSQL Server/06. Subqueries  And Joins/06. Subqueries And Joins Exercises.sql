--1
    SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID,a.AddressText 
      FROM Employees AS e
INNER JOIN Addresses AS a
        ON a.AddressID=e.AddressID
  ORDER BY a.AddressID

--2
    SELECT TOP(50) e.FirstName,e.LastName,t.Name AS Town,a.AddressText 
      FROM Employees AS e
INNER JOIN Addresses AS a
        ON a.AddressID=e.AddressID
INNER JOIN Towns AS t
		ON t.TownID=a.TownID
  ORDER BY e.FirstName,e.LastName

--3
	SELECT e.EmployeeID,e.FirstName,e.LastName,d.Name AS DepartmentName 
	  FROM Employees AS e
INNER JOIN Departments AS d
		ON d.DepartmentID=e.DepartmentID
	 WHERE d.Name='Sales'
  ORDER BY e.EmployeeID

--4
	SELECT TOP(5)  e.EmployeeID,e.FirstName,e.Salary,d.Name AS DepartmentName 
	  FROM Employees AS e
INNER JOIN Departments AS d
		ON d.DepartmentID=e.DepartmentID
	 WHERE e.Salary>15000
  ORDER BY e.DepartmentID

--5
		 SELECT TOP(3) e.EmployeeID,e.FirstName 
		   FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep
			 ON ep.EmployeeID=e.EmployeeID
		  WHERE ep.ProjectID IS NULL
	   ORDER BY e.EmployeeID

--6
	SELECT e.FirstName,e.LastName,e.HireDate,d.Name AS DeptName 
	  FROM Employees AS e
INNER JOIN Departments d
		ON d.DepartmentID=e.DepartmentID
	 WHERE e.HireDate>'1.1.1999' AND d.Name IN ((SELECT Name FROM Departments WHERE Name='Finance' OR Name='Sales'))
  ORDER BY e.HireDate

--7
	SELECT TOP(5) e.EmployeeID,e.FirstName,p.Name AS ProjectName 
	  FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
		ON ep.EmployeeID=e.EmployeeID
INNER JOIN Projects p
		ON p.ProjectID=ep.ProjectID
	 WHERE p.StartDate > CONVERT(smalldatetime ,'13.08.2002',103) AND p.EndDate IS NULL
  ORDER BY e.EmployeeID

--8
	 SELECT e.EmployeeID,e.FirstName,
       CASE    
            WHEN p.StartDate >= CONVERT(smalldatetime ,'13.08.2002',103) THEN NULL  
            ELSE p.Name
       END AS ProjectName 
      FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
		ON ep.EmployeeID=e.EmployeeID
INNER JOIN Projects p
		ON p.ProjectID=ep.ProjectID
	 WHERE ep.EmployeeID=24

--9
	SELECT e1.EmployeeID,e1.FirstName,e2.EmployeeID, e2.FirstName AS ManagerName 
	  FROM Employees e1
INNER JOIN Employees e2
		ON e2.EmployeeID = e1.ManagerID
	 WHERE e1.ManagerID IN (3,7)
  ORDER BY e1.EmployeeID

--10
	SELECT TOP(50) e1.EmployeeID,e1.FirstName + ' ' + e1.LastName AS EmployeeName,
			   e2.FirstName + ' ' + e2.LastName AS ManagerName, d.Name AS DeparmentName
      FROM Employees AS e1
INNER JOIN  Employees AS e2
		ON e2.EmployeeID=e1.ManagerID
INNER JOIN Departments d
		ON d.DepartmentID=e1.DepartmentID
  ORDER BY e1.EmployeeID

--11
SELECT MIN(avgSalary.Salary) AS MinAverageSalary 
  FROM (
		   SELECT AVG(e.Salary) AS Salary 
		     FROM Employees e
		 GROUP BY e.DepartmentID
	   ) AS avgSalary


--USE Geography db
--12
	SELECT C.CountryCode,m.MountainRange,p.PeakName,p.Elevation 
	  FROM Countries AS c
INNER JOIN MountainsCountries AS mc
		ON mc.CountryCode=c.CountryCode
INNER JOIN Mountains AS m
		ON m.Id=mc.MountainId 
INNER JOIN Peaks AS p
		ON p.MountainId=m.Id
	 WHERE c.CountryCode='BG' AND p.Elevation>2835
  ORDER BY p.Elevation DESC

--13
	SELECT mc.CountryCode, COUNT(mc.CountryCode) AS MountainRanges 
	  FROM Countries AS c
INNER JOIN MountainsCountries AS mc
		ON mc.CountryCode=c.CountryCode
	 WHERE mc.CountryCode IN('BG','US','RU')
  GROUP BY mc.CountryCode

--14
		 SELECT TOP(5) c.CountryName, r.RiverName 
		   FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr
			 ON cr.CountryCode=c.CountryCode
LEFT OUTER JOIN Rivers r
			 ON r.Id=cr.RiverId
		  WHERE c.ContinentCode='AF'
	   ORDER BY c.CountryName

--15
WITH CTE_CountiesInfo(ContinentCode,CurrencyCode,MaxCurrencyCode) AS 
(
	  SELECT ContinentCode,CurrencyCode,COUNT(CurrencyCode) AS MaxCurrencyCode 
	    FROM Countries
	GROUP BY ContinentCode,CurrencyCode
	  HAVING COUNT(CurrencyCode) > 1
)

	SELECT cce.ContinentCode,cce.CurrencyCode,cce.MaxCurrencyCode 
	  FROM (
			  SELECT ContinentCode, MAX(MaxCurrencyCode) AS CurrentMaxCurrencyCode 
			    FROM CTE_CountiesInfo
			GROUP BY ContinentCode ) AS E
INNER JOIN CTE_CountiesInfo AS cce
		ON cce.ContinentCode = E.ContinentCode AND cce.MaxCurrencyCode = E.CurrentMaxCurrencyCode
  ORDER BY E.ContinentCode

--16
SELECT COUNT(*) AS CountryCode 
		   FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mr
			 ON mr.CountryCode = c.CountryCode
		  WHERE mr.MountainId IS NULL

--17
SELECT TOP(5) c.CountryName,MAX(p.Elevation) AS HighestPeakElevation,MAX(r.Length) AS LongestRiverLength 
	  FROM Countries AS c
INNER JOIN CountriesRivers AS cr
		ON cr.CountryCode=c.CountryCode
INNER JOIN Rivers AS r
		ON r.Id=cr.RiverId
INNER JOIN MountainsCountries mc
		ON mc.CountryCode=c.CountryCode
INNER JOIN Mountains AS m
		ON m.Id=mc.MountainId
INNER JOIN Peaks p
		ON p.MountainId=m.Id
  GROUP BY c.CountryName
  ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC

--18
WITH CTE_CountriesHighestElevation AS
(
	   SELECT c.CountryName,
		  CASE 
		  	  WHEN MAX(p.Elevation) IS NULL THEN 0
		  	  ELSE MAX(p.Elevation)
		  END AS [Highest Peak Elevation] FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		   ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks As p
		  ON p.MountainId = mc.MountainId
	GROUP BY c.CountryName
),

CTE_MountainHighestElevation AS
(
	  SELECT m.Id, MAX(p.Elevation) AS mhe 
	    FROM Mountains AS m
	    JOIN Peaks AS p
	      ON p.MountainId = m.Id
	GROUP BY m.Id
)

   SELECT TOP 5
	      he.CountryName AS Country,
	      CASE
	      	 WHEN p.PeakName IS NULL THEN '(no highest peak)'
	      	 ELSE p.PeakName
	      END AS [Highest Peak Name],
	      he.[Highest Peak Elevation],
	      CASE
	      	 WHEN m.MountainRange IS NULL THEN '(no mountain)'
	      	 ELSE m.MountainRange
	      END AS Mountain
     FROM CTE_CountriesHighestElevation As he
	 JOIN Countries AS c
	   ON c.CountryName = he.CountryName
LEFT JOIN MountainsCountries AS mc
	  ON mc.CountryCode = c.CountryCode
LEFT JOIN CTE_MountainHighestElevation AS mh
	  ON mh.Id = mc.MountainId AND mh.mhe = [Highest Peak Elevation]
LEFT JOIN Peaks AS p
	  ON p.Elevation = mh.mhe
LEFT JOIN Mountains AS m
	  ON mc.MountainId = m.Id
   WHERE he.[Highest Peak Elevation] = p.Elevation OR he.[Highest Peak Elevation] = 0
ORDER BY he.CountryName