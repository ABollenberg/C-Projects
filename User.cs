/***************************************************
 * Name: Allie Bollenberg
 * Date: February 5, 2024
 * Assignment: Project
 *
 * Public class User
*/

public class User
{
    public string UserID { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string AccountNumber { get; set; }

    // Default constructor to initialize properties
    public User()
    {
        UserID = string.Empty;
        Username = string.Empty;
        Name = string.Empty;
        AccountNumber = string.Empty;
    }

    public void UpdateUserInfo(string newName)
    {
        Name = newName;
    }
}
