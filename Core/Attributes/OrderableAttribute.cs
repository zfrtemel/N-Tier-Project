namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class OrderableAttribute : Attribute
{
    public readonly string Key;
    //public readonly string orderType;

    public OrderableAttribute(string Key/*, string orderType*/)
    {
        this.Key = Key;
        //this.orderType = orderType;
    }
}
