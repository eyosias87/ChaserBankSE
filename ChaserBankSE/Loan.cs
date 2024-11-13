namespace ChasersBankSE
{
    public class Loan
    {
        public decimal Principal { get; private set; }
        public decimal InterestRate { get; private set; }
        public int TermInMonths { get; private set; }

        public Loan(decimal principal, decimal interestRate, int termInMonths)
        {
            Principal = principal;
            InterestRate = interestRate;
            TermInMonths = termInMonths;
        }

        public decimal CalculateMonthlyPayment()
        {
            decimal monthlyRate = InterestRate / 12 / 100;
            decimal denominator = (decimal)(1 - Math.Pow(1 + (double)monthlyRate, -TermInMonths));
            return Principal * monthlyRate / denominator;
        }

        public decimal TotalRepayment => CalculateMonthlyPayment() * TermInMonths;
    }
}
