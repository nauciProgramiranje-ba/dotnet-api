using Application;
using Infrastructure;
using Presentation;
using Serilog;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var AllowSpecificOrigins = "AllowAccess";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000/", "https://nauciprogramiranje.vercel.app/")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.RegisterServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseGlobalExceptionHandling();

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);
app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.RegisterEndpointDefinitions();

app.Run();
