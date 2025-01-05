namespace Vander.Wallet.Service.Domain.BankAccounts;

public class BankAccount
{
    public Guid Id { get; }
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(Guid id, string owner)
    {
        Id = id;
        Owner = owner;
        Balance = 0;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }
        Balance += amount;
    }
}
