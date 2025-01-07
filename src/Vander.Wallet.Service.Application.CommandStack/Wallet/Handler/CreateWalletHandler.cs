using System.Collections.Concurrent;
using MediatR;
using Vander.Wallet.Service.CommandStack.Wallet.Command;

namespace Vander.Wallet.Service.CommandStack.Wallet.Handler;

public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, Guid>
{
    public static readonly ConcurrentDictionary<Guid, Domain.Wallets.Wallet> _accounts = new();

    public Task<Guid> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = new Domain.Wallets.Wallet(Guid.NewGuid(), request.ClientId, request.Description);
        _accounts[wallet.Id] = wallet;
        return Task.FromResult(wallet.Id);
    }
}