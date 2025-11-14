using DotNetEnv.Configuration;

namespace API.Config;

public sealed class JwtSettings
{
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public string Key { get; init; } = null!;
    public int ExpirationInMinutes { get; init; }

    private JwtSettings()
    {

    }

    public static JwtSettings FromConfiguration(IConfiguration config)
    {

        return new JwtSettings
        {
            Issuer = config["JWT_ISSUER"]
                ?? throw new InvalidOperationException("Missing JWT_ISSUER"),
            Audience = config["JWT_AUDIENCE"]
                ?? throw new InvalidOperationException("Missing JWT_AUDIENCE"),
            Key = config["JWT_KEY"]
                ?? throw new InvalidOperationException("Missing JWT_KEY"),

            ExpirationInMinutes = int.TryParse(config["JWT_TOKEN_EXPIRATION_IN_MINUTES"]!, out var value)
                ? value : throw new InvalidCastException("Missing JWT_TOKEN_EXPIRATION_IN_MINUTES"),

        };
    }


}
