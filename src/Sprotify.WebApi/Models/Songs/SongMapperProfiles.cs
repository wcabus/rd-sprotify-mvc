namespace Sprotify.WebApi.Models.Songs
{
    public class SongMapperProfiles : AutoMapper.Profile
    {
        public SongMapperProfiles()
        {
            CreateMap<Domain.Dto.SongResult, Song>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Song.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Song.Title))
                .ForMember(x => x.ReleaseDate, opt => opt.MapFrom(src => src.Song.ReleaseDate))
                .ForMember(x => x.Duration, opt => opt.MapFrom(src => src.Song.Duration))
                .ForMember(x => x.ContainsExplicitLyrics, opt => opt.MapFrom(src => src.Song.ContainsExplicitLyrics))
                .ForMember(x => x.Album, opt => opt.MapFrom(src => src.Album.Title))
                .ForMember(x => x.AlbumArt, opt => opt.MapFrom(src => src.Album.Art))
                .ForMember(x => x.Band, opt => opt.MapFrom(src => src.Band.Name));
        }
    }
}
