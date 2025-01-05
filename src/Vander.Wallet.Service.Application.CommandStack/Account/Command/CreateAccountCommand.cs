using MediatR;

namespace Vander.Wallet.Service.CommandStack.Account.Command;

public record CreateAccountCommand(string Owner) : IRequest<Guid>;