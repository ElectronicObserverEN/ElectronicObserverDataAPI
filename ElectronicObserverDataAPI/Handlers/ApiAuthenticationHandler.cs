using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace ElectronicObserverDataAPI.Handlers;

public class ApiAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private string SecretLocation => Path.Combine(Environment.CurrentDirectory, "config.json");

    private string? Secret { get; set; }

    public ApiAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("No authorization header was provided");
        }

        // get the secret 
        if (string.IsNullOrEmpty(Secret))
        {
            if (!File.Exists(SecretLocation)) return AuthenticateResult.Fail("Secret doesn't exist");

            await using FileStream stream = File.OpenRead(SecretLocation);
            Dictionary<string, string>? config = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream);

            if (config is null) return AuthenticateResult.Fail("Secret doesn't exist");
            if (!config.ContainsKey("secret")) return AuthenticateResult.Fail("Secret doesn't exist");

            Secret = config["secret"];
        }
        
        if (string.IsNullOrEmpty(Secret))
        {
            return AuthenticateResult.Fail("Secret doesn't exist");
        }
        
        string credentials = Request.Headers["Authorization"].ToString();

        if (credentials == Secret)
        {
            Claim[] claims = { new(ClaimTypes.Role, "Admin") };
            ClaimsIdentity identity = new(claims, Scheme.Name);
            ClaimsPrincipal principal = new(identity);
            AuthenticationTicket ticket = new(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        return AuthenticateResult.Fail("Authentication denied");
    }
}