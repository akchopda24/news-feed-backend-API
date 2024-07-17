using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsFeed.DataAccess.Entities;
using NewsFeed.DataAccess.Repository;
using NewsFeed.Service.Interface;
using NewsFeed.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.API.Profiles;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.DataAccess.Profiler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IGenericRepository, GenericRepository>();


builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<INewsFeedService, NewsFeedService>();

builder.Services.AddSession();
builder.Services.AddDbContext<NewsFeedDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("Connectionstring")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
