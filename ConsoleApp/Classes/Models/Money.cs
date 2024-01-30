namespace ConsoleApp.Classes.Models
{
    public class Money
    {
        private readonly decimal amount;
        private readonly decimal currency;

        public Money(decimal amount, decimal currency)
        {
            if (currency == 0)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            this.amount = amount;
            this.currency = currency;
        }
    }
}
