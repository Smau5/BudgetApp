## GENERATING NEW MIGRATION FILE

cd BudgetApp.Infrastructure

dotnet ef --startup-project ../BudgetApp.API/ migrations add "MigrationName" -o ./Persistence/Migrations

## Run migrations

cd BudgetApp.API

dotnet ef database update