using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        //public async Task<SearchResult> Search(string filter)
        //{
        //    var httpclient = new HttpClient
        //    {
        //        BaseAddress = new Uri("https://localhost:44301/"),
        //        DefaultRequestHeaders =
        //        {
        //            { "Authorize", "Bearer e092309eur02394uf09eu2309uv2049u" }
        //        }
        //    };

        //    var response = await httpclient.GetAsync($"albums?filter={filter}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json = await response.Content.ReadAsStringAsync();
        //        var albums = JsonConvert.DeserializeObject<IEnumerable<SearchItem>>(json);
        //        return new SearchResult(filter, null, albums, null);
        //    }

        //    switch (response.StatusCode)
        //    {
        //        case System.Net.HttpStatusCode.NotFound:
        //            throw new ResourceNotFoundException();
        //    }
        //}

        public async Task<SearchResult> Search(string filter)
        {
            var albums = await Get<IEnumerable<SearchItem>>($"albums?filter={filter}").ConfigureAwait(false);
            var bands = await Get<IEnumerable<SearchItem>>($"bands?filter={filter}").ConfigureAwait(false);
            var songs = await Get<IEnumerable<SearchItem>>($"songs/search?filter={filter}").ConfigureAwait(false);

            return new SearchResult(filter, bands, albums, songs);
        }

        public Task<IEnumerable<Playlist>> GetPlaylists()
        {
            return Get<IEnumerable<Playlist>>($"playlists");
        }

        public Task<IEnumerable<Playlist>> GetMyPlaylists(Guid userId)
        {
            return Get<IEnumerable<Playlist>>($"users/{userId}/playlists");
        }

        public Task<Playlist> CreatePlaylist(CreatePlaylistModel model)
        {
            return Post<Playlist>("playlists", model);
        }

        public Task<Band> GetBand(Guid id)
        {
            return Get<Band>($"bands/{id}");
        }

        public Task<IEnumerable<AlbumWithSongs>> GetAlbumsForBand(Guid id)
        {
            return Get<IEnumerable<AlbumWithSongs>>($"bands/{id}/albums?includeSongs=true");
        }
    }
}