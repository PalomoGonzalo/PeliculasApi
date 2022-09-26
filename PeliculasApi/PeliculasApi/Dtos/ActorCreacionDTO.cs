using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Dtos
{
    public class ActorCreacionDTO
    {
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
       
    }
}
