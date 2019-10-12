INSERT INTO Location (BranchName, Street, City, State, Zipcode) VALUES 
('Flagship', '123 Main', 'Arlington', 'TX', '76010'),
('Branch1', '1 Branch St', 'Dallas', 'TX', '76110'),
('Branch2', '2 Branch St', 'Austin', 'TX', '76111');

INSERT INTO Product (Name, Price) VALUES
('Soy Sauce', 10),
('Vinegar', 15),
('Cabbage', 5),
('Onions', 7)

Select * from Product
Select * from Location

INSERT INTO Inventory (ProductID, Stock, LocationID) VALUES
(1000, 20, 1000),
(1001, 20, 1000),
(1002, 20, 1000),
(1003, 20, 1000),
(1000, 20, 1001),
(1001, 20, 1001),
(1002, 20, 1001),
(1003, 20, 1001),
(1000, 20, 1002),
(1001, 20, 1002),
(1002, 20, 1002),
(1003, 20, 1002)

SELECT * FROM Inventory
