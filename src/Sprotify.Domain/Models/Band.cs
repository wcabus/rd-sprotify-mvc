using System;
using System.Collections.Generic;

namespace Sprotify.Domain.Models
{
    public class Band
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}