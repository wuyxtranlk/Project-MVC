namespace StageSeven.Services.Accounts;

public interface IAccountService
{
    bool Login(string username, string password);
}
