using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TruthLens.Application.Modules.MediaModule.Interfaces;
using TruthLens.Application.Modules.MediaModule.UseCases;
using TruthLens.Infrastructure.Modules.MediaModule.FileStorage;
using TruthLens.Infrastructure.Modules.MediaModule.Hashing;
using TruthLens.Infrastructure.Modules.MediaModule.Repositories;
using TruthLens.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddOpenApi();
builder.Services.AddHealthChecks().AddDbContextCheck<AppDbContext>();
builder.Services.AddSingleton<IHashService, Sha256HashService>();
builder.Services.AddScoped<IFileStorageService, LocalFileStorageService>();
builder.Services.AddScoped<IMediaFileRepository, MediaFileRepository>();
builder.Services.AddScoped<IFileSimilarityRepository, FileSimilarityRepository>();
builder.Services.AddScoped<UploadMediaUseCase>();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapGet("/", () => "Hello World!");
app.MapHealthChecks("/health");
app.MapPost("/upload", async (UploadMediaUseCase uploadMediaUseCase, HttpRequest request) =>
{
    if (!request.HasFormContentType || !request.Form.Files.Any())
        return Results.BadRequest("No file uploaded.");

    var file = request.Form.Files[0];
    using var stream = file.OpenReadStream();
    var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    string fileUrl = await uploadMediaUseCase.ExecuteAsync(userId, stream, file.FileName, file.ContentType);
    return Results.Ok(new { FileUrl = fileUrl });
});

app.Run();



