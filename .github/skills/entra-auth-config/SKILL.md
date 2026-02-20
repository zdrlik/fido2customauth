# Skill: entra-auth-config

## Use when
- Working on authentication/authorization in API or UI.
- Debugging token/scope issues.
- Updating appsettings for Entra ID.

## Key repo facts
- API project: `src/Fido2CustomAuth.Api`
- UI project: `src/Fido2CustomAuth.Ui`
- API auth: JWT bearer via Microsoft Identity Web.
- Protected endpoint pattern includes delegated scope checks.
- UI auth: MSAL + token-attaching HttpClient handler.

## Config locations
- API: `src/Fido2CustomAuth.Api/appsettings.json` (`AzureAd`)
- UI: `src/Fido2CustomAuth.Ui/wwwroot/appsettings.json` (`AzureAd`, `BackendApi`)
- Expected UI scope format:
  - `api://<API_APP_CLIENT_ID>/access_as_user`

## Validation checklist
1. Tenant/client IDs are consistent between API exposure and UI scope.
2. UI `BackendApi:BaseUrl` and `BackendApi:Scope` are present.
3. API accepted scopes include the delegated scope used by UI.
4. CORS origins match local UI launch URLs.
