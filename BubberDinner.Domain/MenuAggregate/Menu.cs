using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;
using BubberDinner.Domain.HostAggregate.ValueObjects;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BubberDinner.Domain.Models.MenuAggregate;

/// <summary>
/// Represents a menu entity in the domain. It contains menu sections, 
/// dinner IDs, menu review IDs, and other metadata. Menu is an aggregate root 
/// with a unique ID used to identify it. It contains factory methods to 
/// create a new Menu instance. The class is immutable except for the 
/// description, which can be changed.
/// </summary>
public class Menu : AggreagateRoot<MenuId>
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
                List<MenuSection> menuSections,
                DateTime createdDateTime,
                DateTime updatedDateTime)
     : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _menuSections = menuSections;
        CreatedDateTime = createdDateTime;
        ModifiedDateTime = updatedDateTime;
    }

    public static Menu Create(string name,
                              string description,
                              HostId hostId,
                              List<MenuSection> sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections,
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