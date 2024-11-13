namespace ChaserBankSE
{
    
        public class BankAccount
        {
            public string AccountNumber { get; set; }
            public decimal Balance { get; private set; }

            public BankAccount(string accountNumber, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
            }

        public bool TransferTo(BankAccount targetAccount, decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                targetAccount.Balance += amount;
                return true;
            }
            return false;
        }
            public void Deposit(decimal amount)
            {
                Balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (Balance >= amount)
                    Balance -= amount;
                else
                    throw new InvalidOperationException("Insufficient funds.");
            }
        }
}


