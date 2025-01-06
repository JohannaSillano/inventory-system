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
    FullName NVARCHAR(100) NOT NULL,   -- FullName column with a maximum length of 100 characters
    Email NVARCHAR(100) NOT NULL,      -- Email column with a maximum length of 100 characters
    Password NVARCHAR(255) NOT NULL    -- Password column with a maximum length of 255 characters (for hashed passwords)
);

CREATE TABLE UserProfiles (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing primary key
    FullName NVARCHAR(255) NOT NULL, -- Required
    Email NVARCHAR(255) NOT NULL, -- Required
    PhoneNumber NVARCHAR(50) NOT NULL, -- Required
    Address NVARCHAR(500) NOT NULL -- Required
);


