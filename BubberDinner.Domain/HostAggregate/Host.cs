using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;
using BubberDinner.Domain.HostAggregate.ValueObjects;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.Models;
using BubberDinner.Domain.UserAggregate.ValueObjects;

namespace BubberDinner.Domain.HostAggregate;


public sealed class Host : AggreagateRoot<HostId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }

    public UserId UserId { get; }
    private readonly List<MenuId> _menuIds;
    private readonly List<DinnerId> _dinnerIds;
    public Host(HostId id) : base(id)
    {
    }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public string CreatedBy { get; set; }
    public string DeletedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime DeletedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }

}
