namespace BubberDinner.Domain.Models;

public abstract class AggreagateRoot<TId>(TId id) : Entity<TId>(id)
where TId : notnull
{
}