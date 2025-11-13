using DotNetEnv;
using DotNetEnv.Extensions;

namespace API.Config;

public sealed class ConnectionStringReader
{
    private readonly Dictionary<string, string> _connectionStringParameters;

    public ConnectionStringReader()
    {
        _connectionStringParameters = Env.Load(PathHelper.GetEnvFilePath()).ToDotEnvDictionary();
    }
    public string GetConnectionString()
    {
        var connString = $"Server={_connectionStringParameters["DB_HOST"]};Database={_connectionStringParameters["DB_NAME"]};User Id={_connectionStringParameters["DB_USER"]};Password="
        + $"{_connectionStringParameters["DB_PASSWORD"]};Encrypt={_connectionStringParameters["DB_ENCRYPT"]};TrustServerCertificate={_connectionStringParameters["DB_TRUST_SERVER_CERTIFICATE"]};";

        return connString;
    }
}
