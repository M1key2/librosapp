using System.ComponentModel.DataAnnotations;

namespace libroscrudd.Shared
{
    public class LibroDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es requerido")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "El autor es requerido")]

        public string? Autor { get; set; }
        [Required(ErrorMessage = "El género es requerido")]
        public int AnioPublicacion { get; set; }
        [Required(ErrorMessage = "El género es requerido")]
        public string? Editorial { get; set; }
    }
}
