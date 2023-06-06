using Domain.UserTransaction;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Filters;

public class UserTransactionValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var userTransaction = context.GetArgument<UserTransaction>(1);

        if(userTransaction.UserId.IsNullOrEmpty()) return await Task.FromResult(Results.BadRequest("Invalid UserID."));
        if(userTransaction.Amount < 0) return await Task.FromResult(Results.BadRequest("Invalid amount."));

        return await next(context);
    }
}
