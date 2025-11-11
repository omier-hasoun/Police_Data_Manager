
using System.Text.RegularExpressions;

namespace Domain.Citizens;

public record CitizenNationalId
{
    private string _id = string.Empty;

    public string Value => _id!;

    public CitizenNationalId(string id)
    {
        _id = id;
    }

}
