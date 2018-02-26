using System;
using System.Collections.Generic;

namespace Sprotify.Domain.Models
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Guid CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastUpdatedOn { get; set; }
        public bool IsCollaborative { get; set; }
        public bool IsPrivate { get; set; }

        public virtual ICollection<PlaylistSong> Songs { get; set; }
    }
}