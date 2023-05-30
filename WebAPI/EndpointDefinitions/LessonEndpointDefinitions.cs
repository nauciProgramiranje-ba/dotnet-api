using Application.Chapters.Commands;
using Application.Chapters.Queries;
using WebAPI.Abstractions;
using WebAPI.Filters;

namespace WebAPI.EndpointDefinitions;

public class LessonEndpointDefinitions : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var lessons = app.MapGroup("/api/lessons");

        lessons.MapGet("/{id:guid}", GetLessonById)
            .WithName("GetLessonById");

        lessons.MapGet("/", GetAllLessons);

        lessons.MapPost("/", CreateLesson)
            .AddEndpointFilter<LessonValidationFilter>();

        lessons.MapPut("/{id:guid}", EditLesson)
            .AddEndpointFilter<LessonValidationFilter>();

        lessons.MapDelete("/{id:guid}", DeleteLesson);
    }

    private async Task<IResult> GetLessonById()
    {
        return TypedResults.Ok();
    }

    private async Task<IResult> GetAllLessons()
    {
        return TypedResults.Ok();
    }

    private async Task<IResult> CreateLesson()
    {
        return TypedResults.Ok();
    }

    private async Task<IResult> EditLesson()
    {
        return TypedResults.Ok();
    }

    private async Task<IResult> DeleteLesson()
    {
        return TypedResults.NoContent();
    }
}
