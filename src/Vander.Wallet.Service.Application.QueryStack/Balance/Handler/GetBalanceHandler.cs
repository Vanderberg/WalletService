using MediatR;
using Vander.Wallet.Service.Application.QueryStack.Balance.Query;
using Vander.Wallet.Service.CommandStack.Account.Handler;

namespace Vander.Wallet.Service.Application.QueryStack.Balance.Handler;

public class GetBalanceHandler : IRequestHandler<GetBalanceQuery, decimal?>
{
    public Task<decimal?> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
    {
        if (CreateAccountHandler._accounts.TryGetValue(request.AccountId, out var account))
        {
            return Task.FromResult<decimal?>(account.Balance);
        }
        return Task.FromResult<decimal?>(null);
    }
}