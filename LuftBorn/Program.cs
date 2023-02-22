using LuftBorn.Application.Common;
using LuftBorn.Domain.Model;
using LuftBorn.Infrastructure;
using LuftBorn.Infrastructure.Interfaces;
using LuftBorn.Infrastructure.Repositry;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddApplication();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" }));
builder.Services.AddScoped<IRepository<Note>, NoteRepositry>();
builder.Services.AddDbContext<LuftBornContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DataEF"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Awesome API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
