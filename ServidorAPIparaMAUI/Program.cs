using Microsoft.EntityFrameworkCore;
using ServidorAPIparaMAUI.Contenido;
using ServidorAPIparaMAUI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));
// Add services to the container.
var app = builder.Build();
app.MapGet("api/plato", async (AppDbContext contexto) => { 
    var elementos = await contexto.Platos.ToListAsync();
    return Results.Ok(elementos);
});
app.MapPost("api/plato", async (AppDbContext contexto, Plato plato) => {
    var elementos = await contexto.Platos.AddAsync(plato);
    await contexto.SaveChangesAsync();
    return Results.Created($"api/plato/{plato.Id}", plato);// HTTP 201, URI y objeto
});
app.MapPut("api/plato/{identificador}", async (AppDbContext contexto, int identificador, Plato plato) => {
    var platoModelo = await contexto.Platos.FirstOrDefaultAsync(pl => pl.Id == identificador);
    if (platoModelo == null)
        return Results.NotFound();// HTTP 404
    platoModelo.Nombre = plato.Nombre;
    await contexto.SaveChangesAsync();
    return Results.NoContent();// HTTP 200
});
app.MapDelete("api/plato/{id}", async (AppDbContext contexto, int id) => {
    var platoModelo = await contexto.Platos.FirstOrDefaultAsync(pl => pl.Id == id);
    if (platoModelo == null)
        return Results.NotFound();// HTTP 404
    contexto.Platos.Remove(platoModelo);
    await contexto.SaveChangesAsync();
    return Results.NoContent();// HTTP 200
});
app.Run();