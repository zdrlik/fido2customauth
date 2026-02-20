# Copilot Instructions for `fido2customauth`

## Build, test, and lint commands

- Restore solution:
  - `dotnet restore Fido2CustomAuth.slnx`
- Build solution (analyzers and style rules run here and are treated as errors):
  - `dotnet build Fido2CustomAuth.slnx`
- Run all tests:
  - `dotnet test Fido2CustomAuth.slnx`
- Run a single test (when test projects exist):
  - `dotnet test <path-to-test-project.csproj> --filter "FullyQualifiedName~<TestName>"`

There is currently no separate lint command; linting is enforced by Roslyn analyzers and style rules during `dotnet build`.

## High-level architecture

- The solution is a two-project .NET 10 setup:
  - `src/Fido2CustomAuth.Api` - ASP.NET Core minimal API backend.
  - `src/Fido2CustomAuth.Ui` - Blazor WebAssembly frontend used as a test UI.
- Authentication flow:
  - API uses `AddMicrosoftIdentityWebApi` (JWT bearer) and protects `/weatherforecast` with `.RequireAuthorization()`.
  - API also enforces delegated scope checks via `VerifyUserHasAnyAcceptedScope` using `AzureAd:Scopes`.
  - UI uses MSAL (`AddMsalAuthentication`) and an `AuthorizationMessageHandler`-backed `HttpClient` to call the API with an access token.
- Local development wiring:
  - API CORS policy allows UI origins `https://localhost:7090` and `http://localhost:5034`.
  - API launch profile runs on `https://localhost:7290` / `http://localhost:5126`.
  - UI launch profile runs on `https://localhost:7090` / `http://localhost:5034`.

## Key conventions in this repo

- Central package management is enabled (`Directory.Packages.props`); keep package versions there, not in individual `.csproj` files.
- Repo-wide build quality settings are in `Directory.Build.props`:
  - nullable enabled, latest analysis level/mode, warnings treated as errors.
  - analyzer packages (`Meziantou`, `SonarAnalyzer.CSharp`, `Roslynator`, `xunit.analyzers`) are applied solution-wide.
- `.editorconfig` is strict for C#:
  - nullable diagnostics configured as errors.
  - interface names must start with `I`.
  - async methods must end with `Async`.
- Configuration conventions:
  - API settings are in `src/Fido2CustomAuth.Api/appsettings*.json` under `AzureAd`.
  - Blazor WASM settings are in `src/Fido2CustomAuth.Ui/wwwroot/appsettings*.json` under `AzureAd` and `BackendApi`.
  - UI startup throws immediately if `BackendApi:BaseUrl` or `BackendApi:Scope` is missing.

## Agent Skills (load by task)

Use these repository-local skill files as task playbooks:

1. Build/test workflows:
  - `.github/skills/dotnet-build-test/SKILL.md`
2. Entra auth and scope/config troubleshooting:
  - `.github/skills/entra-auth-config/SKILL.md`
3. UI + API local execution and integration:
  - `.github/skills/ui-api-integration/SKILL.md`
4. Quality/analyzer/style/package governance:
  - `.github/skills/repo-quality-rules/SKILL.md`

### Skill loading policy
- Load only the skill(s) relevant to the user request.
- For auth/config/token issues, always load `entra-auth-config`.
- For command/run/debug requests, always load `dotnet-build-test` and `ui-api-integration`.
- For code changes, always load `repo-quality-rules` before proposing edits.
