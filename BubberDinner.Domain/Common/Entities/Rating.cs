using System;

using BubberDinner.Domain.DinnerAggregate.ValueObjects;
using BubberDinner.Domain.HostAggregate.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.ValueObjects
{
    public class Rating : Entity<RatingId>
    {

        public DinnerId DinnerId { get; }
        public HostId HostId { get; }
        public int Value { get; }

        public Rating(RatingId id, HostId hostId, DinnerId dinnerId, int value,
            DateTime createdDateTime, DateTime updatedDateTime) : base(id)
        {

            HostId = hostId;
            DinnerId = dinnerId;
            Value = value;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
    }
}