using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprotify.WebApi.Models.Albums
{
    public class AlbumMapperProfile : AutoMapper.Profile
    {
        public AlbumMapperProfile()
        {
            CreateMap<Domain.Models.Album, AlbumWithBandAndSongs>()
                .ForMember(dst => dst.BandName, opt => opt.MapFrom(src => src.Band.Name))
                .ForMember(
                    dst => dst.Songs, opt => opt.MapFrom(src => 
                        src.Songs.Select(s => s.Song.Title).ToList()
                    ));
        }
    }
}
