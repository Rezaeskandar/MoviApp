using AutoMapper;
using MoviApp.Enteties;
using MoviApp.Models;

namespace MoviApp.AoutoMaping
{
    public class MapingConfig : Profile
    {
        public MapingConfig()
        {
             CreateMap<Genre,Genre>().ReverseMap();
            CreateMap<Movie, Movie>().ReverseMap();
            CreateMap<Person, Genre>().ReverseMap();
            CreateMap<List<Person>, Movie>().ReverseMap();
            //CreateMap<List<Person>, Rating>().ReverseMap();
            //CreateMap<List<Rating>, Rating>().ReverseMap();

        }
    }
}
