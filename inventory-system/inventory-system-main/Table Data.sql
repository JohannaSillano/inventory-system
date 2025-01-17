INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, Address, Password, Role)
VALUES 
('Alice', 'Guo', 'admin@gmail.com', '123-456-7890', '123 Admin St, Cityville', '1234', 'Admin'),
('Bengie', 'Villesco', 'cashier1@gmail.com', '987-654-3210', '456 Cashier Ave, Towncity', '1234', 'Cashier'),
('Johanna', 'Sillano', 'cashier2@gmail.com', '555-123-4567', '789 Worker Blvd, Metrocity', '1234', 'Cashier');

INSERT INTO Products (Name, Description, Price, StockQuantity, Category, IsDeleted, DateAdded, DateExpired)
VALUES 
('Chess', 'Description of Product 1', 19.99, 100, 'Toy', 0, GETDATE(), '2026-01-01'),
('Headphone', 'Description of Product 2', 299.99, 200, 'Electronics', 0, GETDATE(), '2026-01-01'),
('Barbie', 'Description of Product 3', 29.99, 200, 'Toy', 0, GETDATE(), '2026-01-01'),
('Lego', 'Description of Product 4', 150, 200, 'Toy', 0, GETDATE(), '2026-01-01'),
('Chair', 'Description of Product 5', 599.99, 200, 'Furniture', 0, GETDATE(), '2026-01-01'),
('Uno', 'Description of Product 6', 250, 200, 'Toy', 0, GETDATE(), '2026-01-01'),
('Charger', 'Description of Product 7', 70, 200, 'Electronics', 0, GETDATE(), '2026-01-01'),
('Phone', 'Description of Product 8', 23, 50, 'Electronics', 0, GETDATE(), '2026-01-01');

SELECT * FROM Employees
SELECT * FROM Products
--Data from POS
SELECT * FROM Sales




