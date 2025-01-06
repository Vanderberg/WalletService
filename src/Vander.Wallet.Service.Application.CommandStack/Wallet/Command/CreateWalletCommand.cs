using MediatR;

namespace Vander.Wallet.Service.CommandStack.Wallet.Command;

public record CreateWalletCommand(Guid ClientId, string Description) : IRequest<Guid>;