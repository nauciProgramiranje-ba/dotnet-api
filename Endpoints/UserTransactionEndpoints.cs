using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using dotnet_api.Models;
namespace dotnet_api.Endpoints;

public static class UserTransactionEndpoints
{
    public static void MapUserTransactionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/UserTransaction").WithTags(nameof(UserTransaction));

        group.MapGet("/", async (NauciProgramiranjeDbContext db) =>
        {
            return await db.UserTransactions.ToListAsync();
        })
        .WithName("GetAllUserTransactions")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<UserTransaction>, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            return await db.UserTransactions.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is UserTransaction model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUserTransactionById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, UserTransaction userTransaction, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.UserTransactions
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, userTransaction.Id)
                  .SetProperty(m => m.UserId, userTransaction.UserId)
                  .SetProperty(m => m.PaidDate, userTransaction.PaidDate)
                  .SetProperty(m => m.PaidAmount, userTransaction.PaidAmount)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUserTransaction")
        .WithOpenApi();

        group.MapPost("/", async (UserTransaction userTransaction, NauciProgramiranjeDbContext db) =>
        {
            db.UserTransactions.Add(userTransaction);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/UserTransaction/{userTransaction.Id}",userTransaction);
        })
        .WithName("CreateUserTransaction")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, NauciProgramiranjeDbContext db) =>
        {
            var affected = await db.UserTransactions
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUserTransaction")
        .WithOpenApi();
    }
}
