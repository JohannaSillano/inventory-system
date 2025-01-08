CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    Category NVARCHAR(255) NOT NULL,
    IsDeleted BIT NOT NULL,
    DateAdded DATETIME NOT NULL DEFAULT GETDATE() -- Added column
);

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key
    FirstName NVARCHAR(50) NOT NULL,   -- First name column with a maximum length of 50 characters
    LastName NVARCHAR(50) NOT NULL,   -- Last name column with a maximum length of 50 characters
    Email NVARCHAR(100) NOT NULL,      -- Email column with a maximum length of 100 characters
    Password NVARCHAR(255) NOT NULL    -- Password column with a maximum length of 255 characters (for hashed passwords)
);

CREATE TABLE UserProfiles (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    FirstName NVARCHAR(255) NOT NULL,  -- First name (required)
    LastName NVARCHAR(255) NOT NULL,   -- Last name (required)
    Email NVARCHAR(255) NOT NULL,      -- Email (required)
    PhoneNumber NVARCHAR(50) NOT NULL, -- Phone number (required)
    Address NVARCHAR(500) NOT NULL     -- Address (required)
);


CREATE TABLE Sales (
    Id INT IDENTITY(1,1) PRIMARY KEY,          -- Auto-incrementing primary key
    DatePurchased DATETIME NOT NULL DEFAULT GETDATE(), -- Date of the sale with default value
    Quantity INT NOT NULL,                     -- Quantity of products sold
    TotalAmount DECIMAL(18, 2) NOT NULL,        -- Total price for the sale
    ProductId INT NOT NULL,                    -- Foreign key reference to Products
    -- Foreign key constraint
    CONSTRAINT FK_Sales_Products FOREIGN KEY (ProductId)
        REFERENCES Products(Id)
        ON DELETE CASCADE                      -- Deletes sales if the product is deleted
        ON UPDATE CASCADE                      -- Updates product references if Product Id changes
);
