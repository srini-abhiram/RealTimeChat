To use the API, the connection string to postgres database is to be set as a secret as mentioned below:

dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:PostgreSQL" "Host=...;Port=...;Username=...;Password=..."
