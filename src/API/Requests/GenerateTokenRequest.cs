
namespace API.Requests;

public class GenerateTokenRequest
{
    public string Id { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public List<string> Permissions { get; set; } = [];

    public List<string> Roles { get; set; } = [];
}
