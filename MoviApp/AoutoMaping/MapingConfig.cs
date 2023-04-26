using AutoMapper;

using MoviApp.Models;

namespace MoviApp.AoutoMaping
{
    public class MapingConfig : Profile
    {
        public MapingConfig()
        {
             CreateMap<Genre,Genre>().ReverseMap();
            CreateMap<Person, Genre>().ReverseMap();
            CreateMap<List<Person>, Movie>().ReverseMap();
        }
    }
}
