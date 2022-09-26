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
            
            CreateMap<GeneroCreacionDTO,Genero>();//post

            CreateMap<Actor, ActorDTO>().ReverseMap();

            CreateMap<ActorCreacionDTO, Actor>();

            CreateMap<Pelicula,PeliculaDTO>().ReverseMap();
           // CreateMap<ActorDTO, Actor>();

        }

    }
}
