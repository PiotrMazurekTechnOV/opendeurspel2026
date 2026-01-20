# DATABASE documentatie 

Deze query voegt een nieuwe gebruiker toe aan de users-tabel met de naam van de vocht, de naam van het kind, het e-mailadres en de code. De id en createdAt worden automatisch door de database ingevuld.

user toevoegen:
INSERT INTO users (nameGuardian, nameChild, email, code)
VALUES
('Mohamed', 'Kai', 'mohames@alibaba.com', 67);


locatie toevoegen:
INSERT INTO locations (nummer, naamLokaal)
VALUES
(112, 'ICT');
