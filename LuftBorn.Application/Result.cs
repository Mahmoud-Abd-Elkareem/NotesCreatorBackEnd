namespace LuftBorn.Application
{

    public class Result
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        internal Result(IEnumerable<string>? errors = null)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            Errors = errors?.ToArray();
        }

        public bool Succeeded => Errors == default || !Errors.Any();

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string[]? Errors { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.


        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(errors);
        }
    }

    public class Result<T> : Result
    {
        public Result()
        {

        }

        internal Result(T data, IEnumerable<string> errors = null) : base(errors)
        {
            Data = data;
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public T? Data { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.


        public static Result<T> Failure(T data, IEnumerable<string> errors)
        {
            return new Result<T>(data, errors);
        }

        public new static Result<T> Failure(IEnumerable<string> errors)
        {
            return new Result<T>(default, errors);
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data);
        }
    }
}