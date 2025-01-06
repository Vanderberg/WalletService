using MediatR;
using Vander.Wallet.Service.CommandStack.DepositFund.Command;
using Vander.Wallet.Service.CommandStack.Wallet.Handler;

namespace Vander.Wallet.Service.CommandStack.DepositFund.Handler;

public class DepositHandler : IRequestHandler<DepositFundCommand, bool>
{
    public Task<bool> Handle(DepositFundCommand request, CancellationToken cancellationToken)
    {
        if (CreateWalletHandler._accounts.TryGetValue(request.AccountId, out var account))
        {
            account.Deposit(request.Amount);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}