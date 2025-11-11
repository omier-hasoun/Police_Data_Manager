using System;

namespace Shared.Results;

public interface IResult
{
    bool IsSuccess { get; }
    bool IsFailure { get; }

}

public interface IResult<out TValue>
{
    List<Error>? Errors { get; }
    TValue Value { get; }

}

