/***************************************************
 * Name: Allie Bollenberg
 * Date: February 5, 2024
 * Assignment: Project
 *
 * Public class Budget.cs
*/

public class Budget
{
    public double MonthlyIncome { get; set; }
    public List<ExpenseCategory> ExpenseCategories { get; set; } = new List<ExpenseCategory>();

    public double CalculateMonthlyBalance()
    {
        double totalExpenses = 0;
        foreach (var category in ExpenseCategories)
        {
            totalExpenses += category.ActualAmountSpent;
        }

        return MonthlyIncome - totalExpenses;
    }

    public void AddExpenseCategory(ExpenseCategory category)
    {
        ExpenseCategories.Add(category);
    }
}