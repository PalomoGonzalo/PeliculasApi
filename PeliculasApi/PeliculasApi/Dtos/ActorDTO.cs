using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Dtos
{
    public class ActorDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
    }
}
