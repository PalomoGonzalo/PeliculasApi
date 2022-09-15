using AutoMapper;
using PeliculasApi.Dtos;
using PeliculasApi.Entidades;

namespace PeliculasApi.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero,GeneroDTO>().ReverseMap();//get
            
            CreateMap<GeneroCreacionDTO,Genero>().ReverseMap();//post

            CreateMap<Actor, ActorDTO>().ReverseMap();

            CreateMap<ActorDTO, Actor>();

        }

    }
}
