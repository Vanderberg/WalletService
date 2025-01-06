using MediatR;

namespace Vander.Wallet.Service.CommandStack.DepositFund.Command;

public record DepositFundCommand : IRequest<bool>
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
}