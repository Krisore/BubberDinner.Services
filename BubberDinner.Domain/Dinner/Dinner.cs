using BubberDinner.Domain.Common.Enums;
using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.Dinner.Entities;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Dinner;

public sealed class Dinner : AggreagateRoot<DinnerId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDaDateTime { get; } = default;
    public DateTime EndDateTime { get; } = default;
    public Status Status { get; } = Status.None;
    public bool IsPublic { get; } = true;
    public int MaxGuests { get; } = 10;
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    private readonly List<Reservation> _reservations;
    public Dinner(DinnerId id, string name) : base(id)
    {
        Name = name;
    }

    public string CreatedBy { get; set; }
    public string DeletedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime DeletedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }

}