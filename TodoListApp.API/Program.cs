

using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoListApp.API.Services.MappingProfiles;
using TodoListApp.Business;
using TodoListApp.Business.Interfaces;
using TodoListApp.DataLayer.Repositories;
using TodoListApp.DataLayer.Repositories.Interfaces;
using AppDbContext = TodoListApp.DataLayer.DataAccess.AppDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDb")));

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddFluentValidation(v =>
    {
        v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors("myAppCors");


app.Run();

