using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sprotify.Domain.Models;
using Sprotify.Domain.Repositories;

namespace Sprotify.DAL.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly SprotifyDbContext _context;

        public AlbumRepository(SprotifyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAlbumsWithBands()
        {
            var query = await _context
                .Set<Album>()
                .Include(x => x.Band)
                .ToListAsync()
                .ConfigureAwait(false);

            return query;
        }

        public async Task<IEnumerable<Album>> GetAlbumsWithBandsAndSongs()
        {

            var query = await _context
                .Set<Album>()
                .Include(x => x.Band)
                .Include(x => x.Songs).ThenInclude(s => s.Song)
                .ToListAsync()
                .ConfigureAwait(false);

            return query;
        }
    }
}
