namespace HomeSeeker.API.Models.CustomResults
{
    public class OperationResultSuccess : OperationResult
    {
        public OperationResultSuccess()
        {
            Success = true;
        }
    }

    public class OperationResultSuccess<T> : OperationResult<T>
    {
        public OperationResultSuccess(T data) : base(data)
        {
            Success = true;
        }
    }
}
