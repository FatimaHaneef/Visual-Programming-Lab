-- Drop the old table
DROP TABLE CustomerTable;

-- Rename the new table to the original name
EXEC sp_rename 'CustomerTable_New', 'CustomerTable';


DROP TABLE IF EXISTS CustomerTable;

CREATE TABLE CustomerTable (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(50),
    Country NVARCHAR(50),
    Gender NVARCHAR(10),
    Hobbies NVARCHAR(50),
    Status NVARCHAR(20)
);
select * from CustomerTable;