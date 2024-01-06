using BubberDinner.Domain.Bill.ValueObjects;
using BubberDinner.Domain.Common.Enums;
using BubberDinner.Domain.Dinner.ValueObjects;
using BubberDinner.Domain.Guest.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Dinner.Entities;


public sealed class Reservation : AggreagateRoot<ReservationId>
{

    public Reservation(ReservationId id) : base(id)
    {
    }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public ReservationStatus ReservationStatus { get; }
    public DateTime ArrivalDateTime { get; }
}