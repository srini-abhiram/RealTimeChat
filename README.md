To use the API, the connection string to postgres database is to be set as a secret as mentioned below (in development):

dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:PostgreSQL" "Host=...;Port=...;Username=...;Password=..."

On production servers / CI/CD (e.g., GitHub Actions):
Set environment variables in your deployment environment:

ConnectionStrings__PostgreSQL="Host=...;Port=...;Database=...;Username=...;Password=..."

Note: 
: becomes __ (double underscores) in environment variable keys.
