using System.ComponentModel.DataAnnotations;

namespace Core.Attributes;

public class OneOfAttribute : ValidationAttribute
{
    private readonly string[] _pool;

    public OneOfAttribute(params string[] pool)
    {
        _pool = pool;
    }

    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        return _pool.Contains(value.ToString());
    }
}
