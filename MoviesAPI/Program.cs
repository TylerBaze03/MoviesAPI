using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using MoviesAPI.Models;
using MoviesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.Configure<MovieDatabaseSettings>(
    builder.Configuration.GetSection("MovieDatabase"));

builder.Services.AddSingleton<MovieService>();

BsonSerializer.RegisterSerializer(new DateOnlySerializer());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
