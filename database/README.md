# DATABASE documentatie 

Deze query voegt een nieuwe gebruiker toe aan de users-tabel met de naam van de vocht, de naam van het kind, het e-mailadres en de code. De id en createdAt worden automatisch door de database ingevuld.

## User queries
user toevoegen:
INSERT INTO users (nameGuardian, nameChild, email, code)
VALUES
('Mohamed', 'Kai', 'mohames@alibaba.com', 67);

user verwijderen:
DELETE FROM opendeurdag.users
WHERE email='m%';

user updaten:
UPDATE users 
SET nameGuardian = 'Kai', nameChild = 'Mohamed', email = 'Kai@Verret.com', code = 76
WHERE id = 1;

## Locatie query

Deze query voegt een nieuwe klaslocatie toe aan de database door het lokaalnummer en de naam van het lokaal op te slaan in de tabel.
locatie toevoegen:
INSERT INTO locations (nummer, naamLokaal)
VALUES
(112, 'ICT');

locatie update:
UPDATE locations
SET nummer ='103', naamLokaal = 'Industriële Automatisering lokaal'
WHERE id = 1;

locatie verwijderen:
DELETE FROM users
WHERE id=1;


## Questions queries

question toevoegen:
INSERT INTO  (question, locations_id)
VALUES
('Is 6ICT de beste?', 2);



## Answers queries








## Scores queries
scores toevoegen:
INSERT INTO scores (user_id,question_id,status)
VALUES (1,1,0);

score updaten:
UPDATE scores 
SET status = 1 WHERE user_id = 1;

score verwijderen:
DELETE FROM scores 
WHERE user_id = 1;