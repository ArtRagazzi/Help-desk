using System.ComponentModel.DataAnnotations;

namespace api.Entities;

public abstract class EntityBase
{
    public int Id { get; private set; }
}