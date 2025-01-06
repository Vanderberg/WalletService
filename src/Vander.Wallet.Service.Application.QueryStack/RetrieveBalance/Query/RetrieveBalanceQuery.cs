using MediatR;

namespace Vander.Wallet.Service.Application.QueryStack.RetrieveBalance.Query;

public record RetrieveBalanceQuery : IRequest<decimal?>
{
    public Guid AccountId { get; set; }
}