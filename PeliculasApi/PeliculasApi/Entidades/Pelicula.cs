using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Entidades
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Titulo { get; set; }  
        public string Poster { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaDeEstreno { get; set; }    

    }
}