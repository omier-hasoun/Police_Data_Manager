
using System.Text.RegularExpressions;

namespace Domain.Officers;

public sealed record OfficerBadgeNumber
{
    public uint Value { get; }

    public OfficerBadgeNumber(uint value)
    {

        if (value == default)
        {
            throw new ArgumentException("the provided badge number cannot be 0");
        }

        this.Value = value;
    }

}
