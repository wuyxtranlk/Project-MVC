using Microsoft.AspNetCore.Identity;
using StageSeven.Models;

namespace StageSeven.Services.Accounts;

public class AccountService : IAccountService
{
    private static List<Account> Database { get; } = [];
    private readonly PasswordHasher<string> Hasher = new();
    public bool CheckLogin(string username, string password) => username == "sa" && password == "1234567";

    public bool Login(string username, string password)
    {
        if (username == "sa" && password == "1234567")
        {
            return true;
        }
        Account? account = Database.FirstOrDefault(a => a.Username == username);
        if (account is null)
        {
            return false;
        }
        PasswordVerificationResult result = Hasher.VerifyHashedPassword(username, account.Password, password);
        return result == PasswordVerificationResult.Success;
    }
}