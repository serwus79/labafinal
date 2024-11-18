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

## Zasoby

- https://github.com/Azure-Samples/todo-csharp-cosmos-sql (hłehłe)
- https://learn.microsoft.com/en-us/dotnet/aspire/
- https://github.com/dotnet/aspire-samples/tree/main
- https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/
- generowanie bicep https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-azd-in-depth?tabs=macos#generate-bicep-from-net-aspire-project-model

## Kroki

### Przygotowanie

- instalacja `aspire` https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/setup-tooling?tabs=linux&pivots=dotnet-cli#install-net-aspire
- instalacja `azd` https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/install-azd?tabs=winget-windows%2Cbrew-mac%2Cscript-linux&pivots=os-mac

#### Instalacja aspire

Wykonaj komendy:

```bash
dotnet workload update
dotnet workload install aspire
```

(źródło: https://learn.microsoft.com/en-us/training/modules/introduction-dotnet-aspire/5-exercise-use-eshop)

### Aplikacja

Utworzenie aplikacji

```bash
dotnet new aspire-starter --use-redis-cache --output LabaToDo`
```

_// TODO: kodowanie aplikacji_

### Publikacja

Publikacja za pomocą `azd`: https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment

1. Przejdź do folderu `AppHost`
2. Inicjalizacja `azd init`

```
➜  LabaToDo.AppHost git:(final_aspire) azd init

Initializing an app to run on Azure (azd init)

? How do you want to initialize your app? Use code in the current directory

  (✓) Done: Scanning app code in current directory

Detected services:

  .NET (Aspire)
  Detected in: /Users/krzysztofchomicz/projects/laba/labahomeworks/99_final_project/LabaToDo/LabaToDo.AppHost/LabaToDo.AppHost.csproj

azd will generate the files necessary to host your app on Azure using Azure Container Apps.

? Select an option Confirm and continue initializing my app
? Enter a new environment name:
environment name '' is invalid (it should contain only alphanumeric characters and hyphens)

? Enter a new environment name: dev

Generating files to run your app on Azure:

  (✓) Done: Generating ./azure.yaml
  (✓) Done: Generating ./next-steps.md

SUCCESS: Your app is ready for the cloud!
You can provision and deploy your app to Azure by running the azd up command in this directory. For more   information on configuring your app, see ./next-steps.md
```

3. Publikacja `azd up` (opcjonalnie przed pierwszym uruchomieniem `azd auth login`)

```
➜  LabaToDo.AppHost git:(final_aspire) ✗ azd auth login
Logged in to Azure.
➜  LabaToDo.AppHost git:(final_aspire) ✗ azd up
(✓) Done: Downloading Bicep
? Select an Azure Subscription to use:  1. Azure subscription 1 (cb817725-db40-42f3-9d78-928f943bc34e)
? Select an Azure location to use: 29. (Europe) Poland Central (polandcentral)

Packaging services (azd package)


Provisioning Azure resources (azd provision)
Provisioning Azure resources can take some time.

Subscription: Azure subscription 1 (cb817725-db40-42f3-9d78-928f943bc34e)
Location: Poland Central

You can view detailed progress in the Azure Portal:
https://portal.azure.com/#view/HubsExtension/DeploymentDetailsBlade/~/overview/id/%2Fsubscriptions%2Fcb817725-db40-42f3-9d78-928f943bc34e%2Fproviders%2FMicrosoft.Resources%2Fdeployments%2Fdev-1730750734

(✓) Done: Resource group: rg-dev (1.809s)
(✓) Done: Log Analytics workspace: law-lxvvujgox527k (30.318s)
(✓) Done: Container Registry: acrlxvvujgox527k (42.715s)
(✓) Done: Container Apps Environment: cae-lxvvujgox527k (2m3.033s)

Deploying services (azd deploy)

(✓) Done: Deploying service apiservice
- Endpoint: https://apiservice.internal.blackmoss-af5cb88e.polandcentral.azurecontainerapps.io/

(✓) Done: Deploying service cache
- Endpoint: https://cache.internal.blackmoss-af5cb88e.polandcentral.azurecontainerapps.io/

(✓) Done: Deploying service webfrontend
- Endpoint: https://webfrontend.blackmoss-af5cb88e.polandcentral.azurecontainerapps.io/

Aspire Dashboard: https://aspire-dashboard.ext.blackmoss-af5cb88e.polandcentral.azurecontainerapps.io

SUCCESS: Your up workflow to provision and deploy to Azure completed in 5 minutes 47 seconds.
```
