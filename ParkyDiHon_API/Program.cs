using Microsoft.EntityFrameworkCore;
using ParkyDiHon_API.Data;
using AutoMapper;
using ParkyDiHon_API.Mapper;
using ParkyDiHon_API.Repository.IRepository;
using ParkyDiHon_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddAutoMapper(typeof(ParkyMapper));
builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
