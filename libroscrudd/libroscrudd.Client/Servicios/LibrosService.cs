using System.Net.Http.Json;
using libroscrudd.Shared;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace libroscrudd.Client.Servicios
{
    public class LibrosService
    {
        private readonly HttpClient _http;

        public LibrosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<LibroDTO>> GetLibrosAsync()
        {
            return await _http.GetFromJsonAsync<List<LibroDTO>>("api/Libroes");

        }

        public async Task<LibroDTO> GetLibroAsync(int id)
        {
            return await _http.GetFromJsonAsync<LibroDTO>($"api/Libroes/{id}");
        
        }

        public async Task AddLibroAsync(LibroDTO libro)
        {
            await _http.PostAsJsonAsync("api/Libroes", libro);
        }

        public async Task UpdateLibroAsync(LibroDTO libro)
        {
            await _http.PutAsJsonAsync($"api/Libroes/{libro.Id}", libro);
        }

        public async Task DeleteLibroAsync(int id)
        {
            await _http.DeleteAsync($"api/Libroes/{id}");
        }
    }
}