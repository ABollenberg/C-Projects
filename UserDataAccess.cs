/***************************************************
 * Name: Allie Bollenberg
 * Date: February 12, 2024
 * Assignment: Project
 *
 * Public class UserDataAccess
*/

using System;
using System.Data.SQLite;

public class UserDataAccess
{
    private string connectionString = "Data Source=budgetProject.db;Version=3;";

    // This method creates a budget and returns the budgetID
    private int CreateBudget(Budget budget)
    {
        int budgetID = 0;

        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create the Budgets table if it doesn't exist
                using (SQLiteCommand createTableCmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Budgets " +
                    "(BudgetID INTEGER PRIMARY KEY AUTOINCREMENT, MonthlyIncome REAL)", connection))
                {
                    createTableCmd.ExecuteNonQuery();
                }

                // Insert a new budget into the Budgets table
                using (SQLiteCommand insertBudgetCmd = new SQLiteCommand("INSERT INTO Budgets (MonthlyIncome) VALUES (@MonthlyIncome); SELECT last_insert_rowid()", connection))
                {
                    insertBudgetCmd.Parameters.AddWithValue("@MonthlyIncome", budget.MonthlyIncome);

                    // ExecuteScalar to get the last inserted row ID
                    budgetID = Convert.ToInt32(insertBudgetCmd.ExecuteScalar());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating budget: {ex.Message}");
        }

        return budgetID;
    }

    // This method creates a user and associates it with a budget
public void CreateUser(User user, Budget budget)
{
    int budgetID = CreateBudget(budget);

    try
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Create the Users table if it doesn't exist
            using (SQLiteCommand createTableCmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Users " +
                "(UserID TEXT, " +
                "Username TEXT, " +
                "Name TEXT, " +
                "AccountNumber TEXT, " +
                "BudgetID INTEGER, " +
                "FOREIGN KEY(BudgetID) REFERENCES Budget(BudgetID))", connection))
            {
                createTableCmd.ExecuteNonQuery();
            }

            // Insert a new user into the Users table with associated BudgetID
            using (SQLiteCommand insertUserCmd = new SQLiteCommand("INSERT INTO Users " +
                "(UserID, Username, Name, AccountNumber, BudgetID) VALUES " +
                "(@UserID, @Username, @Name, @AccountNumber, @BudgetID)", connection))
            {
                insertUserCmd.Parameters.AddWithValue("@UserID", user.UserID);
                insertUserCmd.Parameters.AddWithValue("@Username", user.Username);
                insertUserCmd.Parameters.AddWithValue("@Name", user.Name);
                insertUserCmd.Parameters.AddWithValue("@AccountNumber", user.AccountNumber);
                insertUserCmd.Parameters.AddWithValue("@BudgetID", budgetID);

                insertUserCmd.ExecuteNonQuery();
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating user: {ex.Message}");
    }
}
}
