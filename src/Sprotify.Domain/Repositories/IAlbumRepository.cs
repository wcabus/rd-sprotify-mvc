using System.Collections.Generic;
using System.Threading.Tasks;
using Sprotify.Domain.Models;

namespace Sprotify.Domain.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbumsWithBands();
        Task<IEnumerable<Album>> GetAlbumsWithBandsAndSongs();
    }

}
