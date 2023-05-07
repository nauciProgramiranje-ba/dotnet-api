using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using dotnet_api.Models;
namespace dotnet_api.Endpoints;

public static class QuestionEndpoints
{
    public static void MapQuestionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Question").WithTags(nameof(Question));

        group.MapGet("/", async (NauciProgramiranjeDbContext db) =>
        {
            return await db.Questions.ToListAsync();
        })
        .WithName("GetAllQuestions")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Question>, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            return await db.Questions.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Question model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetQuestionById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Question question, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.Questions
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, question.Id)
                  .SetProperty(m => m.LessonId, question.LessonId)
                  .SetProperty(m => m.Prompt, question.Prompt)
                  .SetProperty(m => m.Answer, question.Answer)
                  .SetProperty(m => m.CodeQuestion, question.CodeQuestion)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateQuestion")
        .WithOpenApi();

        group.MapPost("/", async (Question question, NauciProgramiranjeDbContext db) =>
        {
            db.Questions.Add(question);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Question/{question.Id}",question);
        })
        .WithName("CreateQuestion")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.Questions
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteQuestion")
        .WithOpenApi();
    }
}
