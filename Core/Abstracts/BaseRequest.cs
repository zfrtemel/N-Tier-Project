namespace Core.Abstracts;

public abstract class BaseRequest
{
    public Out MapTarget<Out, KeyType>(Out target) where Out : BaseEntity<KeyType>
    {
        if (target is null) throw new ArgumentNullException(typeof(Out).Name);

        GetType().GetProperties().ToList().ForEach((property) =>
        {
            var targetProperty = target.GetType().GetProperty(property.Name);
            if (targetProperty == null) return;

            targetProperty.SetValue(target, property.GetValue(this));
        });

        return target;
    }
}
