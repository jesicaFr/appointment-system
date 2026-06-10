using AppointmentSystem.Api.Data;
using AppointmentSystem.Api.Repositories;
using AppointmentSystem.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// DI for repositories and services
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var connFromConfig = config.GetConnectionString("DefaultConnection");
    var connFromDb = db.Database.GetDbConnection().ConnectionString;
    Console.WriteLine($"ConnectionString (config): {connFromConfig}");
    Console.WriteLine($"ConnectionString (DbConnection): {connFromDb}");
    Console.WriteLine($"Current process user: {WindowsIdentity.GetCurrent().Name}");

    try
    {
        // Prueba de conexión antes de migrar
        var canConnect = db.Database.CanConnect();
        Console.WriteLine($"Database.CanConnect() = {canConnect}");

        db.Database.Migrate();
        Console.WriteLine("Migrate aplicado correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("EXCEPCIÓN al migrar:");
        Console.WriteLine(ex.ToString());
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors("ReactPolicy"); 
app.UseAuthorization();

app.MapControllers();

app.Run();
