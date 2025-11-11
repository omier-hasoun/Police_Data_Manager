using System;

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Shared.Results;
public static class Result
{
    public static Success Success => default;
    public static Created Created => default;
    public static Updated Updated => default;
    public static Deleted Deleted => default;
}

public readonly struct Success {};
public readonly struct Created {};
public readonly struct Updated {};
public readonly struct Deleted {};

public readonly record struct Result<TValue> : IResult<TValue>
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = [];
    public bool IsSuccess {get;}
    public bool IsFailure => !IsSuccess;
    public List<Error> Errors => _errors!;
    public Error TopError => (_errors?.Count > 0) ? Errors[0] : default;

    public TValue Value
    {
        get
        {
            if (IsFailure)
            {
                throw new ValueAccessOnFailedResultException();
            }

            return _value!;
        }
    }

    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("")]
    public Result(TValue value, List<Error> errors, bool isSuccess)
    {
        IsSuccess = isSuccess;
        _errors = errors;
        _value = value;

    }

    private Result(List<Error> errors)
    {
        if (errors is null || errors.Count == 0)
        {
            throw new ArgumentNullException("errors list is empty");
        }
        IsSuccess = false;
        _errors = errors!;
    }

    private Result(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        _value = value;
        IsSuccess = true;
    }

    public static implicit operator Result<TValue>(TValue value)
        => new(value: value);

    public static implicit operator Result<TValue>(Error error)
        => new(errors: [error]);

    public static implicit operator Result<TValue>(List<Error> errors)
        => new(errors: errors);
    public TNextValue Match<TNextValue>(Func<TValue, TNextValue> OnSuccess, Func<List<Error>, TNextValue> OnError)
        => IsSuccess ? OnSuccess(Value!) : OnError(Errors);
}
