using System;
using System.Collections.Generic;

namespace Sprotify.Web.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Art { get; set; }
        public string BandName { get; set; }
    }

    public class AlbumWithSongs : Album
    {
        public List<string> Songs { get; set; }
    }
}
