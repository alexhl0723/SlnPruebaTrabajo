
using Capa_Datos.DataContext;
using Capa_Negocio.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUbigeoService, UbigeoService>();

// Obtener y validar cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("connection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'connection' no está configurada correctamente.");
}
else
{
    Console.WriteLine($"Cadena de conexión obtenida: {connectionString}");
}

// Registrar el DbContext

builder.Services.AddDbContext<TrabajadoresDataContext>(options =>
{
    options.UseSqlServer(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trabajadores}/{action=Index}/{id?}");

app.Run();
