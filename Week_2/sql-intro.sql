-- a comment

-- first step: make sure the drop-down is set to the corrct database, not "master"
-- Azure does not support the USE statement for swithcing databases

-- Highlight query, then execute to execute just that query

-- SalesLT is the schema name, Customer is the table name
SELECT *
FROM SalesLT.Customer; 

SELECT CustomerID, Title, FirstName, MiddleName, LastName, Suffix
FROM SalesLT.Customer;

-- Brackets allow for spaces in column name
SELECT CustomerID, Title, FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name], Suffix
FROM SalesLT.Customer;

SELECT *
FROM SalesLT.Product;

SELECT ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, ListPrice * 1.08 AS PriceAfterTax, ListPrice * 0.08 AS TaxAmount, ListPrice - StandardCost AS Profit
FROM SalesLT.Product;

SELECT Color, Size
FROM SalesLT.Product;

SELECT DISTINCT Color, Size
FROM SalesLT.Product;

-- Table aliases
SELECT p.Color, p.Size
FROM SalesLT.Product AS p;

-- WHERE clause allows filtring of rows based on a condition (before any calculated columns in the SELECT clause)
-- String literals use single quotes ' '
-- Names of things with spaces in them use double quotes " "
SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'brian';

SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'Brian' AND LastName = 'Goldstein';

-- <> is the 'Not Equals' operator (also supports !=)
SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'Brian' AND LastName != 'Goldstein';

-- Strings can have ordered comparison (<, <=, >, >=) done on them via "dictionary"/lexicographic ordering (basically alphabetic order)
-- The following query returns all names that start with the letter 'B'
SELECT *
FROM SalesLT.Customer
WHERE FirstName >= 'B' AND FirstName < 'C';

-- String functions
SELECT LEFT('123456789', 4);  -- returns '1234'
SELECT RIGHT('123456789', 4); -- returns '6789'
SELECT LEN('123456789');  -- returns the number 9 (the length)

-- String indexes start at 1, *not* 0
SELECT SUBSTRING('123456789', 3, 5); -- returns '34567'; SUBTRING(string, starting index, length of string)
SELECT REPLACE('Hello World!', 'World', 'Devin'); -- returns "Hello Devin!"
SELECT CHARINDEX(' ', 'Hello world!'); -- returns 6 (first index of the character you're searching for)

-- SQL uses LIKE to support its own pattern matching, does not support regex
--	%		any number of characters
--	[abc]	either a, b, or c
-- etc...

SELECT *
FROM SalesLT.Customer
WHERE FirstName LIKE 'Br%';

-- Data types
--	numeric
--		tinyint			1 byte
--		smallint		2 bytes
--		int				4 bytes
--		bigint			8 bytes
--		float
--		decimal			(10,3) means "10 digits total, 3 digits after the deciamal place (ex: 1234567.890)
--		real
--		money
--
--	string
--		char(n)			fixed length character array n characters long
--		varchar(n)		variable length character array up to n characters long
--		nchar(n)		"national" aka Unicode char array
--		nvarchar(n)		Unicode variable length (no reason not to use nvarchar all the time)
--
--	binary
--	varbinary
--	date
--	time
--	datetime			Do *not* use this
--	datetime2			*Do* use this, has more range
--	datetimeoffset		For intervals of time, ex: "5 minutes"

-- String literals are technically VARCHAR: 'Hello'
-- We can make Unicode string literals (NVARCHAR) like: N'Hello'

-- We also have BINARY and VARBINARY for storing binary data directly in the database
-- The ThumbNailPhoto column in the SaleLT.Product table

-- group all rows by first name and count how many instances per name (with more than one instance)
SELECT FirstName, COUNT(FirstName) AS Count
FROM SalesLT.Customer
WHERE COUNT(FirstName)> 1  -- This line will fail
GROUP BY FirstName;

-- WHERE runs before GROUP BY, so we can't filter on any conditions that depend on the grouping

-- COUNT is an aggreagate function, meaning it operates on my functions and returns only one value
--	Note: LEN is not an aggreagte because it operates on one string

-- HAVING is for conditions that run after the GROUP BY
SELECT FirstName, COUNT(FirstName) AS Count
FROM SalesLT.Customer
GROUP BY FirstName
HAVING COUNT(FirstName)> 1;  -- This line will succeed

-- ORDER BY sorts the result set and is the last thing that runs
--	NULL will always first on ASC and last on DESC
SELECT *
FROM SalesLT.Product
ORDER BY Weight DESC;  -- ASC is default order

-- ASC and DESC are tied to the column they are operating on (in this case it's Color ascending, StandardCose descending)
SELECT *
FROM SalesLT.Product
ORDER BY Color, StandardCost DESC;

-- Execution order of a query:
--	FROM
--	WHERE
--	GROUP BY
--	HAVING
--	ORDER BY
--	SELECT

