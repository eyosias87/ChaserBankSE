namespace ChasersBankSE
{
        public class Admin : User
        {
            public Admin(string username, string password) : base(username, password) { }

            public void CreateNewUser(string username, string password)
            {
                // Logic to add a new user to the system
            }

            public void UpdateExchangeRate(string currency, decimal newRate)
            {
                // Logic to update exchange rate
            }
        }
}


