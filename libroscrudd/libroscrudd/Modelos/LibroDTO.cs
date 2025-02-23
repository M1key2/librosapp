using System.ComponentModel.DataAnnotations;

namespace libroscrudd.Modelos
{
    public class LibroDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        public string? Autor { get; set; }

        public string? Editorial { get; set; }
        [Required(ErrorMessage = "El año de publicacion es obligatorio")]
        [Range(1000, 9999, ErrorMessage = "El año de publicacion debe ser un valor entre 1000 y 9999")]
        public int AnioPublicacion { get; set; }

    }
}
