namespace Core.Responses;

public class ModelValidationError
{
    public string Key { get; set; } = "";
    public ICollection<string> Errors { get; set; } = new List<string>();
}
