using System;
using System.Globalization;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Actio.Common.Events
{
    public class ActivityCreated : IAuthenticatedEvent
    {
        public Guid UserId { get; }

        public Guid Id { get; }


        public string Category { get; }

        public string Name { get; }

        public string Description { get; }
        public DateTime CreatedAt { get; }

        protected ActivityCreated()
        {
        }

        public ActivityCreated(
            Guid id,
            Guid userId,
            string category,
            string name,
            string description,
            DateTime createdAt
        )
        {
            Id = id;
            Category = category;
            CreatedAt = createdAt;
            Description = description;
            UserId = userId;
            Name = name;
        }
    }
}
