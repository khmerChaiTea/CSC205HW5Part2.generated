﻿using Classes;

// Creating a new bank account with an initial balance
var account = new BankAccount("<Prem>", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

// Making a withdrawal and displaying the updated balance
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);

// Making a deposit and displaying the updated balance
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);

Console.WriteLine(account.GetAccountHistory());

// Creating a new bank account with an initial balance
var account2 = new BankAccount("<Tom>", 2000);
Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance} initial balance.");
