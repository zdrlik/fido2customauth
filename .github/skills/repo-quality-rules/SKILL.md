# Skill: repo-quality-rules

## Use when
- Creating/modifying C# code, project files, or package references.
- Explaining why builds fail due to analyzers/style checks.

## Rules to enforce
1. Central package management is enabled:
   - Keep versions in `Directory.Packages.props`, not per-project `.csproj`.
2. Build quality settings are strict:
   - Nullable enabled.
   - Latest analysis level/mode.
   - Warnings treated as errors.
3. `.editorconfig` highlights:
   - Interface names must start with `I`.
   - Async methods must end with `Async`.
   - Nullable diagnostics are errors.

## Agent behavior
- Prefer minimal, targeted edits.
- Preserve existing architecture (API + Blazor WASM).
- Recommend running `dotnet build Fido2CustomAuth.slnx` after changes.
