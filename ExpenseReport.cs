/***************************************************
 * Name: Allie Bollenberg
 * Date: February 5, 2024
 * Assignment: Project
 *
 * Public class ExpenseReport
*/

public class ExpenseReport
{
    // Make ExpenseCategory nullable
    public ExpenseCategory? ExpenseCategory { get; set; }

    // Rest of the class remains the same
    public int ReportID { get; set; }
    public List<double> Expenses { get; set; } = new List<double>();

    public void GenerateReport()
    {
        // Generate and display the detailed report
        Console.WriteLine("Detailed Expense Report - {0}:\n", ExpenseCategory?.CategoryName);
        for (int i = 0; i < Expenses.Count; i++)
        {
            Console.WriteLine("\t>> Expense ID: {0}\n", i + 1);
            Console.WriteLine("\t>> Amount Spent: ${0}\n", Expenses[i]);
        }
    }
}