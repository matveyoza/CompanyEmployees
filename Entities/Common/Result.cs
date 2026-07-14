namespace Entities.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public IEnumerable<string> Errors { get; }

        protected Result(bool isSuccess, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result Success() => new Result(true, Array.Empty<string>());
        public static Result Failure(IEnumerable<string> errors) => new Result(false, errors);
    }
}
