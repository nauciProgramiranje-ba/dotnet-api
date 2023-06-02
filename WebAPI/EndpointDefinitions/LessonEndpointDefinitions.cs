using Application.Lessons.Commands;
using Application.Lessons.Queries;
using Domain.Chapter;
using Domain.Lesson;
using MediatR;
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

        lessons.MapGet("/chapter={chapterId:guid}", GetLessonsByChapterId);

        lessons.MapGet("/", GetAllLessons);

        lessons.MapPost("/", CreateLesson)
            .AddEndpointFilter<LessonValidationFilter>();

        lessons.MapPut("/{id:guid}", EditLesson)
            .AddEndpointFilter<LessonValidationFilter>();

        lessons.MapDelete("/{id:guid}", DeleteLesson);
    }

    private async Task<IResult> GetLessonById(IMediator mediator, Guid id)
    {
        var getLesson = new GetLessonById { LessonId = new LessonId(id) };
        var lesson = await mediator.Send(getLesson);

        return TypedResults.Ok(lesson);
    }

    private async Task<IResult> GetAllLessons(IMediator mediator)
    {
        var getAllLessons = new GetAllLessons();
        var lessons = await mediator.Send(getAllLessons);

        return TypedResults.Ok(lessons);
    }

    private async Task<IResult> GetLessonsByChapterId(IMediator mediator, Guid chapterId)
    {
        var getLessonsByChapterId = new GetLessonsByChapterId { ChapterId = new ChapterId(chapterId) };
        var lessons = await mediator.Send(getLessonsByChapterId);

        return TypedResults.Ok(lessons);
    }

    private async Task<IResult> CreateLesson(IMediator mediator, Lesson lesson)
    {
        var createLesson = new CreateLesson
        { 
            ChapterId = lesson.ChapterId, 
            Title = lesson.Title, 
            Description = lesson.Description,
            VideoUrl = lesson.VideoUrl,
            LessonNumber = lesson.LessonNumber
        };
        var createdLesson = await mediator.Send(createLesson);

        return TypedResults.Ok(createdLesson);
    }

    private async Task<IResult> EditLesson(IMediator mediator, Lesson lesson, Guid id)
    {
        var updateLesson = new UpdateLesson 
        { 
            LessonId = new LessonId(id),
            ChapterId = lesson.ChapterId,
            Title = lesson.Title, 
            Description = lesson.Description,
            VideoUrl = lesson.VideoUrl,
            LessonNumber = lesson.LessonNumber 
        };
        var updatedLesson = await mediator.Send(updateLesson);

        return Results.Ok(updatedLesson);
    }

    private async Task<IResult> DeleteLesson(IMediator mediator, Guid id)
    {
        var deleteLesson = new DeleteLesson { LessonId = new LessonId(id) };
        await mediator.Send(deleteLesson);

        return TypedResults.NoContent();
    }
}
