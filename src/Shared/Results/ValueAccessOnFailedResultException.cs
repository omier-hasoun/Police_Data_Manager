using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Results;

public sealed class ValueAccessOnFailedResultException : Exception
{
    public ValueAccessOnFailedResultException
     (): base("you have tried to access a value of a failed Result, pls ensure to handle it")
    {
        
    }
}
