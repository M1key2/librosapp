using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libroscrudd.Data;
using libroscrudd.Modelos;

namespace libroscrudd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroesController : ControllerBase
    {
        private readonly Contextobiblioteca _context;

        public LibroesController(Contextobiblioteca context)
        {
            _context = context;
        }

        // GET: api/Libroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> Getlibros()
        {
            return await _context.libros
                .Select(l => new LibroDTO
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    AnioPublicacion = l.AnioPublicacion,
                    Editorial = l.Editorial
                })
                .ToListAsync();
        }

        // GET: api/Libroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDTO>> GetLibro(int id)
        {
            var libro = await _context.libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            var libroDTO = new LibroDTO
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                AnioPublicacion = libro.AnioPublicacion,
                Editorial = libro.Editorial
            };

            return libroDTO;
        }

        // PUT: api/Libroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        private bool LibroExists(int id)
        {
            return _context.libros.Any(e => e.Id == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, LibroDTO libroDTO)
        {
            if (id != libroDTO.Id)
            {
                return BadRequest();
            }

            var libro = await _context.libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            // Actualizamos las propiedades del libro con los datos del DTO
            libro.Titulo = libroDTO.Titulo;
            libro.Autor = libroDTO.Autor;
            libro.AnioPublicacion = libroDTO.AnioPublicacion;
            libro.Editorial = libroDTO.Editorial;

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/Libroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibroDTO>> PostLibro(LibroDTO libroDTO)
        {
            var libro = new Libro
            {
                Titulo = libroDTO.Titulo,
                Autor = libroDTO.Autor,
                AnioPublicacion = libroDTO.AnioPublicacion,
                Editorial = libroDTO.Editorial
            };

            _context.libros.Add(libro);
            await _context.SaveChangesAsync();

            // Devolvemos un LibroDTO con el ID generado
            var nuevoLibroDTO = new LibroDTO
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                AnioPublicacion = libro.AnioPublicacion,
                Editorial = libro.Editorial
            };

            return CreatedAtAction("GetLibro", new { id = libro.Id }, nuevoLibroDTO);
        }
        // DELETE: api/Libroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
