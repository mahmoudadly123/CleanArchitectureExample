using CleanArchitecture.Common.Errors.Abstract;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Common.Results;

public class Result
{
    #region Properites

    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public bool HasErrors=>Errors.Any();
    
    public IList<Error> Errors { get; private set; }

    public IList<ProblemDetails> ProblemDetails
    {
        get
        {
            return Errors.Select(error => new ProblemDetails()
            {
                Title = error.Code,
                Detail = error.Message
            }).ToList();

        }
    }

    #endregion

    #region Constructors

    protected internal Result(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;

        Errors = isSuccess
            ? new List<Error>()
            : (IList<Error>)new List<Error>()
            {
                new Error(errorMessage)
            };

    }
    protected internal Result(bool isSuccess, string errorCode,string errorMessage)
    {
        IsSuccess = isSuccess;

        Errors = isSuccess
            ? new List<Error>()
            : (IList<Error>)new List<Error>()
            {
                new Error(errorCode,errorMessage)
            };
    }
    protected internal Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;

        Errors = isSuccess
            ? new List<Error>()
            : (IList<Error>)new List<Error>()
            {
                error
            };

    }

    protected internal Result(bool isSuccess, Exception exception)
    {
        IsSuccess = isSuccess;

        if (isSuccess)
        {
            Errors = new List<Error>();

        }
        else
        {
            Errors = new List<Error>
            {
                new Error(exception.Message)
            };
        }
        
    }

    protected internal Result(bool isSuccess, IList<Error> errors)
    {
        IsSuccess = isSuccess;

        Errors = isSuccess ? new List<Error>() : errors;
    }

    protected internal Result(bool isSuccess, IList<ValidationFailure> validationFailures)
    {
        IsSuccess = isSuccess;

        Errors = isSuccess ? new List<Error>() : validationFailures.Select(s => new Error(s.ErrorCode, s.ErrorMessage)).ToList();
    }

    #endregion

    #region Factory Methods

    public static Result Success()
    {
        return new(true, Error.None);
    }
    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new(value, true, Error.None);
    }

    public static Result Failure(string errorMessage)
    {
        return new(false, new Error(errorMessage));
    }
    public static Result Failure(string errorCode,string errorMessage)
    {
        return new(false, new Error(errorCode,errorMessage));
    }
    public static Result Failure(Error error)
    {
        return new(false, error);
    }
    public static Result Failure(Exception exception)
    {
        return new(false, exception);
    }
    public static Result Failure(IList<Error> errors)
    {
        return new(false, errors);
    }
    public static Result Failure(IList<ValidationFailure> validationFailures)
    {
        return new(false, validationFailures);
    }
    public static Result Failure(List<ValidationFailure> validationFailures)
    {
        return new(false, validationFailures);
    }
    
    
    
    public static Result<TValue> Failure<TValue>(string errorMessage)
    {
        return new(false, errorMessage);
    }
    public static Result<TValue> Failure<TValue>(string errorCode, string errorMessage)
    {
        return new(false, errorCode, errorMessage);
    }
    public static Result<TValue> Failure<TValue>(Error error)
    {
        return new(false, error);
    }
    public static Result<TValue> Failure<TValue>(Exception exception)
    {
        return new(false, exception);
    }
    public static Result<TValue> Failure<TValue>(IList<Error> errors)
    {
        return new(false, errors);
    }
    public static Result<TValue> Failure<TValue>(IList<ValidationFailure> validationFailures)
    {
        return new(false, validationFailures);
    }
    public static Result<TValue> Failure<TValue>(List<ValidationFailure> validationFailures)
    {
        return new(false, validationFailures);
    }


    public static Result<TValue> Failure<TValue>(TValue? value, string errorMessage)
    {
        return new(value, false, errorMessage);
    }
    public static Result<TValue> Failure<TValue>(TValue? value, string errorCode,string errorMessage)
    {
        return new(value, false, errorCode,errorMessage);
    }
    public static Result<TValue> Failure<TValue>(TValue? value, Error error)
    {
        return new(value, false, error);
    }
    public static Result<TValue> Failure<TValue>(TValue? value, Exception exception)
    {
        return new(value, false, exception);
    }
    public static Result<TValue> Failure<TValue>(TValue? value, IList<Error> errors)
    {
        return new(value, false, errors);
    }
    public static Result<TValue> Failure<TValue>(TValue? value, IList<ValidationFailure> validationFailures)
    {
        return new(value, false, validationFailures);
    }
    public static Result<TValue> Failure<TValue>(TValue? value, List<ValidationFailure> validationFailures)
    {
        return new(value, false, validationFailures);
    }


    
  

    #endregion


    #region Helper

    /// <summary>
    /// Cast Value To Result of Value
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Result<TValue> Cast<TValue>(TValue? value)
    {
        if (value == null)
        {
            return new Result<TValue>(value, false, Error.Null);
        }
        else
        {
            return new Result<TValue>(value, true, Error.None);
        }
    }

   



    #endregion
}

public class Result<TValue> : Result
{
    #region Fields

    private readonly TValue? _value;

    #endregion

    #region Constructors

    protected internal Result(TValue? value, bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        _value = value;
    }
    protected internal Result(TValue? value, bool isSuccess, string errorCode,string errorMessage) : base(isSuccess, errorCode, errorMessage)
    {
        _value = value;
    }
    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }
    protected internal Result(TValue? value, bool isSuccess, Exception exception) : base(isSuccess, exception)
    {
        _value = value;
    }
    protected internal Result(TValue? value, bool isSuccess, IList<Error> errors) : base(isSuccess, errors)
    {
        _value = value;
    }
    protected internal Result(TValue? value, bool isSuccess, IList<ValidationFailure> validationFailures) : base(isSuccess, validationFailures)
    {
        _value = value;
    }
    protected internal Result(bool isSuccess, IList<ValidationFailure> validationFailures) : base(isSuccess, validationFailures)
    {
        _value = default;
    }

    protected internal Result(bool isSuccess, IList<Error> errors) : base(isSuccess, errors)
    {
        _value = default;
    }

    protected internal Result(bool isSuccess, Exception exception) : base(isSuccess, exception)
    {
        _value = default;
    }

    protected internal Result(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        _value = default;
    }

    protected internal Result(bool isSuccess, string errorCode, string errorMessage) : base(isSuccess, errorCode, errorMessage)
    {
        _value = default;
    }

    #endregion

    #region Properites

    public TValue? Value => IsSuccess ? _value : throw new InvalidOperationException("The Value of a failure result cant be accessed .");

    #endregion

    #region Operators

    public static implicit operator Result<TValue>(TValue? value) => Cast(value);

    #endregion
}