using System;
using System.Collections.Generic;

namespace Sprotify.Domain.Models
{
    public class User
    {
        protected internal User() { }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
            Registered = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public DateTimeOffset Registered { get; internal set; }

        public virtual ICollection<UserSubscription> Subscriptions { get; set; }

        public virtual ICollection<PlaylistSubscription> Playlists { get; set; }
    }
}