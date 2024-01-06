using BubberDinner.Domain.BillAggregate.ValueObjects;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;
using BubberDinner.Domain.GuestAggregate.ValueObjects;
using BubberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BubberDinner.Domain.Models;
using BubberDinner.Domain.UserAggregate.ValueObjects;

namespace BubberDinner.Domain.GuestAggregate;


public sealed class Guest : AggreagateRoot<GuestId>
{
    private readonly List<DinnerId> _upcommingDinnerIds;
    private readonly List<DinnerId> _pastDinnerIds;

    private readonly List<DinnerId> _pendingDinnerIds;
    private readonly List<BillId> _billIds;
    private readonly List<MenuReviewId> _menuReviewIds;

    private readonly List<Rating> _ratings;
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; set; }
    public Guest(GuestId id) : base(id)
    {
    }

    public IReadOnlyList<DinnerId> UpcommingDinnerIds => _upcommingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

}