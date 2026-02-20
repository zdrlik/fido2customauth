# fido2customauth

Basic .NET 10 solution scaffolded for:
- Backend API (`src/Fido2CustomAuth.Api`)
- Blazor WebAssembly test UI (`src/Fido2CustomAuth.Ui`)
- Entra ID authentication for both API and UI

## Solution layout

- `Fido2CustomAuth.slnx` - solution file
- `Directory.Build.props` - shared build/code-quality settings
- `Directory.Packages.props` - central package version management
- `.editorconfig` - shared coding standards

## Entra ID placeholders

The scaffold uses placeholder IDs from the templates. Replace these before real usage:
- API: `src/Fido2CustomAuth.Api/appsettings.json` (`AzureAd` section)
- UI: `src/Fido2CustomAuth.Ui/wwwroot/appsettings.json` (`AzureAd` and `BackendApi` sections)

Expected scope format in UI:
- `api://<API_APP_CLIENT_ID>/access_as_user`

## Run locally

1. Start API:
   - `dotnet run --project src\\Fido2CustomAuth.Api`
2. Start UI:
   - `dotnet run --project src\\Fido2CustomAuth.Ui`
3. Open the UI URL from console output and test the `Weather` page (calls authenticated API endpoint).
