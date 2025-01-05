using System.Collections.Concurrent;
using MediatR;
using Vander.Wallet.Service.CommandStack.Account.Command;
using Vander.Wallet.Service.Domain.BankAccounts;

namespace Vander.Wallet.Service.CommandStack.Account.Handler;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    public static readonly ConcurrentDictionary<Guid, BankAccount> _accounts = new();

    public Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new BankAccount(Guid.NewGuid(), request.Owner);
        _accounts[account.Id] = account;
        return Task.FromResult(account.Id);
    }
}