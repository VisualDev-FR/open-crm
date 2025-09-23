DELETE FROM Contacts;

DBCC CHECKIDENT ('Contacts', RESEED, 0);

INSERT INTO Contacts (Nom, Email) VALUES ('Alice', 'alice@test.com');
INSERT INTO Contacts (Nom, Email) VALUES ('Bob', 'bob@test.com');
