using System;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.ValueObjects
{
    public class Rating : Entity<RatingId>
    {

        public Guid DinnerId { get; }
        public Guid HostId { get; }
        public int Value { get; }

        public Rating(RatingId id, Guid hostId, Guid dinnerId, int value,
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