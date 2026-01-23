# DATABASE documentatie 

Deze query voegt een nieuwe gebruiker toe aan de users-tabel met de naam van de voogt, de naam van het kind, het e-mailadres en de code. De id en createdAt worden automatisch door de database ingevuld.

## User queries
user toevoegen:
INSERT INTO users (nameGuardian, nameChild, email, code)
VALUES
('Mohamed', 'Kai', 'mohames@alibaba.com', 67);

user verwijderen:
DELETE FROM users
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
INSERT INTO questions (question, locations_id)
VALUES
('Is 6ICT de beste?');

question verwijderen:
DELETE FROM questions
WHERE id=1;

question updaten:
DELETE FROM questions
WHERE id=1;


## Answers queries

answers toevoegen:
INSERT INTO answers(answers)
VALUES
('Ja');

answers updaten:
UPDATE answers
SET answers = 'nee'
WHERE id = 1;

answers verwijderen:
DELETE FROM answers
WHERE id= 1;


## Scores queries
### scores toevoegen:
INSERT INTO opendeurspel.scores (user_id,question_id,status)
VALUES (1,1,0);

### score updaten:
UPDATE opendeurspel.scores 
SET status = 1 WHERE id = 1;

### score verwijderen:
DELETE FROM opendeurspel.scores 
WHERE id = 1;