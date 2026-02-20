# Skill: dotnet-build-test

## Use when
- Building, restoring, testing, or troubleshooting CI/local build failures.
- Verifying commands for this repository.

## Repository commands
- Restore:
  - `dotnet restore Fido2CustomAuth.slnx`
- Build (includes analyzers/style checks, warnings treated as errors):
  - `dotnet build Fido2CustomAuth.slnx`
- Test all:
  - `dotnet test Fido2CustomAuth.slnx`
- Test one:
  - `dotnet test <path-to-test-project.csproj> --filter "FullyQualifiedName~<TestName>"`

## Execution policy
1. Prefer solution-level commands unless user asks for a single project.
2. Treat build warnings as blockers (repo enforces strict quality).
3. Keep responses concise and command-first.
4. If suggesting fixes, ensure they align with `.editorconfig` and analyzer expectations.
