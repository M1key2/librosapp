    using libroscrudd.Client.Servicios;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using libroscrudd.Client;
using libroscrudd.Shared;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

    // Registra el servicio LibrosService
    builder.Services.AddScoped<LibrosService>();


// Establece la base URL de la API
builder.Services.AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7227/") // URL base de la API
    });



    await builder.Build().RunAsync();
    