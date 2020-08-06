using System;
using System.Diagnostics.Contracts;

namespace NetExercise.BLL.Utils
{
    public class Result
    {
        public bool Success { get; }
        public string Error { get; }
        public bool Failure => !Success;

        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default(T), false, message);
        }

        public static Result Ok()
        {
            return new Result(true, String.Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, String.Empty);
        }
    }

    public class Result<T> : Result
    {
        private T _value;

        public T Value
        {
            get
            {
                Contract.Requires(Success);

                return _value;
            }

            private set { _value = value; }
        }

        protected internal Result(T value, bool success, string error)
            : base(success, error)
        {
            Contract.Requires(value != null || !success);

            Value = value;
        }
    }
}