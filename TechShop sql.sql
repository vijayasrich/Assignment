--create databse
create database TechShop
--create table customer
create table Customers(
CustomerID int identity(1,1) primary key,
FirstName varchar(20) not null,
LastName varchar(20) not null,
Email varchar(50) not null unique,
Phone varchar(20),
[Address] varchar(100))
--create table products
create table Products(
ProductID int identity(1,1) primary key,
ProductName varchar(20) not null,
[Description] text not null,
Price decimal(10,2) not null)
--create table orders
create table Orders(
OrderID int identity(1,1) primary key,
CustomerID int,
OrderDate date not null,
TotalAmount decimal(10,2) not null
Foreign key(CustomerID)references Customers(CustomerID))
--create table orderdetails
create table OrderDetails(
OrderDetailsID int identity(1,1) primary key,
OrderID int not null,
ProductID int not null,
Quantity int not null,
foreign key(OrderID) references Orders(OrderID),
foreign key(ProductID) references Products(ProductID))
--ctreate table inventory
create table Inventory(
InventoryID int identity(1,1) primary key,
ProductID int not null,
QuantityInStock int not null,
LastStockUpdate date not null,
foreign key(ProductID) references Products(ProductID))

insert into Customers(FirstName,LastName,Email,Phone,[Address]) values
('a','a','aa@gmail.com','1234567891','aa,AP'),
('b','b','bb@gmail.com','1235678922','bb,TN'),
('c','c','cc@gmail.com','1234567893','cc,TS'),
('d','d','dd@gmail.com','1234567894','dd,TN'),
('e','e','ee@gmail.com','1234567895','ee,AP'),
('f','f','ff@gmail.com','1234567896','ff,TS'),
('g','g','gg@gmail.com','1234567897','gg,TN'),
('h','h','hh@gmail.com','1234567898','hh,AP'),
('i','i','ii@gmail.com','1234567899','ii,AP'),
('j','j','jj@gmail.com','2345678911','jj,TS'),
('k','k','kk@gmail.com','2345678912','kk,TS')

insert into Products(ProductName,[Description],Price) values
('Laptop','15-inch laptop',55000),
('Smartphone', 'Latest 5G smartphone', 30000),
('Tablet', '10-inch tablet', 25000),
('Smartwatch', 'Fitness tracker with heart rate monitor', 10000),
('Headphones', 'Noise-cancelling over-ear headphones', 7000),
('Camera', 'Digital camera with sensor',50000 ),
('Printer', 'Wireless inkjet printer', 8500),
('Monitor', '27-inch 4K monitor', 20000),
('Keyboard', 'Mechanical keyboard with RGB lighting', 4000),
('Mouse', 'Wireless mouse', 3500),
('Smart TV', 'LED display', 60000)

insert into Orders(CustomerID,OrderDate,TotalAmount) values
(1,'2024-09-01',10000),
(2, '2024-09-02',7000),
(3, '2024-09-03',8500),
(4, '2024-09-04',55000),
(5, '2024-09-05',25000),
(6, '2024-09-06',50000),
(7, '2024-09-07',8000),
(8, '2024-09-08',20000),
(9, '2024-09-09',3500),
(10,'2024-09-10',50000),
(11,'2024-09-11',120000)

insert into OrderDetails(OrderID,ProductID,Quantity) values
(1,4,1),
(2,5,1),
(3,7,1),
(4,1,1),
(5,3,1),
(6,6,1),
(7,9,2),
(8,8,1),
(9,10,1),
(10,6,1),
(11,11,2)

insert into Inventory(ProductID,QuantityInStock,LastStockUpdate) values
(1,20,'2024-09-10'),
(2,25,'2024-09-11'),
(3,50,'2024-09-12'),
(4,90,'2024-09-13'),
(5,67,'2024-09-14'),
(6,56,'2024-09-15'),
(7,76,'2024-09-16'),
(8,100,'2024-09-17'),
(9,45,'2024-09-18'),
(10,50,'2024-09-19'),
(11,20,'2024-09-20')

--Task 2
--1. Write an SQL query to retrieve the names and emails of all customers.  
select FirstName,LastName,Email from Customers 

--2. Write an SQL query to list all orders with their order dates and corresponding customer names.
select o.OrderID,o.OrderDate,c.FirstName,c.LastName
from Orders o
join Customers c on o.CustomerID=c.CustomerID

--3. Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address. 
insert into Customers(FirstName,LastName,Email,Phone,[Address])values('u','v','uv@gmail.com','1234578919','uvw')
select * from Customers

--4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%. 
update Products
set Price=Price*1.10
select * from Products

--5. Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables.Allow users to input the order ID as a parameter. 
declare @OrderID int ='4'
delete from Orders where OrderID=@OrderID
select * from OrderDetails
select * from Orders


--6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information. 
insert into Orders(CustomerID,OrderDate,TotalAmount)values(12,'2024-09-12',17000)
select * from Orders

--7. Write an SQL query to update the contact information (e.g., email and address) of a specific customer in the "Customers" table. Allow users to input the customer ID and new contact information. 
declare @CustomerID varchar(20)
set @CustomerID=12
update Customers
set Email='uu@gmail.com',[address]='uu,TN'
where CustomerID=@CustomerID
select * from Customers

--8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" table based on the prices and quantities in the "OrderDetails" table. 
update Orders 
set TotalAmount = isnull((select sum(Products.Price * OrderDetails.Quantity) 
from OrderDetails 
join Products on OrderDetails.ProductID = Products.ProductID 
where OrderDetails.OrderID = Orders.OrderID),0)
--9. Write an SQL query to delete all orders and their associated order details for a specific customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID as a parameter. 
declare @CustomerID1 int 
set @CustomerID1=1
delete from Orders where CustomerID=@CustomerID1
select * from OrderDetails
select * from Orders

--10. Write an SQL query to insert a new electronic gadget product into the "Products" table, including product name, category, price, and any other relevant details. 
alter table Products
add  Category varchar(50)
update Products
set Category =case
when ProductName IN ('Laptop', 'Smartphone', 'Tablet', 'Smartwatch','Camera','Printer','Monitor') then 'Electronic'
when ProductName IN ('Headphones', 'Keyboard', 'Mouse') then 'Accessories'
when ProductName in('Smart TV') then 'ELectronic'
end
insert into Products(ProductName,[Description],Price,Category) values('Pendrive','60 GB',2000,'Accessories')
select * from Products

--11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from "Pending" to "Shipped"). Allow users to input the order ID and the new status. 
alter table Orders
add [Status] varchar(20)
update Orders
set [status]=case
when OrderID in(1,3,5,7,9,11) then 'Pending'
when OrderID in (2,4,6,8,10,12) then 'Shipped'
end
select * from Orders
declare @OrderID1 int 
set @OrderID1=3
update Orders
set [Status]='Shipped'
where OrderID=@OrderID1
select * from Orders

--12. Write an SQL query to calculate and update the number of orders placed by each customer in the "Customers" table based on the data in the "Orders" table.
alter table Customers
add NumberOfOrders int default 0
update Customers
set NumberOfOrders=(select count(*) from Orders where Orders.CustomerID=Customers.CustomerID)
select * from Customers

--Task 3

--1. Write an SQL query to retrieve a list of all orders along with customer information (e.g., customer name) for each order. 
select O.OrderID, C.FirstName, C.LastName, O.OrderDate 
from Orders O
join Customers C on O.CustomerID = C.CustomerID

--2. Write an SQL query to find the total revenue generated by each electronic gadget product. Include the product name and the total revenue. 
select P.ProductName, sum(OD.Quantity * P.Price) as TotalRevenue
from OrderDetails OD
join Products P on OD.ProductID = P.ProductID
group by P.ProductName

--3. Write an SQL query to list all customers who have made at least one purchase. Include their names and contact information.
select distinct C.FirstName, C.LastName, C.Email,C.Phone
from Orders O
join Customers C on O.CustomerID = C.CustomerID

--4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest total quantity ordered. Include the product name and the total quantity ordered. 
select top 1 P.ProductID,P.ProductName, sum(OD.Quantity) as TotalQuantity
from OrderDetails OD 
join Products P on OD.ProductID = P.ProductID
group by P.ProductName,P.ProductID
order by TotalQuantity desc

--5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding categories. 
select *
from Products
where Category='Electronic'

--6. Write an SQL query to calculate the average order value for each customer. Include the customer's name and their average order value. 
select C.FirstName, C.LastName, avg(O.TotalAmount) as AvgOrderValue
from Orders O
join Customers C on O.CustomerID = C.CustomerID
group by C.CustomerID,C.FirstName,C.LastName

--7. Write an SQL query to find the order with the highest total revenue. Include the order ID, customer information, and the total revenue. 
select top 1 O.OrderID, C.FirstName, C.LastName, O.TotalAmount
from Orders O
join Customers C on O.CustomerID = C.CustomerID
order by O.TotalAmount desc

--8. Write an SQL query to list electronic gadgets and the number of times each product has been ordered. 
select P.ProductName, count(OD.Quantity) as NumberOfOrders
from Products P
join OrderDetails OD on P.ProductID = OD.ProductID
join Orders O on OD.OrderID=O.OrderID
where p.Category='Electronic'
group by P.ProductName

--9. Write an SQL query to find customers who have purchased a specific electronic gadget product. Allow users to input the product name as a parameter. 
declare @ProductName varchar(20)
set @ProductName='Monitor'
select distinct C.FirstName, C.LastName 
from OrderDetails OD 
join Orders O on OD.OrderID = O.OrderID
join Customers C on O.CustomerID = C.CustomerID
join Products P on OD.ProductID = P.ProductID
where P.ProductName = @ProductName

--10. Write an SQL query to calculate the total revenue generated by all orders placed within a specific time period. Allow users to input the start and end dates as parameters. 
declare @StartDate date ='2024-09-01'
declare @EndDate date ='2024-09-02'
select sum(O.TotalAmount) as TotalRevenue 
from Orders O
where O.OrderDate between @StartDate and @EndDate

--Task 4

--1. Write an SQL query to find out which customers have not placed any orders. 
select Customers.CustomerID, Customers.FirstName, Customers.LastName
from Customers
where CustomerID not in (select CustomerID from Orders)

--2. Write an SQL query to find the total number of products available for sale.  
select (select count(ProductID) from Products) as TotalProducts

--3. Write an SQL query to calculate the total revenue generated by TechShop.
select (select sum(TotalAmount) from Orders) as TotalRevenue

--4. Write an SQL query to calculate the average quantity ordered for products in a specific category. Allow users to input the category name as a parameter. 
update Products
set Description = cast([Description] as varchar(255))+ cast(' Electronic' as varchar(255))
select * from Products
declare @Category varchar(20) = 'Electronic' 
select Avg(Quantity) AS AvgQuantityOrdered
from OrderDetails
where ProductID IN (
select ProductID 
from Products 
where [Description] like '%' + @Category + '%')


--5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users to input the customer ID as a parameter. 
declare @CustomerId5 int ='2'
select (select sum(TotalAmount) 
from Orders 
where CustomerID = @CustomerID5) as TotalRevenue

--6. Write an SQL query to find the customers who have placed the most orders. List their names and the number of orders they've placed. 
select top 3 C.FirstName, C.LastName, OrderCount
from Customers C
join(
select CustomerID,count(OrderID) as OrderCount 
from orders 
group by CustomerID) as OrderCounts on C.CustomerID = OrderCounts.CustomerID
order by OrderCount  desc

--7. Write an SQL query to find the most popular product category, which is the one with the highest total quantity ordered across all orders. 
select top 1 Category,total_quantity_ordered
from (
select P.Category,sum(OD.quantity) as total_quantity_ordered
from Products P
join OrderDetails OD on P.ProductID = Od.ProductID
group by P.Category) as Category_totals
order by total_quantity_ordered desc

--8. Write an SQL query to find the customer who has spent the most money (highest total revenue) on electronic gadgets. List their name and total spending. 
select top 1 C.FirstName, C.LastName,total_spent
from Customers c
join(
select O.CustomerID,sum(OD.quantity * P.price) as total_spent
from Orders O
join OrderDetails od on O.OrderID = OD.OrderID
join Products P on OD.ProductID = P.ProductID
where P.Category like '%Electronic%'
group by O.CustomerID) as spending on C.CustomerID = spending.CustomerID
order by  total_spent desc

--9. Write an SQL query to calculate the average order value (total revenue divided by the number of orders) for all customers. 
select (select avg(TotalAmount) from Orders) as AvgOrderValue

--10. Write an SQL query to find the total number of orders placed by each customer and list their names along with the order count.
select FirstName, LastName, OrderCount
from (
select Customers.FirstName, Customers.LastName, count(Orders.OrderID) as OrderCount
from Orders
join Customers on Orders.CustomerID = Customers.CustomerID
group by Customers.CustomerID, Customers.FirstName, Customers.LastName) as OrderCount
select * from Customers
select * from Products
select * from Orders
select * from OrderDetails
select * from Inventory