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

GET npm

GET /user/get/code/:code  
Haalt een gebruiker op via code.  
Verwacht: code

GET /user/get/all
toont alles uit user(s).

POST /user/add  
Voegt een gebruiker toe.  
Verwacht: naam, email (optioneel)

POST /user/update/id
Past een gebruiker aan met id 
Verwacht: nieuwe gegevens

POST /user/delete
Verwijdert een gebruiker.  
Verwacht: id


## Questions

POST /question/add  
Voegt een vraag toe.  
Verwacht: vraagtekst, locationId

POST /question/update/:id
Past een vraag aan.  
Verwacht: nieuwe gegevens

POST /question/delete/:id
Verwijdert een vraag.  
Verwacht: id

GET /question/get/:id
haal op uit queston met id
vewacht: id

GET /question/get/all
haalt alles op uit questions

## Answers

GET /answer/get/id/:id  
Haalt een antwoord op via id.  
Verwacht: id

GET /answer/get/question/:questionId  
Haalt antwoorden op via questionId.  
Verwacht: questionId

GET /answer/get/correct/:question_id
het juiste antwoord opvragen.

POST /answer/add  
Voegt een antwoord toe.  
Verwacht: questionId, antwoordtekst, correct/incorrect

POST /answer/update:id
Past een antwoord aan.  
Verwacht: nieuwe gegevens

POST /answer/delete/:id
Verwijdert een antwoord.  
Verwacht: id

GET /answer/get/all
haalt alles uit answer op.
## Locations

GET /locations/add
Voegt een locatie toe.  
Verwacht: number, naam

POST /location/update/:number
Past een locatie aan.  
Verwacht: nieuwe gegevens , number

GET /location/get/:id  
Haalt een locatie op via id.  
Verwacht: id

GET /question/get/location/:location_number
location opvragen aan de hand van id
verwacht: location_number

GET /location/delete/:id
Verwijdert een locatie.  
vewacht: id 

GET /location/get/all
haalt alles uit locatiosn(s) op.

## Score

POST /score/add  
Voegt een score toe.  
Verwacht: user_id, question_id, correct

POST /score/update/:location_number
Past een score aan.  
Verwacht: nieuwe gegevens

GET /score/get/:id  
Haalt een score op via id.  
Verwacht: id

POST /score/delete/:id
Verwijdert een score.  
Verwacht: id

GET /score/get/all
haalt alles uit scaore(s) op.