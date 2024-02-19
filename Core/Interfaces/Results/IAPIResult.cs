namespace Core.Interfaces.Results;

public interface IAPIResult<T>
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
}
