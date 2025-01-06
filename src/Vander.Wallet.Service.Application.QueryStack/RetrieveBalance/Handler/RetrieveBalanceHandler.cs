using MediatR;
using Vander.Wallet.Service.Application.QueryStack.RetrieveBalance.Query;
using Vander.Wallet.Service.CommandStack.Wallet.Handler;

namespace Vander.Wallet.Service.Application.QueryStack.RetrieveBalance.Handler;

public class RetrieveBalanceHandler : IRequestHandler<RetrieveBalanceQuery, decimal?>
{
    public Task<decimal?> Handle(RetrieveBalanceQuery request, CancellationToken cancellationToken)
    {
        if (CreateWalletHandler._accounts.TryGetValue(request.AccountId, out var account))
        {
            return Task.FromResult<decimal?>(account.Balance);
        }
        return Task.FromResult<decimal?>(null);
    }
}