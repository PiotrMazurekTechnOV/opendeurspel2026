# API documentatie

## Users

GET /user/get/:id
Haalt een gebruiker op.  
Verwacht: id of code

POST /user/add  
Voegt een gebruiker toe.  
Verwacht: naam, email (optioneel)

POST /user/update  
Past een gebruiker aan.  
Verwacht: id + nieuwe gegevens

GET /user/delete/:id
Verwijdert een gebruiker.  
Verwacht: id


## Questions

GET /question/get/:id
Haalt een vraag op.  
Verwacht: id of locationId

POST /question/add  
Voegt een vraag toe.  
Verwacht: vraagtekst, locationId

POST /question/update  
Past een vraag aan.  
Verwacht: id + nieuwe gegevens

GET /question/delete/:id
Verwijdert een vraag.  
Verwacht: id


## Answers

GET /answer/get/:id
Haalt antwoorden op.  
Verwacht: id of questionId

POST /answer/add  
Voegt een antwoord toe.  
Verwacht: questionId, antwoordtekst, correct/incorrect

POST /answer/update  
Past een antwoord aan.  
Verwacht: id + nieuwe gegevens

GET /answer/delete/:id
Verwijdert een antwoord.  
Verwacht: id


## Score

GET /score/get/:id
Haalt score(s) op.  
Verwacht: code of id

POST /score/add  
Voegt een score toe.  
Verwacht: code, questionId, answerId

POST /score/update  
Past een score aan.  
Verwacht: id + nieuwe gegevens

GET /score/delete/:id
Verwijdert een score.  
Verwacht: id


## Locations

GET /location/get/:id
Haalt een locatie op.  
Verwacht: id

POST /location/add  
Voegt een locatie toe.  
Verwacht: naam

POST /location/update  
Past een locatie aan.  
Verwacht: id + nieuwe gegevens

GET /location/delete/:id
Verwijdert een locatie.  
Verwacht: id