using Application.UserTransactions.Commands;
using Application.UserTransactions.Queries;
using Domain.UserTransaction;
using MediatR;
using WebAPI.Abstractions;
using WebAPI.Filters;

namespace WebAPI.EndpointDefinitions;

public class UserTransactionEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var chapters = app.MapGroup("/api/transactions");

        chapters.MapGet("/{id:guid}", GetUserTransactionById)
            .WithName("GetTransactionById");

        chapters.MapGet("/user={userId}", GetAllUserTransactions);

        chapters.MapGet("/user={userId}/getLatest", GetLatestUserTransaction);

        chapters.MapPost("/", CreateUserTransaction)
            .AddEndpointFilter<UserTransactionValidationFilter>();
    }

    private async Task<IResult> GetUserTransactionById(IMediator mediator, Guid id)
    {
        var getUserTransaction = new GetUserTransactionById { UserTransactionId = new UserTransactionId(id) };
        var transaction = await mediator.Send(getUserTransaction);

        return TypedResults.Ok(transaction);
    }

    private async Task<IResult> GetAllUserTransactions(IMediator mediator, string userId)
    {
        var getUserTransactions = new GetAllUserTransactions { UserId = userId };
        var transactions = await mediator.Send(getUserTransactions);

        return TypedResults.Ok(transactions);
    }

    private async Task<IResult> GetLatestUserTransaction(IMediator mediator, string userId)
    {
        var getUserTransaction = new GetLastTransaction();
        var transaction = await mediator.Send(getUserTransaction);

        return TypedResults.Ok(transaction);
    }

    private async Task<IResult> CreateUserTransaction(IMediator mediator, UserTransaction userTransaction)
    {
        var createUserTransaction = new CreateUserTransaction
        {
            UserId = userTransaction.UserId,
            Amount = userTransaction.Amount,
        };
        var createdUserTransaction = await mediator.Send(createUserTransaction);

        return TypedResults.Ok(createdUserTransaction);
    }
}
