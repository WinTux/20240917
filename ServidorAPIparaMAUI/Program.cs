using Microsoft.EntityFrameworkCore;
using ServidorAPIparaMAUI.Contenido;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));
// Add services to the container.
var app = builder.Build();
app.Run();