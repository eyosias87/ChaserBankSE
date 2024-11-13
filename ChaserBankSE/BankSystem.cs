using ChaserBankSE;
using System.Timers;

namespace ChasersBankSE
{
    public class BankSystem
    {
        private List<User> users;
        private List<BankAccount> accounts;
        private List<Transaction> transactionLog;
        private Queue<Transaction> pendingTransactions;
        private System.Threading.Timer transactionTimer;

        // Constructor
        public BankSystem()
        {
            users = new List<User>();
            accounts = new List<BankAccount>();
            transactionLog = new List<Transaction>();
            pendingTransactions = new Queue<Transaction>();

            InitializeData();

            // Set up the timer for scheduled transactions
            transactionTimer = new System.Threading.Timer(ProcessScheduledTransactions, null, 0, 180000); // 3 minutes in milliseconds
        }

        private void InitializeData()
        {
            // Add default users and accounts for testing purposes
            users.Add(new User("admin", "password"));
            users.Add(new User("customer", "password"));

            accounts.Add(new BankAccount("12345", 1000));  // Checking account for testing
            accounts.Add(new BankAccount("67890", 5000));  // Savings account for testing
        }

        // Display Main Menu
        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to ChaserBankSE!");
            Console.WriteLine("1. Login as Administrator");
            Console.WriteLine("2. Login as Customer");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AdminLogin();
                    break;
                case "2":
                    CustomerLogin();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    DisplayMainMenu();  // Recurse to show the menu again
                    break;
            }
        }

        // Placeholder method for Admin Login
        private void AdminLogin()
        {
            Console.WriteLine("Logging in as Admin...");
            // Implement admin login validation here
            DisplayAdminMenu();
        }

        // Placeholder method for Customer Login
        private void CustomerLogin()
        {
            Console.WriteLine("Logging in as Customer...");
            // Implement customer login validation here
            DisplayCustomerMenu();
        }

        // Display Customer Menu
        public void DisplayCustomerMenu()
        {
            Console.WriteLine("Customer Menu:");
            Console.WriteLine("1. View Account Summary");
            Console.WriteLine("2. Transfer Funds");
            Console.WriteLine("3. Open New Account");
            Console.WriteLine("4. Back to Main Menu");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Call method to view account summary
                    break;
                case "2":
                    // Call method to transfer funds
                    break;
                case "3":
                    // Call method to open a new account
                    break;
                case "4":
                    DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    DisplayCustomerMenu();
                    break;
            }
        }

        // Display Admin Menu
        public void DisplayAdminMenu()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Create New User");
            Console.WriteLine("2. View All User Accounts");
            Console.WriteLine("3. Update Exchange Rates");
            Console.WriteLine("4. Back to Main Menu");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Call method to create new user
                    break;
                case "2":
                    // Call method to view all accounts
                    break;
                case "3":
                    // Call method to update exchange rates
                    break;
                case "4":
                    DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    DisplayAdminMenu();
                    break;
            }
        }

        // Transfer Funds
        public bool TransferFunds(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            BankAccount fromAccount = GetAccountByNumber(fromAccountNumber);
            BankAccount toAccount = GetAccountByNumber(toAccountNumber);

            if (fromAccount == null || toAccount == null || fromAccount.Balance < amount)
            {
                Console.WriteLine("Transfer failed. Please check account details or balance.");
                return false;
            }

            bool success = fromAccount.TransferTo(toAccount, amount);
            if (success)
            {
                var transaction = new Transaction(fromAccountNumber, toAccountNumber, amount, DateTime.Now, "Fund Transfer");
                transactionLog.Add(transaction);
                Console.WriteLine("Transfer successful.");
            }
            return success;
        }

        // Retrieve Account by Number
        private BankAccount GetAccountByNumber(string accountNumber)
        {
            return accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);
        }

        // Scheduled Transactions Processing
        private void ProcessScheduledTransactions(object state)
        {
            while (pendingTransactions.Count > 0)
            {
                var transaction = pendingTransactions.Dequeue();
                LogTransaction(transaction);
            }
        }

        // Log Transaction
        private void LogTransaction(Transaction transaction)
        {
            transactionLog.Add(transaction);
            Console.WriteLine($"Transaction logged: {transaction.Description} - {transaction.Amount:C}");
        }
    }
}
