using Sprotify.Web.Models;
using Sprotify.Web.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
