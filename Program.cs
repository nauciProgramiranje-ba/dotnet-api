using Microsoft.EntityFrameworkCore;
using dotnet_api.Data;
using dotnet_api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<dotnet_apiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("azuredatabase") ?? throw new InvalidOperationException("Connection string 'dotnet_apiContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapChapterEndpoints();

app.Run();
