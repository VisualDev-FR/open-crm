DELETE FROM Clients;

DBCC CHECKIDENT ('Clients', RESEED, 0);

INSERT INTO Clients (Nom, Email) VALUES ('Alice', 'alice@test.com');
INSERT INTO Clients (Nom, Email) VALUES ('Bob', 'bob@test.com');
