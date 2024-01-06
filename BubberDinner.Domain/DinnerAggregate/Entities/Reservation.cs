
using BubberDinner.Domain.BillAggregate.ValueObjects;
using BubberDinner.Domain.Common.Enums;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;
using BubberDinner.Domain.GuestAggregate.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.DinnerAggregate.Entities;


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