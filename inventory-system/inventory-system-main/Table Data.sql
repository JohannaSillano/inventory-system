-- Insert data into Employees table
INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, Address, Password, Role)
VALUES
('Alice', 'Guo', 'admin@gmail.com', '123-456-7890', '123 Admin St, Cityville', '123456', 'Admin'),
('Bengie', 'Villesco', 'cashier1@gmail.com', '987-654-3210', '456 Cashier Ave, Towncity', '123456', 'Cashier'),
('Johanna', 'Sillano', 'cashier2@gmail.com', '555-123-4567', '789 Worker Blvd, Metrocity', '123456', 'Cashier'),
('Edzra', 'Macas', 'cashier3@gmail.com', '654-987-3210', '101 Worker Rd, Cityville', '123456', 'Cashier');

-- Insert data into Products table (Mini Mart products like grocery, hygiene, etc.)
INSERT INTO Products (Name, Description, Price, StockQuantity, Category, IsDeleted, DateAdded, DateExpired)
VALUES
('Lucky Me! Instant Pancit Canton', 'Instant Pancit Canton noodles, 100g, 5-pack, quick and easy meal option', 50.00, 150, 'Food', 0, GETDATE(), '2026-01-01'),
('Ayam Brand Canned Tuna', '180g canned tuna in oil, Ayam Brand, great for sandwiches and salads', 60.00, 100, 'Food', 0, GETDATE(), '2026-01-01'),
('Colgate Toothpaste', 'Mint flavored toothpaste, 100g, Colgate, for a fresh and clean mouth', 55.00, 200, 'Hygiene', 0, GETDATE(), '2026-01-01'),
('Head & Shoulders Shampoo', 'Anti-dandruff shampoo, 200ml, Head & Shoulders, for dandruff-free hair', 80.00, 200, 'Hygiene', 0, GETDATE(), '2026-01-01'),
('Surf Excel Detergent Powder', '1kg laundry detergent powder, Surf Excel, effective for stain removal', 120.00, 75, 'Household', 0, GETDATE(), '2026-01-01'),
('Quaker Oats', '500g pack of instant oats, Quaker, healthy breakfast choice', 45.00, 200, 'Food', 0, GETDATE(), '2026-01-01'),
('Gold Label Cooking Oil', '1L bottle of vegetable cooking oil, Gold Label, ideal for frying and cooking', 100.00, 150, 'Food', 0, GETDATE(), '2026-01-01'),
('Palmolive Dishwashing Liquid', '500ml dishwashing liquid, Palmolive, for effective grease removal', 45.00, 100, 'Household', 0, GETDATE(), '2026-01-01'),
('Chippy Assorted Biscuits', 'Pack of assorted Chippy biscuits, delicious snack for all ages', 30.00, 120, 'Food', 0, GETDATE(), '2026-01-01'),
('Charmin Toilet Paper', '12-roll pack of soft toilet paper, Charmin, for comfort and strength', 80.00, 200, 'Hygiene', 0, GETDATE(), '2026-01-01');

-- Select all records from Employees table
SELECT * FROM Employees;

-- Select all records from Products table
SELECT * FROM Products;

-- Select all records from Sales table (assuming a Sales table structure)
SELECT * FROM Sales;
