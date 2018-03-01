namespace Sprotify.WebApi.Models.Albums
{
    public class AlbumMapperProfiles : AutoMapper.Profile
    {
        public AlbumMapperProfiles()
        {
            CreateMap<Domain.Models.Album, Album>()
                .ForMember(x => x.Band, opt => opt.MapFrom(x => x.Band.Name));
        }
    }
}
