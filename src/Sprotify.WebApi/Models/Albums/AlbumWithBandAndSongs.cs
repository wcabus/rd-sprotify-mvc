using System.Collections.Generic;

namespace Sprotify.WebApi.Models.Albums
{
    public class AlbumWithBandAndSongs : AlbumWithBand
    {
        public List<string> Songs { get; set; }
    }
}