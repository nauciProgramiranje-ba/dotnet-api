using Domain.Chapter;

namespace WebAPI.Filters;

public class ChapterValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var chapter = context.GetArgument<Chapter>(1);

        if (string.IsNullOrEmpty(chapter.Title)) return await Task.FromResult(Results.BadRequest("Invalid title."));
        if (string.IsNullOrEmpty(chapter.Description)) return await Task.FromResult(Results.BadRequest("Invalid description."));

        return await next(context);
    }
}
