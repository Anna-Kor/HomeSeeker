using System;

namespace HomeSeeker.API.Models.CustomResults
{
    public abstract class OperationResult
    {
        public bool Success { get; protected set; }

        public bool Failure => !Success;
    }

    public abstract class OperationResult<T> : OperationResult
    {
        private T _data;

        protected OperationResult(T data)
        {
            Data = data;
        }

        public T Data
        {
            get => Success ? _data : throw new Exception($"You can't access .{nameof(Data)} when .{nameof(Success)} is false");
            set => _data = value;
        }
    }
}
