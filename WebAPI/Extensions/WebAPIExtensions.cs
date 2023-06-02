using MediatR;
using WebAPI.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions;
using Application.Lessons.Commands;
using Application.Questions.Commands;
using Application.Chapters.Commands;
using Infrastructure;
using Infrastructure.Repositories;

namespace WebAPI.Extensions;

public static class WebAPIExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Azure");
        builder.Services.AddDbContext<NauciProgramiranjeDbContext>(opt => opt.UseSqlServer(cs));

        builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
        builder.Services.AddScoped<ILessonRepository, LessonRepository>();
        builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

        builder.Services.AddMediatR(typeof(CreateChapter));
        builder.Services.AddMediatR(typeof(CreateLesson));
        builder.Services.AddMediatR(typeof(CreateQuestion));
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

    public static void UseGlobalExceptionHandling(this WebApplication app)
    {
        app.Use(async (ctx, next) =>
        {
            try
            {
                await next();
            }
            catch (Exception)
            {
                ctx.Response.StatusCode = 500;
                await ctx.Response.WriteAsync("An error occured.");
            }
        });
    }
}
