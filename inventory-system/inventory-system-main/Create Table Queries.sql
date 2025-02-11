CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    Category NVARCHAR(255) NOT NULL,
    IsDeleted BIT NOT NULL,
    DateAdded DATETIME2 NOT NULL DEFAULT GETDATE(), -- Added column
    DateExpired DATETIME2 NOT NULL
);

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,           -- Auto-incrementing primary key
    FirstName NVARCHAR(50) NOT NULL,             -- First name column with a maximum length of 50 characters
    LastName NVARCHAR(50) NOT NULL,              -- Last name column with a maximum length of 50 characters
    Email NVARCHAR(100) NOT NULL,                -- Email column with a maximum length of 100 characters
    PhoneNumber NVARCHAR(50) NOT NULL,           -- Phone number (required)
    Address NVARCHAR(500) NOT NULL,              -- Address (required)
    Password NVARCHAR(255) NOT NULL,             -- Password column with a maximum length of 255 characters (for hashed passwords)
    Role NVARCHAR(50) NOT NULL,                  -- Role column to store user roles (e.g., Admin, User, etc.)
    IsDeleted BIT NOT NULL DEFAULT 0,            -- Soft delete column (default to 0: not deleted)
    DateAdded DATETIME2 NOT NULL DEFAULT GETDATE() -- Date the employee was added (default to current date and time)
);

CREATE TABLE Sales (
    Id INT IDENTITY(1,1) PRIMARY KEY,          -- Auto-incrementing primary key
    DatePurchased DATETIME2 NOT NULL DEFAULT GETDATE(), -- Date of the sale with default value
    Quantity INT NOT NULL,                     -- Quantity of products sold
    TotalAmount DECIMAL(18, 2) NOT NULL,        -- Total price for the sale
    ProductId INT NOT NULL,                    -- Foreign key reference to Products
    -- Foreign key constraint
    CONSTRAINT FK_Sales_Products FOREIGN KEY (ProductId)
        REFERENCES Products(Id)
        ON DELETE CASCADE                      -- Deletes sales if the product is deleted
        ON UPDATE CASCADE                      -- Updates product references if Product Id changes
);
