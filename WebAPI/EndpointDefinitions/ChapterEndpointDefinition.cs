using Application.Chapters.Commands;
using Application.Chapters.Queries;
using Domain.Chapter;
using MediatR;
using WebAPI.Abstractions;
using WebAPI.Filters;

namespace WebAPI.Endpoint;

public class ChapterEndpointDefinition : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var chapters = app.MapGroup("/api/chapters");

        chapters.MapGet("/{id:guid}", GetChapterById)
            .WithName("GetChapterById");

        chapters.MapGet("/", GetAllChapters);
        
        chapters.MapPost("/", CreateChapter)
            .AddEndpointFilter<ChapterValidationFilter>();
        
        chapters.MapPut("/{id:guid}", EditChapter)
            .AddEndpointFilter<ChapterValidationFilter>();

        chapters.MapDelete("/{id:guid}", DeleteChapter);
    }

    private async Task<IResult> GetChapterById(IMediator mediator, Guid id)
    {
        var getChapter = new GetChapterById { ChapterId = new ChapterId(id) };
        var chapter = await mediator.Send(getChapter);

        return TypedResults.Ok(chapter);
    }

    private async Task<IResult> GetAllChapters(IMediator mediator)
    {
        var getChapters = new GetAllChapters();
        var chapters = await mediator.Send(getChapters);

        return TypedResults.Ok(chapters);
    }

    private async Task<IResult> CreateChapter(IMediator mediator, Chapter chapter)
    {
        var createChapter = new CreateChapter { Title = chapter.Title, Description = chapter.Description, ChapterNumber = chapter.ChapterNumber };
        var createdChapter = await mediator.Send(createChapter);

        return TypedResults.Ok(createdChapter);
    }

    private async Task<IResult> EditChapter(IMediator mediator, Chapter chapter, Guid id)
    {
        var updateChapter = new UpdateChapter { ChapterId = new ChapterId(id), Title = chapter.Title, Description = chapter.Description, ChapterNumber = chapter.ChapterNumber };
        var updatedChapter = await mediator.Send(updateChapter);

        return Results.Ok(updatedChapter);
    }

    private async Task<IResult> DeleteChapter(IMediator mediator, Guid id)
    {
        var deleteChapter = new DeleteChapter { ChapterId = new ChapterId(id) };
        await mediator.Send(deleteChapter);

        return TypedResults.NoContent();
    }

}
