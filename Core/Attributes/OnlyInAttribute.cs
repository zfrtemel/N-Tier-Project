namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class OnlyInAttribute : Attribute
{
    public readonly string[] Documents;

    public OnlyInAttribute(params string[] docs)
    {
        Documents = docs;
    }
}
