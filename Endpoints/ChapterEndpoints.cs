﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using dotnet_api.Models;
namespace dotnet_api.Endpoints;

public static class ChapterEndpoints
{
    public static void MapChapterEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Chapter").WithTags(nameof(Chapter));

        group.MapGet("/", async (NauciProgramiranjeDbContext db) =>
        {
            return await db.Chapters.ToListAsync();
        })
        .WithName("GetAllChapters")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Chapter>, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            return await db.Chapters.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Chapter model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetChapterById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Chapter chapter, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.Chapters
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, chapter.Id)
                  .SetProperty(m => m.Title, chapter.Title)
                  .SetProperty(m => m.Description, chapter.Description)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateChapter")
        .WithOpenApi();

        group.MapPost("/", async (Chapter chapter, NauciProgramiranjeDbContext db) =>
        {
            db.Chapters.Add(chapter);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Chapter/{chapter.Id}",chapter);
        })
        .WithName("CreateChapter")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.Chapters
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteChapter")
        .WithOpenApi();
    }
}
