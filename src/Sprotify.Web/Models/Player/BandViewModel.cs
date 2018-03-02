using System.Collections.Generic;

namespace Sprotify.Web.Models.Player
{
    public class BandViewModel
    {
        public BandViewModel(Band band, IEnumerable<AlbumWithSongs> albums)
        {
            Band = band;
            Albums = albums;
        }

        public Band Band { get; set; }
        public IEnumerable<AlbumWithSongs> Albums { get; set; }
    }
}