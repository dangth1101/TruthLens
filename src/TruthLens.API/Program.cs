using Microsoft.EntityFrameworkCore;
using TruthLens.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHealthChecks().AddDbContextCheck<AppDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHealthChecks("/health");

app.Run();



