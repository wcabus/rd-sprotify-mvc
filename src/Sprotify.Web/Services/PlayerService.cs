using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sprotify.Web.Models;
using Sprotify.Web.Models.Player;
using Sprotify.Web.Services.Core;

namespace Sprotify.Web.Services
{
    public class PlayerService : ApiServiceBase
    {
        public PlayerService(SprotifyHttpClient sprotifyclient) : base(sprotifyclient)
        {
        }

        public async Task<SearchResult> Search(string filter)
        {
            var albums = await Get<IEnumerable<SearchItem>>($"albums?filter={filter}").ConfigureAwait(false);
            var bands = await Get<IEnumerable<SearchItem>>($"bands?filter={filter}").ConfigureAwait(false);
            var songs = await Get<IEnumerable<SearchItem>>($"songs/search?filter={filter}").ConfigureAwait(false);

            return new SearchResult(filter, bands, albums, songs);
        }

        public Task<IEnumerable<Playlist>> GetMyPlaylists(Guid userId)
        {
            return Get<IEnumerable<Playlist>>($"users/{userId}/playlists");
        }
    }
}