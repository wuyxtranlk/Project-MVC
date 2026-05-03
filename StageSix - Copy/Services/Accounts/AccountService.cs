
namespace StageSix.Services.Accounts;

public class AccountService : IAccountService
{
    private static List<Account> Database { get; } = [];
    private readonly PasswordHasher<string> Hasher = new();
    public string Register(string username, string password)
    {
        if (Database.Any(a => a.Username == username))
        {
            return "Username already exists";
        }

        Account account = new()
        {
            Username = username,
            Password = Hasher.HashPassword(username, password)
        };

        Database.Add(account);
        return "Account registered successfully";
    }
    public bool Login(string username, string password)
    {
        Account? account = Database.FirstOrDefault(a => a.Username == username);
        if (account is null)
        {
            return false;
        }
        PasswordVerificationResult result = Hasher.VerifyHashedPassword(username, account.Password, password);
        return result == PasswordVerificationResult.Success;
    }
}
