USE task4

/****** Script for Selecting All Employees  ******/
SELECT *
FROM Employees;


/****** Script for Selecting Employees that have salary greather than 10.000 ******/
SELECT *
FROM Employees
WHERE Salary > 10000;

/****** Script for Deleting Employees over 70 ******/
DELETE 
FROM Employees
WHERE DateOfBirth < DATEADD(YEAR, -70, GETDATE());

/****** Script for Updating salary to 15.000 where salary is less ******/
UPDATE Employees
SET Salary = 15000
WHERE Salary < 15000;
