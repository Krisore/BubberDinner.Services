using BubberDinner.Domain.Bill.ValueObjects;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Bill;

public sealed class Bill : AggreagateRoot<BillId>
{

    public Bill(BillId id, HostId hostId, DinnerId dinnerId, GuestId guestId) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Price = Price.Create(10);
        GuestId = guestId;
        CreatedDateTime = DateTime.UtcNow;
        ModifiedDateTime = DateTime.UtcNow;
    }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }

    public GuestId GuestId { get; }

    public Price Price { get; set; }

    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }
}