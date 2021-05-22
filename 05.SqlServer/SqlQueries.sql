--use CTRL SHIFT Q for getting query designer to get formatted query
SELECT *
FROM Customers

WHERE Address IS NOT NULL;

Select count(*) from Customers;

Select top 4 * from Customers;

--AGG Functions - similarly use MAX,AVG,SUM,Count functions 
Select MIN(UnitPrice) as smallestprice from Products;

 --The percent sign (%) represents zero, one, or multiple characters
 --The underscore sign (_) represents one, single character
--LIKE Operator	Description
--WHERE CustomerName LIKE 'a%'	Finds any values that start with "a"
--WHERE CustomerName LIKE '%a'	Finds any values that end with "a"
--WHERE CustomerName LIKE '%or%'	Finds any values that have "or" in any position
--WHERE CustomerName LIKE '_r%'	Finds any values that have "r" in the second position
--WHERE CustomerName LIKE 'a_%'	Finds any values that start with "a" and are at least 2 characters in length
--WHERE CustomerName LIKE 'a__%'	Finds any values that start with "a" and are at least 3 characters in length
--WHERE ContactName LIKE 'a%o'	Finds any values that start with "a" and ends with "o"


SELECT * FROM Customers
WHERE ContactName LIKE '_r%';

SELECT * FROM Products
WHERE UnitPrice BETWEEN 10 AND 20;

SELECT ContactName AS Customer, ContactName AS [Contact Person]
FROM Customers;

--If some customers or suppliers have the same city, each city will only be listed once, 
--because UNION selects only distinct values. Use UNION ALL to also select duplicate values
SELECT City FROM Customers
UNION 
SELECT City FROM Suppliers
ORDER BY City;

-- if agg is not used, gives error - 
--Column 'Customers.ContactName' is invalid in the select list because 
--it is not contained in either an aggregate function or the GROUP BY clause.
--The following SQL statement lists the number of customers in each country:
Select count(CustomerID), Country
--,ContactName 
from Customers
Group By Country

-- same as above, just orders from high to low, notice AGG function in ORDER BY
SELECT COUNT(CustomerID), Country
FROM Customers
GROUP BY Country
ORDER BY COUNT(CustomerID) DESC;


--lists the number of orders sent by each shipper
SELECT Shippers.CompanyName as [Shipper Name], COUNT(Orders.OrderID) AS NumberOfOrders FROM Orders
LEFT JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID
GROUP BY Shippers.CompanyName;

--gives same count as above query, even though orders table has duplicate values for ShipCountry column
SELECT Shippers.CompanyName as [Shipper Name], COUNT(Orders.ShipCountry) AS NumberOfOrders FROM Orders
LEFT JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID
GROUP BY Shippers.CompanyName;

-- having on top of group by
SELECT COUNT(CustomerID), Country
FROM Customers
GROUP BY Country
HAVING COUNT(CustomerID) > 5
ORDER BY COUNT(CustomerID) DESC;

--lists if the employees "Davolio" or "Fuller" have registered more than 25 orders
SELECT Employees.LastName, COUNT(Orders.OrderID) AS NumberOfOrders
FROM Orders
INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID
WHERE LastName = 'Davolio' OR LastName = 'Fuller'
-- notice GROUP BY is applied after WHERE. WHERE Cannot be applied after GROUP BY
GROUP BY LastName
HAVING COUNT(Orders.OrderID) > 25;


--this gives same result as above. The WHERE clause is removed and the condition is moved to HAVING
SELECT Employees.LastName, COUNT(Orders.OrderID) AS NumberOfOrders
FROM Orders
INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID
-- notice GROUP BY is applied after WHERE. WHERE Cannot be applied after GROUP BY
GROUP BY LastName
HAVING COUNT(Orders.OrderID) > 25 AND LastName = 'Davolio' OR LastName = 'Fuller';












