using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fido2CustomAuth.Ui;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var backendApiUrl = builder.Configuration["BackendApi:BaseUrl"]
    ?? throw new InvalidOperationException("Missing BackendApi:BaseUrl configuration.");
var backendApiScope = builder.Configuration["BackendApi:Scope"]
    ?? throw new InvalidOperationException("Missing BackendApi:Scope configuration.");

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);

    var authority = options.ProviderOptions.Authentication.Authority;
    if (!string.IsNullOrWhiteSpace(authority) && !Uri.IsWellFormedUriString(authority, UriKind.Absolute))
    {
        options.ProviderOptions.Authentication.Authority =
            $"https://login.microsoftonline.com/{authority.Trim('/')}";
    }
});

builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthorizationMessageHandler>()
        .ConfigureHandler(
            authorizedUrls: [backendApiUrl],
            scopes: [backendApiScope]);

    return new HttpClient(handler)
    {
        BaseAddress = new Uri(backendApiUrl),
    };
});

await builder.Build().RunAsync().ConfigureAwait(false);
