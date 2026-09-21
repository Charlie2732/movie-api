# Movie App

En filmapp jag byggt. React på frontend och ASP.NET på backend.

Man kan lägga till filmer, redigera titeln, ta bort filmer och ladda upp en bild till varje film. Om något går fel med API:et visas ett felmeddelande i appen istället för att den kraschar. Appen funkar både på mobil och dator.

Filmerna sparas i en SQLite-databas som skapas automatiskt första gången man kör API:et.

## Så startar du det

Du behöver .NET SDK 10 och Node.js installerat.

Backend: gå in i movie-api mappen och kör dotnet run. Den kör då på http://localhost:5215.

Frontend: gå in i movie-app mappen, kör npm install och sen npm run dev. Öppna länken som dyker upp i terminalen, oftast http://localhost:5173.

Både backend och frontend måste köra samtidigt för att appen ska fungera.