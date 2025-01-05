using MediatR;
using Vander.Wallet.Service.CommandStack.Account.Handler;
using Vander.Wallet.Service.CommandStack.Deposit.Command;

namespace Vander.Wallet.Service.CommandStack.Deposit.Handler;

public class DepositHandler : IRequestHandler<DepositCommand, bool>
{
    public Task<bool> Handle(DepositCommand request, CancellationToken cancellationToken)
    {
        if (CreateAccountHandler._accounts.TryGetValue(request.AccountId, out var account))
        {
            account.Deposit(request.Amount);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}