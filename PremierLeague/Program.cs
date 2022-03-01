using MediatR;
using Microsoft.EntityFrameworkCore;
using PremierLeague.EntityModels;
using PremierLeague.EntityModels.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PremierLeagueContext>((DbContextOptionsBuilder options) =>

{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(GetAllPlayersQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetPlayerByIdQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(CreatePlayerCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdatePlayerCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(DeletePlayerCommandHandler).Assembly);
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
