using Core.Attributes;
using Core.Interfaces.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Abstracts;

/// <inheritdoc />
public abstract class BaseEntity<T> : ISoftDelete, ITimeStamps
{
    [Column("id"), Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; } = default!;

    [Column("created_at"), Orderable("created_at"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at"), Orderable("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at"), JsonIgnore]
    public DateTime? DeletedAt { get; set; }

    [NotMapped]
    public bool BypassSoftDelete { get; set; } = false;
}
