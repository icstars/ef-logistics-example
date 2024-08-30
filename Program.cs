using Microsoft.EntityFrameworkCore;

// LogisticsManager

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LogisticsDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new Microsoft.EntityFrameworkCore.MySqlServerVersion(new Version(8, 0, 21)))
);


var app = builder.Build();


// creating the database if not existing based on models
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<LogisticsDbContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.MapGet("/", () => "Helloooooooo Nurse!");

app.MapGet("/vehicles", async (LogisticsDbContext db) =>
    await db.Vehicles.ToListAsync());

app.Run();
