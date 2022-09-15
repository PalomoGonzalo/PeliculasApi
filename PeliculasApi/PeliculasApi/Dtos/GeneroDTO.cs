using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Dtos
{
    public class GeneroDTO
    {
        public string Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
    }
}
