using Microsoft.EntityFrameworkCore;
using PassingTrips;
using PassingTrips.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtTokens();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("TripsDatabase"))
        .UseSnakeCaseNamingConvention());
builder.Services.AddRepositories();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
