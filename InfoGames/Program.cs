using InfoGames.WebAPI.Data.DbContexts;
using InfoGames.WebAPI.Infrastructure.Managers;
using InfoGames.WebAPI.Infrastructure.Managers.Interfaces;
using InfoGames.WebAPI.Infrastructure.Repositories;
using InfoGames.WebAPI.Infrastructure.Repositories.Base;
using InfoGames.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GamesDbContext>(options =>
options.UseSqlServer(
     builder.Configuration.GetConnectionString("GameDbConnection")));

builder.Services.AddTransient<IRepository<GameModel>, GameRepository>();
builder.Services.AddTransient<IGameManager, GameManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();