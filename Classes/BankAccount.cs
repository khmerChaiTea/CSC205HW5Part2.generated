namespace Classes
{
    // Represents a bank account
    public class BankAccount
    {
        // Static field to keep track of the account number seed (used to generate unique account numbers)
        private static int s_accountNumberSeed = 1234567890;

        // Public properties to expose account details
        public string Number { get; }  // Account number
        public string Owner { get; set; }  // Account owner
        public decimal Balance  // Account balance, calculated based on transactions
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;  // Summing up all transaction amounts
                }
                return balance;
            }
        }

        // ConstructorModifications
        private readonly decimal _minimumBalance;

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        // Constructor to initialize the account with an owner and an initial balance
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            Number = s_accountNumberSeed.ToString();    // Assigns a unique account number
            s_accountNumberSeed++;  // Increments the account number seed for the next account

            Owner = name;
            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");   // Adds the initial balance as the first transaction
        }

        // Private field to store all transactions associated with the account
        private List<Transaction> _allTransactions = new List<Transaction>();

        // Method to make a deposit into the account
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");  // Validates that the deposit amount is positive
            }
            var deposit = new Transaction(amount, date, note);  // Creates a new transaction for the deposit
            _allTransactions.Add(deposit);  // Adds the deposit transaction to the list
        }

        // RefactoredMakeWithdrawal
        // Method to make a withdrawal from the account
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            Transaction? withdrawal = new(-amount, date, note);
            _allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                _allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }

        // Method to get the history of all transactions on the account
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\t\tBalance\t\tNote");  // Header for the transaction report
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;  // Running balance
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount, 10:F2}\t{balance, 10:F2}\t{item.Notes}");  // Appends each transaction to the report
            }

            return report.ToString();  // Returns the complete transaction history as a string
        }

        // DeclareMonthEndTransactions
        public virtual void PerformMonthEndTransactions() { }
    }
}
