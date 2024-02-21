/***************************************************
 * Name: Allie Bollenberg
 * Date: February 5, 2024
 * Assignment: Project
 *
 * Public class BudgetSummary
*/

public class BudgetSummary
{
    public double TotalExpenses { get; set; }
    public double MonthlyBalance { get; set; }

    public void GenerateSummary()
    {
        // Generate and display the summary
        Console.WriteLine("\nTotal Expenses: ${0}\n", TotalExpenses);
        Console.WriteLine("Monthly Income After Bills: ${0}\n", MonthlyBalance);
    }
}