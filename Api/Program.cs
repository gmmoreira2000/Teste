using Data.Context;
using Microsoft.EntityFrameworkCore;
//using Data.Repository.Interfaces;
using Business.Configurations;
using Api.Configurations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContatoContextDb>(options =>
{
    options.UseSqlServer("DefautlConnection", b => b.MigrationsAssembly("Data"));
    options.UseSqlServer(builder.Configuration["ConnectionString:Location"]);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddAutoMapper(typeof(AutomapperConfig));


builder.Services.ResolveDependencias();   

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
