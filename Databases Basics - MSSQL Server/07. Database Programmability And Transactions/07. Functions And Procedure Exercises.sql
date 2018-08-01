--1
CREATE PROC usp_GetEmployeesSalaryAbove35000 
	AS
	   SELECT FirstName, LastName FROM Employees
	   WHERE Salary>35000

  EXEC usp_GetEmployeesSalaryAbove35000
GO

--2
CREATE PROC usp_GetEmployeesSalaryAboveNumber 
	   @Salary DECIMAL(18,4)
	AS
	   SELECT FirstName,LastName FROM Employees
	   WHERE Salary>=@Salary

EXEC usp_GetEmployeesSalaryAboveNumber 48100
GO

--3
CREATE PROC usp_GetTownsStartingWith 
	   @Character NVARCHAR(50)
	AS
	   SELECT Name AS Town FROM Towns
	   WHERE LOWER(@Character)=LOWER(LEFT(Name,LEN(@Character)))

  EXEC usp_GetTownsStartingWith B
GO

--4
CREATE OR ALTER PROC usp_GetEmployeesFromTown 
	            @Town NVARCHAR(50)
		 	 AS
		 SELECT FirstName,LastName FROM Employees AS e
		   JOIN Addresses AS a ON a.AddressID=e.AddressID
		   JOIN Towns AS t ON t.TownID=a.TownID
		  WHERE @Town=t.Name

           EXEC usp_GetEmployeesFromTown 'Sofia'
GO

--5
 CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(7)
	 AS
  BEGIN
		DECLARE @Result NVARCHAR(7);

		IF(@salary<30000)
		BEGIN
			SET @Result='Low';
		END
		ELSE IF(@salary<=50000)
		BEGIN
			SET @Result='Average'
		END
		ELSE 
		BEGIN
			SET @Result='High'
		END

		RETURN @Result;
    END
GO

SELECT Salary,dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees
GO

--6
CREATE PROC usp_EmployeesBySalaryLevel 
	   @SalaryLevel NVARCHAR(7)
	AS
	   SELECT FirstName, LastName FROM Employees
	   WHERE dbo.ufn_GetSalaryLevel(Salary)=@SalaryLevel
GO

EXEC usp_EmployeesBySalaryLevel 'High'
GO

--7
 CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
	 RETURNS BIT
		      AS
		         BEGIN
			      SET @word=LOWER(@word);
			      DECLARE @counter INT = 1;
			      DECLARE @wordLen INT = LEN(@word);
	
			      WHILE(@counter<=@wordLen)
			     BEGIN
				  DECLARE @currentCharacter NCHAR = LOWER((SUBSTRING(@word,@counter,1)));
				  DECLARE @index INT = CHARINDEX(@currentCharacter,LOWER(@setOfLetters),1);
	              
				  IF @index=0 RETURN 0
	              
				  SET @counter+=1;
			     END
			
		 RETURN 1;
		    END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')
GO

--8
CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN
    DECLARE @EmployeesIdToDelete TABLE (Id INT)

    INSERT INTO @EmployeesIdToDelete
         SELECT e.EmployeeID
           FROM Employees e
          WHERE e.DepartmentID = @DepartmentId

     ALTER TABLE Departments
    ALTER COLUMN ManagerID INT NULL
    
    DELETE FROM EmployeesProjects
          WHERE EmployeeID IN (SELECT Id FROM @EmployeesIdToDelete)

    UPDATE Employees
       SET ManagerID = NULL
     WHERE ManagerID IN (SELECT Id FROM @EmployeesIdToDelete)

    UPDATE Departments
       SET ManagerId = NULL
     WHERE ManagerID IN (SELECT Id FROM @EmployeesIdToDelete)

    DELETE FROM Employees
          WHERE EmployeeID IN (SELECT Id FROM @EmployeesIdToDelete)

    DELETE FROM Departments
          WHERE DepartmentID = @DepartmentId

        SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
    INNER JOIN Departments AS d
            ON d.DepartmentID = e.DepartmentID
         WHERE e.DepartmentID = @DepartmentId
END

EXEC usp_DeleteEmployeesFromDepartment 4
GO

--9
CREATE PROC usp_GetHoldersFullName 
	AS
 BEGIN
	   SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM AccountHolders
   END
GO

--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Number DECIMAL(16,2))
	AS
 BEGIN
	   SELECT ac.FirstName,ac.LastName FROM AccountHolders AS ac
	   INNER JOIN Accounts AS a ON a.AccountHolderId = ac.Id
	   GROUP BY ac.FirstName,ac.LastName
	   HAVING SUM(a.Balance)>=@Number
 END

 EXEC usp_GetHoldersWithBalanceHigherThan 30000
 GO

 --11
 CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(16,2), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(16,4)
	 AS
	    BEGIN
		   DECLARE @result DECIMAL(16,4) = @sum * (POWER((1 + @yearlyInterestRate), @numberOfYears));
		
		   RETURN @result
	    END
GO

SELECT dbo.ufn_CalculateFutureValue(1000,10,5)
GO

--12
CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @intersetRate FLOAT)
	AS
	   BEGIN
		   SELECT a.Id AS [Account Id], ah.FirstName AS [First Name],
		          ah.LastName AS [Last Name],a.Balance AS [Current Balance],
		          [dbo] .ufn_CalculateFutureValue(a.Balance,@intersetRate,5) AS [Balance in 5 years]
		     FROM Accounts AS a
		     JOIN AccountHolders AS ah ON ah.Id=a.AccountHolderId 
		    WHERE a.Id=@accountId

	     END

EXEC  usp_CalculateFutureValueForAccount 1,0.1

--13
--USE Diablo db
CREATE function ufn_CashInUsersGames (@gameName NVARCHAR(100))
	RETURNS TABLE
	AS
		RETURN (SELECT SUM(T.Cash) AS SumCash FROM (SELECT ROW_NUMBER() OVER(ORDER BY UG.Cash DESC) AS Row,ug.Cash FROM Games AS G
				  JOIN UsersGames AS UG ON UG.GameId=G.Id
				 WHERE G.Name=@gameName) AS T
				 WHERE T.Row % 2 = 1);

GO
SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

--USE Bank db
--14
CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
            AS
               INSERT INTO Logs
                    SELECT inserted.Id, deleted.Balance, inserted.Balance FROM inserted
                      JOIN deleted
						ON inserted.Id = deleted.Id
				    UPDATE Accounts
				       SET Balance=113.12
				     WHERE Id=1

--15
CREATE TABLE NotificationEmails (
	   Id INT PRIMARY KEY IDENTITY,
	   Recipient INT FOREIGN KEY REFERENCES Accounts (Id),
	   Subject NVARCHAR(600) NOT NULL,
	   Body NVARCHAR(600) NOT NULL
)
GO

CREATE TRIGGER tr_LogsInsert ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient,Subject,Body)
	SELECT I.AccountId,CONCAT('Balance change for account: ',I.AccountId),
	CONCAT('On ',CAST(DATENAME(month, GETDATE()) AS CHAR(3)),' ',DATEPART(DAY,GETDATE()),' ',DATEPART(YEAR,GETDATE()),' ',CONVERT(varchar(15),CAST(GETDATE() AS TIME),100),' ','your balance was changed from ',I.OldSum,I.NewSum,'.') 
	FROM inserted AS I
	JOIN Accounts AS D ON D.Id=I.LogId
END
GO

INSERT INTO Logs VALUES
(1,113.14,123.14)

SELECT * FROM Logs
GO

--16
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY) 
AS
BEGIN
	BEGIN TRAN
	IF @MoneyAmount>0
	BEGIN
		UPDATE Accounts
			SET Balance+=@MoneyAmount
		WHERE @AccountId=Id

		IF @@ROWCOUNT != 1
		BEGIN 
			ROLLBACK
			RAISERROR('Invalid', 16, 1)
			RETURN
		END
	END

	COMMIT
END

EXEC usp_DepositMoney 1, 10
SELECT Id,AccountHolderId, CAST(Balance AS DECIMAL(18,4)) AS Balance FROM Accounts
WHERE Id=1
GO

--17
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY) AS
BEGIN
	BEGIN TRAN
	IF @MoneyAmount>0
	BEGIN
		UPDATE Accounts
			SET Balance-=@MoneyAmount
		WHERE @AccountId=Id

		DECLARE @currentMoney DECIMAL(16,2)= (SELECT TOP(1) Balance FROM Accounts WHERE Id=@AccountId) 

		IF @@ROWCOUNT != 1 OR @currentMoney < 0
		BEGIN 
			ROLLBACK
			RAISERROR('Invalid', 16, 1)
			RETURN
		END
	END

	COMMIT
END

EXEC usp_WithdrawMoney 1, 100
SELECT Id,AccountHolderId, CAST(Balance AS DECIMAL(18,4)) AS Balance FROM Accounts
WHERE Id=1
GO

--18
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL) AS
BEGIN
	EXEC usp_WithdrawMoney @SenderId,@Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
END

EXEC usp_TransferMoney 5,1,5000

SELECT * FROM Accounts A
WHERE A.Id=1 OR A.Id=5

--USE Diablo db
--19

--20

--USE SoftUni
--21
CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
	BEGIN
		BEGIN TRAN
			INSERT INTO EmployeesProjects VALUES
			(@emloyeeId, @projectID)

			DECLARE @count INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId);

			IF (@count > 3)
			BEGIN
				ROLLBACK
				RAISERROR('The employee has too many projects!', 16, 1)
				RETURN
			END

		COMMIT
	END

--22
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentID INT NOT NULL,
	Salary MONEY NOT NULL
)
GO

CREATE TRIGGER tr_EmployeesDeleted ON Employees FOR DELETE AS
BEGIN
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT d.FirstName,d.LastName,d.MiddleName,d.JobTitle,d.DepartmentID,d.Salary FROM deleted AS d
END
