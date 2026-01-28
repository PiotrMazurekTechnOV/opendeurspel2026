# API documentatie
ga naar de terminal en ga naar command promt
cd api
npm install
voor dev: npm run start
voor productie: npm run prod

Deze API verzorgt de communicatie tussen de applicaties (adminprogramma, vraagprogramma en printprogramma) en de database van het opendeurspel.  
De API ontvangt verzoeken om gebruikers, locaties, vragen, antwoorden en scores toe te voegen, aan te passen, op te vragen of te verwijderen,  
en stuurt deze correct door naar de database.


## Users

GET /user/get/id/:id  
Haalt een gebruiker op via id.  
Verwacht: id

GET /user/get/code/:code  
Haalt een gebruiker op via code.  
Verwacht: code

POST /user/add  
Voegt een gebruiker toe.  
Verwacht: naam, email (optioneel)

POST /user/update
Past een gebruiker aan.  
Verwacht: nieuwe gegevens

POST /user/delete
Verwijdert een gebruiker.  
Verwacht: id


## Questions

GET /question/get/id/:id  
Haalt een vraag op via id.  
Verwacht: id

GET /question/get/location/:locationId  
Haalt een vraag op via locatie.  
Verwacht: locationId

POST /question/add  
Voegt een vraag toe.  
Verwacht: vraagtekst, locationId

POST /question/update
Past een vraag aan.  
Verwacht: nieuwe gegevens

POST /question/delete
Verwijdert een vraag.  
Verwacht: id


## Answers

GET /answer/get/id/:id  
Haalt een antwoord op via id.  
Verwacht: id

GET /answer/get/question/:questionId  
Haalt antwoorden op via questionId.  
Verwacht: questionId

POST /answer/add  
Voegt een antwoord toe.  
Verwacht: questionId, antwoordtekst, correct/incorrect

POST /answer/update
Past een antwoord aan.  
Verwacht: nieuwe gegevens

POST /answer/delete
Verwijdert een antwoord.  
Verwacht: id


## Score

GET /score/get/id/:id  
Haalt een score op via id.  
Verwacht: id

GET /score/get/code/:code  
Haalt score(s) op via code.  
Verwacht: code

POST /score/add  
Voegt een score toe.  
Verwacht: code, questionId, answerId

POST /score/update
Past een score aan.  
Verwacht: nieuwe gegevens

POST /score/delete
Verwijdert een score.  
Verwacht: id


## Locations

GET /location/get/id/:id  
Haalt een locatie op via id.  
Verwacht: id

POST /location/add  
Voegt een locatie toe.  
Verwacht: naam

POST /location/update
Past een locatie aan.  
Verwacht: nieuwe gegevens

POST /location/delete
Verwijdert een locatie.  
Verwacht: id