# labafinal

Projekt końcowy laba

# Projekt końcowy

Termin: 19.11 23:59

## Projekt:

Budowa i wdrożenie aplikacji chmurowej na Azure

## Opis

Celem projektu jest stworzenie i wdrożenie aplikacji webowej na platformie Azure, która wykorzystuje różne usługi chmurowe. Projekt obejmuje zarówno część deweloperską, jak i administracyjną, umożliwiając pracę z rzeczywistymi narzędziami i scenariuszami.

## Wymagania projektu

1. Backend:  
   Stworzenie API w języku C#, Node.js lub Pythonie (do wyboru przez kursanta) i wdrożenie go jako Azure App Service.
   Użycie Azure Functions do obsługi operacji bezserwerowych (serverless).
2. Frontend:  
   Prosta aplikacja frontendowa (np. React, Angular lub Blazor) wdrożona jako Static Web App w Azure.
3. Baza Danych:  
   Użycie Azure SQL Database, Cosmos DB lub innej odpowiedniej usługi bazy danych.
4. Zarządzanie Uwierzytelnianiem:  
   Implementacja uwierzytelniania za pomocą Azure Active Directory B2C lub innej usługi autoryzacyjnej.
5. Bezpieczeństwo:  
   Skonfigurowanie zasad bezpieczeństwa (np. zarządzanie kluczami w Azure Key Vault).
6. Zarządzanie Przechowywaniem Danych:  
   Przechowywanie plików użytkowników w Azure Blob Storage.
7. Monitoring i Logging:  
   Skonfigurowanie monitoringu aplikacji przy użyciu Azure Application Insights i Log Analytics.

## Dodatkowe wymagania:

8. CI/CD:
   Skonfigurowanie procesu Continuous Integration/Continuous Deployment z wykorzystaniem Azure DevOps lub GitHub Actions.
9. Automatyzacja:
   Użycie ARM Templates, Bicep lub Terraform do automatycznego wdrażania infrastruktury.

## Zasoby (to del)

- https://github.com/Azure-Samples/todo-csharp-cosmos-sql (hłehłe)
- https://learn.microsoft.com/en-us/dotnet/aspire/
- https://github.com/dotnet/aspire-samples/tree/main
- https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/
- generowanie bicep https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-azd-in-depth?tabs=macos#generate-bicep-from-net-aspire-project-model

## Zasoby

- instalacja azure CLI https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=azure-cli

## Uruchomienie

### Ręczny deploy

```
az deployment sub create --name laba-final --template-file .\infra\main.bicep --location westeurope
```

api:

```
dotnet publish src/api/Laba.Todo.csproj -c Release -o ./publish
```

spakowanie api

```
cd publish
# bash
zip -r ../publish.zip
# pwsh
Compress-Archive -Path * -DestinationPath ..\publish.zip
```

```
cd publish
zip -r ../publish.zip
Compress-Archive -Path * -DestinationPath ..\publish.zip
az webapp deploy --name labafinal-api --resource-group labafinal-rg --src-path ./publish
```

web:

instalacja Azure Static Web Apps CLI (SWA)

https://learn.microsoft.com/en-us/azure/static-web-apps/deploy-web-framework?source=recommendations&tabs=bash&pivots=vanilla-js#configure-for-deployment

```
cd src/web
npm install
npm run build
npm install -D @azure/static-web-apps-cli
npx swa build
npx swa deploy --env production
```

### Github Actions

Aplikacja jest wdrażana za pomocą Github Actions.

#### Konfiguracja Sekretów GitHub

Dodaj następujące sekrety w repozytorium GitHub:

- `AZURE_CREDENTIALS`: JSON z danymi logowania do Azure (utworzony za pomocą `az ad sp create-for-rbac`).
