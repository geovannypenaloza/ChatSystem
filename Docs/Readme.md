comandos para hacer migracion
Abres la terminal en Rider.

Escribes: 
dotnet ef migrations add "commits" 
(esto crea el plano de la base de datos).

Escribes: 
dotnet ef database update 
(esto construye las tablas físicamente).

Si sale mal
dotnet ef migrations remove