using Domain.Chapter;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Filters;

public class ChapterValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var chapter = context.GetArgument<Chapter>(1);

        if (chapter.Title.IsNullOrEmpty()) return await Task.FromResult(Results.BadRequest("Invalid title."));
        if (chapter.Description.IsNullOrEmpty()) return await Task.FromResult(Results.BadRequest("Invalid description."));

        return await next(context);
    }
}
