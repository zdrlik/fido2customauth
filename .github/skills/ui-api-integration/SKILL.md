# Skill: ui-api-integration

## Use when
- Running API + Blazor UI locally.
- Troubleshooting local connectivity between frontend and backend.
- Suggesting VS Code run/debug workflow.

## Local run options
### VS Code tasks
- `Run API`
- `Run UI`
- `Run Frontend + Backend` (parallel)

### VS Code launch profiles
- `API (.NET)`
- `UI (Blazor WASM)`
- Compound: `Frontend + Backend`

## Default local ports
- API: `https://localhost:7290`, `http://localhost:5126`
- UI: `https://localhost:7090`, `http://localhost:5034`

## Troubleshooting order
1. Start API and UI, verify both are listening.
2. Confirm UI backend base URL matches API URL.
3. Check browser auth flow and token acquisition.
4. Validate CORS and scope configuration.
