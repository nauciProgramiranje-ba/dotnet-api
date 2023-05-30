using Application;
using Infrastructure;
using Presentation;
using Serilog;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

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

//app.Use(async (ctx, next) =>
//{
//	try
//	{
//		await next();
//	}
//	catch (Exception)
//	{
//		ctx.Response.StatusCode = 500;
//		await ctx.Response.WriteAsync("An error occured.");
//	}
//});

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();
