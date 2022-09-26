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
<<<<<<< HEAD
           // CreateMap<ActorDTO, Actor>();
=======
>>>>>>> 4c0ad7531bd11abefa8e285ed8783c8cd8579d96

        }

    }
}
