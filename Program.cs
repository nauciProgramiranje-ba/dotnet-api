using Microsoft.EntityFrameworkCore;
using dotnet_api.Endpoints;
using dotnet_api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NauciProgramiranjeDbContext>(options =>
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

// Endpoints
app.MapChapterEndpoints();
app.MapLessonEndpoints();
app.MapQuestionEndpoints();
app.MapUserProgressEndpoints();

app.Run();