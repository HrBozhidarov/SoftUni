--1
SELECT COUNT(*) 
  FROM WizzardDeposits

--2
SELECT MAX(MagicWandSize) AS LongestMagicWand 
  FROM WizzardDeposits

--3
  SELECT wd.DepositGroup, MAX(MagicWandSize) 
    FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

--4
  SELECT TOP(2) wd.DepositGroup 
    FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup
ORDER BY AVG(wd.MagicWandSize)

--5
  SELECT wd.DepositGroup, SUM(wd.DepositAmount) 
    FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

--6
  SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS TotalSum 
    FROM WizzardDeposits wd
   WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup

--7
  SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS TotalSum 
    FROM WizzardDeposits wd
   WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup
  HAVING SUM(wd.DepositAmount)<150000
ORDER BY SUM(wd.DepositAmount) DESC

--8
  SELECT wd.DepositGroup, wd.MagicWandCreator, MIN(wd.DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup, wd.MagicWandCreator
ORDER BY wd.MagicWandCreator, wd.DepositGroup

--9
  SELECT AgeGroup = 
	     CASE
		    WHEN wd.Age>=0 AND wd.Age<=10 THEN '[0-10]'
		    WHEN wd.Age>=11 AND wd.Age<=20 THEN '[11-20]'
		    WHEN wd.Age>=21 AND wd.Age<=30 THEN '[21-30]'
		    WHEN wd.Age>=31 AND wd.Age<=40 THEN '[31-40]'
		    WHEN wd.Age>=41 AND wd.Age<=50 THEN '[41-50]'
		    WHEN wd.Age>=51 AND wd.Age<=60 THEN '[51-60]'
		    ELSE '[61+]'
	     END,
         COUNT(*) AS WizardCount
    FROM WizzardDeposits AS wd
GROUP BY CASE
            WHEN wd.Age>=0 AND wd.Age<=10 THEN '[0-10]'
            WHEN wd.Age>=11 AND wd.Age<=20 THEN '[11-20]'
            WHEN wd.Age>=21 AND wd.Age<=30 THEN '[21-30]'
            WHEN wd.Age>=31 AND wd.Age<=40 THEN '[31-40]'
            WHEN wd.Age>=41 AND wd.Age<=50 THEN '[41-50]'
            WHEN wd.Age>=51 AND wd.Age<=60 THEN '[51-60]'
            ELSE '[61+]'
         END

--8
  SELECT wd.DepositGroup, wd.MagicWandCreator, MIN(wd.DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup, wd.MagicWandCreator
ORDER BY wd.MagicWandCreator, wd.DepositGroup

--9
SELECT   AgeGroup = 
         CASE
            WHEN wd.Age>=0 AND wd.Age<=10 THEN '[0-10]'
            WHEN wd.Age>=11 AND wd.Age<=20 THEN '[11-20]'
            WHEN wd.Age>=21 AND wd.Age<=30 THEN '[21-30]'
            WHEN wd.Age>=31 AND wd.Age<=40 THEN '[31-40]'
            WHEN wd.Age>=41 AND wd.Age<=50 THEN '[41-50]'
            WHEN wd.Age>=51 AND wd.Age<=60 THEN '[51-60]'
         ELSE '[61+]'
         END,
         COUNT(*) AS WizardCount
    FROM WizzardDeposits AS wd
GROUP BY CASE
            WHEN wd.Age>=0 AND wd.Age<=10 THEN '[0-10]'
            WHEN wd.Age>=11 AND wd.Age<=20 THEN '[11-20]'
            WHEN wd.Age>=21 AND wd.Age<=30 THEN '[21-30]'
            WHEN wd.Age>=31 AND wd.Age<=40 THEN '[31-40]'
            WHEN wd.Age>=41 AND wd.Age<=50 THEN '[41-50]'
            WHEN wd.Age>=51 AND wd.Age<=60 THEN '[51-60]'
            ELSE '[61+]'
		 END

--10
  SELECT LEFT(FirstName,1) AS FirstLetter 
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName,1)
ORDER BY LEFT(FirstName,1)

--11
  SELECT wd.DepositGroup, wd.IsDepositExpired,AVG(wd.DepositInterest) AS AverageInterest 
    FROM WizzardDeposits AS wd
   WHERE wd.DepositStartDate>'01/01/1985'
GROUP BY wd.DepositGroup,wd.IsDepositExpired
ORDER BY wd.DepositGroup DESC, wd.IsDepositExpired

--12
SELECT SUM(wd1.DepositAmount - wd2.DepositAmount) AS SumDifference 
  FROM WizzardDeposits AS wd1, WizzardDeposits AS wd2
 WHERE wd2.Id - wd1.Id=1

--13
--USE SoftUni
  SELECT DepartmentID, SUM(Salary) AS TotalSalary 
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14
  SELECT DepartmentID , MIN(Salary) AS MinimumSalary 
    FROM Employees
   WHERE HireDate> '01/01/2000'
GROUP BY DepartmentID 
  HAVING DepartmentID IN (2,5,7)

--15
SELECT * INTO EmployeesWithHighSalary
  FROM Employees
 WHERE Salary>30000

DELETE 
  FROM EmployeesWithHighSalary
 WHERE ManagerID=42

UPDATE EmployeesWithHighSalary
   SET Salary +=5000
 WHERE DepartmentID=1

  SELECT DepartmentID, AVG(Salary) AS AverageSalary 
    FROM EmployeesWithHighSalary
GROUP BY DepartmentID

--16
SELECT DepartmentID,MAX(Salary) AS MaxSalary 
  FROM Employees
 GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17
  SELECT COUNT(*) AS [Count] 
    FROM Employees
GROUP BY ManagerID
  HAVING ManagerID IS NULL

--18
SELECT a.DepartmentId,
       (
	        SELECT DISTINCT b.Salary 
		      FROM Employees AS b
	         WHERE b.DepartmentID = a.DepartmentId
	      ORDER BY Salary DESC
	               OFFSET 2 ROWS
	     FETCH NEXT 1 ROWS ONLY
       ) AS [ThirdHighestSalary]
    FROM Employees AS a
   WHERE (
	         SELECT DISTINCT b.Salary 
		       FROM Employees AS b
	          WHERE b.DepartmentID = a.DepartmentId
	       ORDER BY Salary DESC
	                OFFSET 2 ROWS
	      FETCH NEXT 1 ROWS ONLY
		  ) IS NOT NULL
GROUP BY a.DepartmentID

--19
  SELECT TOP(10) FirstName, LastName, DepartmentID 
    FROM Employees AS em1
   WHERE em1.Salary > (
	       SELECT AVG(em2.Salary) AS Sal FROM Employees AS em2
	        WHERE em2.DepartmentID = em1.DepartmentID
	     GROUP BY em2.DepartmentID
         )
ORDER BY DepartmentID


---PROBE
--9
SELECT EE.AgeGroup,COUNT(EE.AgeGroup) 
   FROM (
 SELECT AgeGroup = 
        CASE
           WHEN wd.Age>=0 AND wd.Age<=10 THEN '[0-10]'
           WHEN wd.Age>=11 AND wd.Age<=20 THEN '[11-20]'
           WHEN wd.Age>=21 AND wd.Age<=30 THEN '[21-30]'
           WHEN wd.Age>=31 AND wd.Age<=40 THEN '[31-40]'
           WHEN wd.Age>=41 AND wd.Age<=50 THEN '[41-50]'
           WHEN wd.Age>=51 AND wd.Age<=60 THEN '[51-60]'
           ELSE '[61+]'
        END
   FROM WizzardDeposits AS wd
	     ) AS EE
GROUP BY EE.AgeGroup

--12
SELECT SUM(wd1.DepositAmount - wd2.DepositAmount) 
  FROM WizzardDeposits AS wd1, WizzardDeposits AS wd2
 WHERE wd2.Id - wd1.Id=1

 SELECT SUM(a.dif) 
   FROM 
        (
           SELECT SUM(DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id)) AS dif 
		     FROM WizzardDeposits
        ) AS a