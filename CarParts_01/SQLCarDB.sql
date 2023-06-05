CREATE TABLE Cars (
    CarId INT IDENTITY PRIMARY KEY,
    Model VARCHAR(50) NOT NULL,
    Make DATETIME NOT NULL ,
    Color VARCHAR(50) NOT NULL,
    Price DECIMAL NOT NULL,
    Availabel BIT NOT NULL,
    Picture NVARCHAR(50)
    
)
GO

CREATE TABLE Car_Parts (
    PartId INT IDENTITY PRIMARY KEY,
    Engine_type VARCHAR(50) NOT NULL,
    Fuel_type VARCHAR(50) NOT NULL,
    Transmission VARCHAR(50),
    Number_of_doors INT,
    Exhaust_System VARCHAR(50),
   CarId INT NOT NULL  REFERENCES Cars(CarId)
    
)
GO