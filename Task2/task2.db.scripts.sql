/* Follow instructions in order */ 

/* 1. Create Database */
CREATE DATABASE Task2;
 
/* 2. Select Database */
USE Task2;	

/* 3. Run this commands all together until 'END table create and value insertion' comment*/
/* It will create Products, Category tables and their relations, also it will populate the tables*/

/* START tables create and value insertion */ 
CREATE TABLE Products(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100)
);

CREATE TABLE Categories(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100)
);

CREATE TABLE Products_Categories(
    Products_Id INT references Products(Id),
    Categories_Id INT references Categories(Id),
    PRIMARY KEY (Products_Id, Categories_Id)
)

INSERT INTO Categories (CategoryName) VALUES
('Electronics'),
('Clothing'),
('Books'),
('Home & Kitchen'),
('Toys'),
('Gadgets');

INSERT INTO Products (ProductName) VALUES
('Smartphone'),
('T-Shirt'),
('Book'),
('Laptop'),
('Sneakers'),
('Blender'),
('Smartwatch'),
('Tablet'),
('Tv');

INSERT INTO Products_Categories (Products_Id, Categories_Id) VALUES
(1, 1),  
(2, 2),  
(3, 3),  
(4, 1),    
(6, 4),  
(7, 1),
(1, 6),
(4, 6);
/* END tables create and value insertion */ 

/* 4. Script to select all Products with Category
When category is not assigned to the product, ProductName is displayed*/
SELECT p.ProductName,
 CASE 
   WHEN C.CategoryName IS NOT NULL 
   THEN C.CategoryName
    ELSE P.ProductName
    END AS CategoryName
FROM Products p
LEFT JOIN Products_Categories pc ON p.Id = pc.Products_Id
LEFT JOIN Categories c ON pc.Categories_Id = c.Id;