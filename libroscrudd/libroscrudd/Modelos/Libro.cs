using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libroscrudd.Modelos
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="El titulo es obligatorio")]
        [MaxLength(50, ErrorMessage = "El titulo no puede tener mas de 50 caracteres")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        [MaxLength(50, ErrorMessage = "El autor no puede tener mas de 50 caracteres")]
        public string? Autor { get; set; }

        [MaxLength(50, ErrorMessage = "La editorial no puede tener mas de 50 caracteres")]

        public string? Editorial { get; set; }
        [Required(ErrorMessage = "El año de publicacion es obligatorio")]
        [Range(1000, 9999, ErrorMessage = "El año de publicacion debe ser un valor entre 1000 y 9999")]
        public int AnioPublicacion { get; set; }
    }
}
