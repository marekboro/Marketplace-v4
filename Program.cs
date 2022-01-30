using Marketplace_v4.DataAccess;
using Marketplace_v4.Models;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Data>(); //
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProductContext>(options => options.UseMySQL(connectionString));
builder.Services.AddTransient<ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
//var connectionString = app.Configuration.GetConnectionString("Default");

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
