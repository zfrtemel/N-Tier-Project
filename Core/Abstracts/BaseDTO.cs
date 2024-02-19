using Mapster;

namespace Core.Abstracts;

/// <inheritdoc />
public abstract class BaseDTO<TDto, TEntity> : IRegister where TDto : class, new() where TEntity : class, new()
{
    public TypeAdapterConfig? Config;
    public Type TargetEntityType = typeof(TEntity);

    /// <inheritdoc/>
    public TEntity ToEntity() => this.Adapt<TEntity>();

    /// <inheritdoc/>
    public TEntity ToEntity(TEntity entity) => (this as TDto).Adapt(entity);

    /// <inheritdoc/>
    public static TDto FromEntity(TEntity entity) => entity.Adapt<TDto>();

    /// <inheritdoc/>
    public void Register(TypeAdapterConfig config)
    {
        Config = config;
        AddCustomMappings();
    }

    /// <summary>
    /// This methods lets DTO's to set its own mappings.
    /// </summary>
    public virtual void AddCustomMappings() { }

    /// <summary>
    /// SetCustomMappings(a => a, b => b) => a = DTO, b => Entity
    /// </summary>
    /// <returns></returns>
    protected TypeAdapterSetter<TDto, TEntity> SetCustomMappings() => Config.ForType<TDto, TEntity>();

    /// <summary>
    /// SetCustomMappingsInverse(a => a, b => b) => a = Entity, b => DTO
    /// </summary>
    /// <returns></returns>
    protected TypeAdapterSetter<TEntity, TDto> SetCustomMappingsInverse() => Config.ForType<TEntity, TDto>();

    /// <inheritdoc/>
    protected TypeAdapterSetter IgnoreMember(Func<Mapster.Models.IMemberModel, MemberSide, bool> predicate) => Config.Default.IgnoreMember(predicate);
}
