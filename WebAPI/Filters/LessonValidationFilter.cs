using Domain.Lesson;

namespace WebAPI.Filters;

public class LessonValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var lesson = context.GetArgument<Lesson>(1);

        if (string.IsNullOrEmpty(lesson.Title)) return await Task.FromResult(Results.BadRequest("Invalid title."));
        if (string.IsNullOrEmpty(lesson.Description)) return await Task.FromResult(Results.BadRequest("Invalid description."));
        if (string.IsNullOrEmpty(lesson.VideoUrl.ToString())) return await Task.FromResult(Results.BadRequest("Invalid lesson video url."));

        return await next(context);
    }
}
