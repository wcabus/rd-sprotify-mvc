using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprotify.Web.Models;
using Sprotify.Web.Services.Core;

namespace Sprotify.Web.Services
{
    public class AlbumService : ApiServiceBase
    {
        public AlbumService(SprotifyHttpClient sprotifyclient) : base(sprotifyclient)
        {
        }

        public Task<IEnumerable<Album>> GetAlbums()
        {
            return Get<IEnumerable<Album>>("albums");
        }

        public Task<IEnumerable<AlbumWithSongs>> GetAlbumsWithSongs()
        {
            return Get<IEnumerable<AlbumWithSongs>>("albums?includeSongs=true");
        }
    }
}
