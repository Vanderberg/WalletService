using Vander.Wallet.Service.Domain.Enums;

namespace Vander.Wallet.Service.Domain.Wallets;

public class Wallet
{
    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public string Description { get; private set; }
    public WalletStatus Status { get; private set; }
    public decimal Balance { get; private set; }
    
    private DateTime CreatedAt = DateTime.Now;
    private DateTime UpdatedAt;
    
    public void SetLastUpdated()
    {
        UpdatedAt = DateTime.Now;
    }
    
    public Wallet(Guid id, Guid clientId, string description)
    {
        Id = id;
        ClientId = clientId;
        Description = description;
        Balance = 0;
    }
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        
        Balance += amount;
    }
}