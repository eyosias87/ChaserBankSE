namespace ChasersBankSE
    {
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public int LoginAttempts { get; private set; }
            public bool IsLockedOut => LoginAttempts >= 3;

            public User(string username, string password)
            {
                Username = username;
                Password = password;
                LoginAttempts = 0;
            }

            public bool VerifyPassword(string inputPassword)
            {
            if (IsLockedOut)
            {
                Console.WriteLine("Account is locked due to multiple failed login attempts.");
                return false;
            }

            if (Password == inputPassword)
                {
                    LoginAttempts = 0; // Reset attempts on successful login
                return true;
                }
                else
                {
                    LoginAttempts++;
                    if (IsLockedOut)
                    {
                    Console.WriteLine("Account is now locked due to three failed login attempts.");
                    }
                    return false;
                }
            }
        }
}


