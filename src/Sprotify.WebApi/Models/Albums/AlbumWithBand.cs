using System;

namespace Sprotify.WebApi.Models.Albums
{
    public class AlbumWithBand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Art { get; set; }
        public string BandName { get; set; }
    }
}