## MIGRATIONS STEPS

cd BudgetApp.Infrastructure

dotnet ef --startup-project ../BudgetApp.API/ migrations add "InitialMigration" -o ./Persistence/Migrations

## Run migrations

cd BudgetApp.API

dotnet ef database update