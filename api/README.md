# API documentatie

## Users

GET /user/get  
Haalt een gebruiker op.  
Verwacht: id of code

POST /user/add  
Voegt een gebruiker toe.  
Verwacht: naam, email (optioneel)

POST /user/update  
Past een gebruiker aan.  
Verwacht: id + nieuwe gegevens

POST /user/delete  
Verwijdert een gebruiker.  
Verwacht: id


## Questions

GET /question/get  
Haalt een vraag op.  
Verwacht: id of locationId

POST /question/add  
Voegt een vraag toe.  
Verwacht: vraagtekst, locationId

POST /question/update  
Past een vraag aan.  
Verwacht: id + nieuwe gegevens

POST /question/delete  
Verwijdert een vraag.  
Verwacht: id


## Answers

GET /answer/get  
Haalt antwoorden op.  
Verwacht: id of questionId

POST /answer/add  
Voegt een antwoord toe.  
Verwacht: questionId, antwoordtekst, correct/incorrect

POST /answer/update  
Past een antwoord aan.  
Verwacht: id + nieuwe gegevens

POST /answer/delete  
Verwijdert een antwoord.  
Verwacht: id


## Score

GET /score/get  
Haalt score(s) op.  
Verwacht: code of id

POST /score/add  
Voegt een score toe.  
Verwacht: code, questionId, answerId

POST /score/update  
Past een score aan.  
Verwacht: id + nieuwe gegevens

POST /score/delete  
Verwijdert een score.  
Verwacht: id


## Locations

GET /location/get  
Haalt een locatie op.  
Verwacht: id

POST /location/add  
Voegt een locatie toe.  
Verwacht: naam

POST /location/update  
Past een locatie aan.  
Verwacht: id + nieuwe gegevens

POST /location/delete  
Verwijdert een locatie.  
Verwacht: id