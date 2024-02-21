/***************************************************
 * Name: Allie Bollenberg
 * Date: February 5, 2024
 * Assignment: Project
 *
 * Public class SavingsAccount
*/

public class SavingsAccount
{
    public double AccountBalance { get; set; }
    public double InterestRate { get; set; }

    public void CalculateInterest()
    {
        // Calculate and update the account balance with interest
        double interest = AccountBalance * (InterestRate / 100);
        AccountBalance += interest;
    }
}