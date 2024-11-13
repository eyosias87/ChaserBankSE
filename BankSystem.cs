using ChaserBankSE;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChasersBankSE
{
    public class BankSystem
    {
        private List<User> users;
        private List<BankAccount> accounts;
        private List<Transaction> transactionLog;
        private System.Threading.Timer transactionTimer;
        private Queue<Transaction> pendingTransactions;
        private List<BankAccount> accountList; // Changed from Account to BankAccount
        private List<Transaction> transactionHistory;

        // Constructor
        public BankSystem()
        {
            users = new List<User>();
            accounts = new List<BankAccount>();
            transactionLog = new List<Transaction>();
            pendingTransactions = new Queue<Transaction>();
            accountList = new List<BankAccount>(); // Simplified collection initialization
            transactionHistory = new List<Transaction>(); // Simplified collection initialization

            // Set up the timer for scheduled transactions
            transactionTimer = new System.Threading.Timer(ProcessScheduledTransactions, null, 0, 180000); // 3 minutes in milliseconds
        }

        // Display Main Menu
        public void DisplayMainMenu()
        {
            Console.WriteLine("1. Login as Administrator");
            Console.WriteLine("2. Login as Customer");
            Console.WriteLine("3. Exit");
            // Implement login and main options based on user selection
        }

        // Display Customer Menu
        public void DisplayCustomerMenu()
        {
            Console.WriteLine("Customer Menu:");
            Console.WriteLine("1. View Account Summary");
            Console.WriteLine("2. Transfer Funds");
            Console.WriteLine("3. Open New Account");
            // Add additional customer options here
        }

        // Display Admin Menu
        public void DisplayAdminMenu()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Create New User");
            Console.WriteLine("2. View All User Accounts");
            Console.WriteLine("3. Update Exchange Rates");
            // Add additional admin options here
        }

        // Method to Transfer Funds
        public bool TransferFunds(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            // Assuming we have methods to get accounts by account number
            BankAccount fromAccount = GetAccountByNumber(fromAccountNumber);
            BankAccount toAccount = GetAccountByNumber(toAccountNumber);

            if (fromAccount == null || toAccount == null)
            {
                return false; // One or both accounts do not exist
            }

            if (fromAccount.Balance < amount)
            {
                return false; // Insufficient funds
            }

            // Use the TransferTo method to transfer funds
            bool success = fromAccount.TransferTo(toAccount, amount);
            if (success)
            {
                // Log the transaction
                var transaction = new Transaction(fromAccountNumber, toAccountNumber, amount, DateTime.Now, "Fund Transfer");
                transactionLog.Add(transaction);
            }

            return success; // Return the result of the transfer
        }

        // Method to get account by account number
        private BankAccount GetAccountByNumber(string accountNumber)
        {
            return accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);
        }

        // Method to process scheduled transactions
        private void ProcessScheduledTransactions(object? state)
        {
            // Implementation here
        }

        internal void InitializeValues()
        {
            accountList = new List<BankAccount>(); // Changed from Account to BankAccount
            transactionHistory = new List<Transaction>();
            // Add more initialization as needed
        }

        internal void InitializeTimer()
        {
            throw new NotImplementedException();
        }
    }
}
