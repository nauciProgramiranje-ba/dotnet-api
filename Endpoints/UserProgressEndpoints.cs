using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using dotnet_api.Models;
namespace dotnet_api.Endpoints;

public static class UserProgressEndpoints
{
    public static void MapUserProgressEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/UserProgress").WithTags(nameof(UserProgress));

        group.MapGet("/", async (NauciProgramiranjeDbContext db) =>
        {
            return await db.UserProgresses.ToListAsync();
        })
        .WithName("GetAllUserProgresss")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<UserProgress>, NotFound>> (int questionid, NauciProgramiranjeDbContext db) =>
        {
            return await db.UserProgresses.AsNoTracking()
                .FirstOrDefaultAsync(model => model.QuestionId == questionid)
                is UserProgress model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUserProgressById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int questionid, UserProgress userProgress, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.UserProgresses
                .Where(model => model.QuestionId == questionid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.QuestionId, userProgress.QuestionId)
                  .SetProperty(m => m.UserId, userProgress.UserId)
                  .SetProperty(m => m.UserAnswer, userProgress.UserAnswer)
                  .SetProperty(m => m.IsCompleted, userProgress.IsCompleted)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUserProgress")
        .WithOpenApi();

        group.MapPost("/", async (UserProgress userProgress, NauciProgramiranjeDbContext db) =>
        {
            db.UserProgresses.Add(userProgress);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/UserProgress/{userProgress.QuestionId}",userProgress);
        })
        .WithName("CreateUserProgress")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int questionid, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.UserProgresses
                .Where(model => model.QuestionId == questionid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUserProgress")
        .WithOpenApi();
    }
}
