namespace CakeMSSpec.Tests
{
    public class Account
    {
        public decimal Balance { get; private set; }

        public void Transfer(decimal amount, Account toAccount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                toAccount.Balance += amount;
            }
        }

        public Account(decimal balance) => Balance = balance;
    }
}
