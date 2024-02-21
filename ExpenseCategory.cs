/***************************************************
 * Name: Allie Bollenberg
 * Date: February 5, 2024
 * Assignment: Project
 *
 * Public class ExpenseCategory
*/

public class ExpenseCategory
{
    // Initialize CategoryName in the constructor
    public ExpenseCategory()
    {
        CategoryName = string.Empty; // Set an appropriate default value
    }

    public string CategoryName { get; set; }
    public double BudgetedAmount { get; set; }
    public double ActualAmountSpent { get; set; }

    public void RecordExpense(double amount)
    {
        ActualAmountSpent += amount;
    }
}