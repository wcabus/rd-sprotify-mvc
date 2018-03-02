namespace Sprotify.WebApi.Models.Playlists
{
    public class PlaylistToCreate
    {
        public string Title { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsCollaborative { get; set; }
    }
}