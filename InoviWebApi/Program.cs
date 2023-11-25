using Inovi.DataAccessLayer.Models;
using Inovi.DataTransferObject;
using Inovi.Services.Repostories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepositoryWrapper,RepositoryWrapper>();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetService<IConfiguration>();

builder.Services.AddDbContext<QueryPro>(item => item.UseSqlServer(config.GetConnectionString("DC")));

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
