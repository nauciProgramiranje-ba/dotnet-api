using Application.Abstractions;
using Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Application.Chapters.Commands;
using MediatR;
using WebAPI.Abstractions;

namespace WebAPI.Extensions;

public static class WebAPIExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<NauciProgramiranjeDbContext>(opt => opt.UseSqlServer(cs));
        builder.Services.AddScoped<IChapterRepository, ChapterRepository>();

        builder.Services.AddMediatR(typeof(CreateChapter));
    }

    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.RegisterEndpoints(app);
        }
    }
}
