using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprotify.WebApi.Models.Albums
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Art { get; set; }

        public string Band { get; set; }
    }
}
