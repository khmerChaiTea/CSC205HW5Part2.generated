namespace Classes
{
    // Represents a financial transaction (either a deposit or withdrawal)
    public class Transaction
    {
        // Public properties to expose transaction details
        public decimal Amount { get; }  // The amount of the transaction
        public DateTime Date { get; }  // The date of the transaction
        public string Notes { get; }  // Notes or description of the transaction

        // Constructor to initialize a new transaction with a specified amount, date, and note
        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;  // Sets the amount of the transaction
            Date = date;  // Sets the date of the transaction
            Notes = note;  // Sets the notes or description of the transaction
        }
    }
}
