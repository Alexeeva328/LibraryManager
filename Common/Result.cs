namespace Common;

public class Result<T>
{
    public bool IsSuccess { get; protected set; }
    
    public Error Error { get; protected set; }

    public T? Data { get; private set; }

    public static Result<T> Success(T data)
    {
        return new Result<T> { IsSuccess = true, Data = data };
    }

    public new static Result<T> Failure(Error error)
    {
        return new Result<T> { IsSuccess = false, Error = error };
    }
}