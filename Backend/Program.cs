using Backend.Services.Implementations;
using Backend.Services.Interfaces;
using DataRepository3;
using DataRepository3.DbContext;
using DataRepository3.Entities;
using DataRepository3.Repositories;
using DataRepository3.Repositories.Implementations;
using Microsoft.OpenApi.Models;

var myCorsPolicyName = "corspolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<MainDbContext1>();
builder.Services.AddScoped<Repository<Movie>, MovieRepository>();


builder.Services.AddScoped<IMovieService, MovieService2>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(p => p.AddPolicy(myCorsPolicyName, build =>
{
    build.WithOrigins("http://localhost:5300").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Solbeg Task4 backed",
        Version = "v0.1", 
        Description = "Simple API for movie listing"
    });                
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(myCorsPolicyName);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();