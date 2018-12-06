SELECT * FROM SalesLT.Customer;
SELECT * FROM SalesLT.CustomerAddress;
SELECT * FROM SalesLT.Address;

SELECT c.FirstName, c.LastName, a.AddressLine1, a.AddressLine2, a.City, a.StateProvince
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID
WHERE a.City = 'Houston' AND a.StateProvince = 'Texas';

-- Find all customers with multiple addresses
SELECT c.FirstName, c.LastName
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID
GROUP BY c.FirstName, c.LastName
HAVING COUNT(c.CustomerID) > 1


SELECT c.FirstName, c.LastName, a.AddressLine1, a.AddressLine2, a.City, a.StateProvince
FROM SalesLT.Customer AS c
	FULL OUTER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	FULL OUTER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID

-- Subqueries are an alternative way to accomplish what joins do

-- Operators:
--	IN		checking membership in a list
--	NOT IN	is not a member is a list
--	EXISTS
--	ANY		any conditions are true
--	ALL		all conditions are true

-- BIT is boolean type in SQL

-- Get the name and addresses of all customers in Houston
SELECT FirstName, LastName
FROM SalesLT.Customer
WHERE CustomerID IN
	(
		SELECT CustomerID
		FROM SalesLT.CustomerAddress
		WHERE AddressID IN
			(
				SELECT AddressID
				FROM SalesLT.Address
				WHERE City = 'Houston' AND StateProvince = 'Texas'
			)
	)

-- Get all first name that are the same as a last name
SELECT FirstName, LastName
FROM SalesLT.Customer
ORDER BY FirstName;

SELECT DISTINCT a.FirstName, a.LastName
FROM SalesLT.Customer AS a
	INNER JOIN SalesLT.Customer b ON a.FirstName = b.LastName

SELECT *
FROM SalesLT.Customer
ORDER BY FirstName, LastName;
-- But it doesn't work because of multiple customer records ??????

-- Set operators in SQL:
--	UNION		gives all records in *either* of the two results sets ("addition")
--	INTERSECT	gives all records in *both* results sets
--	EXCEPT		gives all records in the *first* but not the *second* result set
-- These don't go inside a SELECT statement, they combine two SELECT statements

SELECT FirstName FROM SalesLT.Customer WHERE FirstName LIKE 'A%'
UNION
SELECT LastName FROM SalesLT.Customer WHERE LastName LIKE 'A%';

-- All set operators by default remove duplicates, but they have "all" versions where return the duplicates (faster to run because they don't have to detect and remove duplicates)
SELECT FirstName FROM SalesLT.Customer WHERE FirstName LIKE 'A%'
UNION ALL
SELECT LastName FROM SalesLT.Customer WHERE LastName LIKE 'A%';

SELECT FirstName FROM SalesLT.Customer
INTERSECT
SELECT LastName FROM SalesLT.Customer;

-- NULL represents a missing piece of data, all comparisons with NULL come out false, even '= NULL'
-- use 'IS NULL' to check for something being NULL
-- All things combined with NULL result in NULL