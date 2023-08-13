using System;
using System.Collections.Generic;

namespace HomeSeeker.API.Models.CustomResults
{
    public class OperationResultError : OperationResult, IOperationResultError
    {
        public OperationResultError(string message) : this(message, Array.Empty<Error>())
        {
        }

        public OperationResultError(string message, IReadOnlyCollection<Error> errors)
        {
            Message = message;
            Success = false;
            Errors = errors ?? Array.Empty<Error>();
        }

        public string Message { get; }
        public IReadOnlyCollection<Error> Errors { get; }
    }

    public class OperationResultError<T> : OperationResult<T>, IOperationResultError
    {
        public OperationResultError(string message) : this(message, Array.Empty<Error>())
        {
        }

        public OperationResultError(string message, IReadOnlyCollection<Error> errors) : base(default)
        {
            Message = message;
            Success = false;
            Errors = errors ?? Array.Empty<Error>();
        }

        public string Message { get; set; }
        public IReadOnlyCollection<Error> Errors { get; }
    }

    public class Error
    {
        public Error(string details) : this(null, details)
        {

        }

        public Error(string code, string details)
        {
            Code = code;
            Details = details;
        }

        public string Code { get; }
        public string Details { get; }
    }

    internal interface IOperationResultError
    {
        string Message { get; }
        IReadOnlyCollection<Error> Errors { get; }
    }
}