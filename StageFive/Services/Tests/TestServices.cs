namespace StageFive.Services.Tests;

public class TestServices : ITestServices
{
    public string GetFullname(string fullname) => $"hello {fullname}, this is my service";
    public string GetMessage() => "Hello, this is my service";
}
