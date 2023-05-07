using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using dotnet_api.Models;
namespace dotnet_api.Endpoints;

public static class LessonEndpoints
{
    public static void MapLessonEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Lesson").WithTags(nameof(Lesson));

        group.MapGet("/", async (NauciProgramiranjeDbContext db) =>
        {
            return await db.Lessons.ToListAsync();
        })
        .WithName("GetAllLessons")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Lesson>, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            return await db.Lessons.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Lesson model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLessonById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Lesson lesson, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.Lessons
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, lesson.Id)
                  .SetProperty(m => m.ChapterId, lesson.ChapterId)
                  .SetProperty(m => m.Title, lesson.Title)
                  .SetProperty(m => m.Description, lesson.Description)
                  .SetProperty(m => m.Video, lesson.Video)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLesson")
        .WithOpenApi();

        group.MapPost("/", async (Lesson lesson, NauciProgramiranjeDbContext db) =>
        {
            db.Lessons.Add(lesson);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Lesson/{lesson.Id}",lesson);
        })
        .WithName("CreateLesson")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.Lessons
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLesson")
        .WithOpenApi();
    }
}
