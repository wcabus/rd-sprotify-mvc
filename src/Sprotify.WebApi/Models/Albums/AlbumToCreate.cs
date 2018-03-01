using System;
using System.ComponentModel.DataAnnotations;

namespace Sprotify.WebApi.Models.Albums
{
    public class AlbumToCreate
    {
        [Required, StringLength(200)]
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [StringLength(1000), Url]
        public string Art { get; set; }
    }
}
