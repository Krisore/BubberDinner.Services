using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.Entities;
using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.MenuReview.ValueObjects;

namespace BubberDinner.Domain.Models.Menu;

/// <summary>
/// Represents a menu entity in the domain. It contains menu sections, 
/// dinner IDs, menu review IDs, and other metadata. Menu is an aggregate root 
/// with a unique ID used to identify it. It contains factory methods to 
/// create a new Menu instance. The class is immutable except for the 
/// description, which can be changed.
/// </summary>
public sealed class Menu : AggreagateRoot<MenuId>
{
    private readonly List<MenuSection> _menuSections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; }
    public string Description { get; }
    public Menu(MenuId id,
                string name,
                string description,
                HostId hostId,
                DateTime createdDateTime,
                DateTime updatedDateTime)
     : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        ModifiedDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public AverageRating AverageRating { get; }
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();

    public string CreatedBy { get; set; }
    public string DeletedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime DeletedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }
}