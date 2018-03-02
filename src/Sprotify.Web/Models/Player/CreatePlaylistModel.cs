using System.ComponentModel.DataAnnotations;

namespace Sprotify.Web.Models.Player
{
    public class CreatePlaylistModel
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        [Display(Name = "Make this playlist private")]
        public bool IsPrivate { get; set; }

        [Display(Name = "Allow others to edit this playlist")]
        public bool IsCollaborative { get; set; }
    }
}
