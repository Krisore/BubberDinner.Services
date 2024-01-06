using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;
using BubberDinner.Domain.GuestAggregate.ValueObjects;
using BubberDinner.Domain.HostAggregate.ValueObjects;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using BubberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggreagateRoot<MenuReviewId>
{
    public Rating Rating { get; }
    public string Comment { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public DinnerId DinnerId { get; }

    public GuestId GuestId { get; }
    public MenuReview(MenuReviewId id) : base(id)
    {
    }
    public DateTime CreatedDateTime { get; set; }
    public DateTime DeletedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }
}
