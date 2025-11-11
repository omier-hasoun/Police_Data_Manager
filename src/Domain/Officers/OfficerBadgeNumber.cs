
using System.Text.RegularExpressions;

namespace Domain.Officers;

public sealed record OfficerBadgeNumber
{
    public static Regex badgeNumberPattern = new(@"^[A-Z]{3}-\d{6}$");// pattern is StateCode-sequentialNumber e.g. NYC-123456
    public string Value { get; set; } = string.Empty;

    public OfficerBadgeNumber(string value)
    {

        if (value is null || !badgeNumberPattern.IsMatch(value))
        {
            throw new ArgumentException("Badge number format is invalid. Expected format is AAA-123456.", nameof(value));
        }

        this.Value = value;

    }

}
