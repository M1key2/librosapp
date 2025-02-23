using libroscrudd.Modelos;
using Microsoft.EntityFrameworkCore;
namespace libroscrudd.Data

{
    public class Contextobiblioteca : DbContext
    {
        public Contextobiblioteca(DbContextOptions<Contextobiblioteca> options) : base(options)
        {
        }
        public DbSet<Libro> libros { get; set; }
    }
    
    }

