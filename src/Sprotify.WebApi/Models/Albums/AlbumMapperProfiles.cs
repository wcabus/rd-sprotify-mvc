namespace Sprotify.WebApi.Models.Albums
{
    public class AlbumMapperProfiles : AutoMapper.Profile
    {
        public AlbumMapperProfiles()
        {
            CreateMap<Domain.Models.Album, Album>()
                .ForMember(x => x.Band, opt => opt.MapFrom(x => x.Band.Name));

            CreateMap<Domain.Models.Album, SearchItem>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(x => x.Band, opt => opt.MapFrom(src => src.Band.Name))
                .ForMember(x => x.BandId, opt => opt.MapFrom(src => src.BandId))
                .ForMember(x => x.Image, opt => opt.MapFrom(src => src.Art));
        }
    }
}
