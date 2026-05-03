namespace StageSeven.Services.Accounts;

public interface IAccountService
{
    string Register(string username, string password);
    bool Login(string username, string password);
}
