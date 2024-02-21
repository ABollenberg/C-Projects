/***************************************************
 * Name: Allie Bollenberg
 * Date: February 5, 2024
 * Assignment: Project
 *
 * Main application class.
*/
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class BudgetProjectTest
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\nAllie Bollenberg - Budget Project\n");

        // Sample usage of the classes
        User user = new User { UserID = "johnDoe", Username = "john_doe", Name = "John Doe", AccountNumber = "ABC123" };
        user.UpdateUserInfo("John M. Doe");

        // Displays the user's information
        Console.WriteLine("User Information:");
        Console.WriteLine("Name: {0}", user.Name);
        Console.WriteLine("Account Number: {0}", user.AccountNumber);

        UserDataAccess dataAccess = new UserDataAccess();
        
        // Adding a new budget
        Budget budget = new Budget { MonthlyIncome = 5000 };
        dataAccess.CreateUser(user, budget);

        // Adding Allie Bollenberg
        User allieUser = new User
        {
            UserID = "allbol6878",
            Username = "abollenberg",
            Name = "Allie Bollenberg",
            AccountNumber = "55442159"
        };
        dataAccess.CreateUser(allieUser, budget);

        // Adding another user
        User johnUser = new User
        {
            UserID = "john123",
            Username = "johnuser",
            Name = "John User",
            AccountNumber = "98765432"
        };
        dataAccess.CreateUser(johnUser, budget);

        // Adding another user
        User janeUser = new User
        {
            UserID = "jane543",
            Username = "JaneUser",
            Name = "Jane User",
            AccountNumber = "984541587"
        };
        dataAccess.CreateUser(janeUser, budget);

        // Now, you can use budgetB
        Budget budgetB = new Budget { MonthlyIncome = 5000 };
        budgetB.AddExpenseCategory(new ExpenseCategory { CategoryName = "Gas", BudgetedAmount = 80 });
        budgetB.AddExpenseCategory(new ExpenseCategory { CategoryName = "Rent", BudgetedAmount = 1200 });
        budgetB.AddExpenseCategory(new ExpenseCategory { CategoryName = "Utilities", BudgetedAmount = 200 });
        budgetB.AddExpenseCategory(new ExpenseCategory { CategoryName = "Groceries", BudgetedAmount = 100 });

        foreach (var category in budgetB.ExpenseCategories)
        {
            category.RecordExpense(category.BudgetedAmount);
        }

        BudgetSummary budgetSummary = new BudgetSummary { TotalExpenses = budget.CalculateMonthlyBalance(), MonthlyBalance = budget.CalculateMonthlyBalance() };
        budgetSummary.GenerateSummary();

        SavingsAccount savingsAccount = new SavingsAccount { AccountBalance = budget.CalculateMonthlyBalance(), InterestRate = 1.5 };
        savingsAccount.CalculateInterest();

        Console.WriteLine("Savings Account Balance: ${0} with Interest Rate: {1}%\n", savingsAccount.AccountBalance, savingsAccount.InterestRate);

        List<ExpenseReport> expenseReports = new List<ExpenseReport>();
        foreach (var category in budget.ExpenseCategories)
        {
            ExpenseReport report = new ExpenseReport { ReportID = expenseReports.Count + 1, ExpenseCategory = category, Expenses = new List<double> { category.ActualAmountSpent } };
            expenseReports.Add(report);
        }

        foreach (var report in expenseReports)
        {
            report.GenerateReport();
        }
    }
}
