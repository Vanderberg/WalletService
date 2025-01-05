using MediatR;

namespace Vander.Wallet.Service.CommandStack.Deposit.Command;

public record DepositCommand : IRequest<bool>
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
}