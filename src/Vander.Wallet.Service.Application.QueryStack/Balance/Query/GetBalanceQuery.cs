using MediatR;

namespace Vander.Wallet.Service.Application.QueryStack.Balance.Query;

public record GetBalanceQuery : IRequest<decimal?>
{
    public Guid AccountId { get; set; }
}