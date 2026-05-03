namespace StageFive.Services.Calcs;

public class CalcService : ICalcService
{
    public double Multi(double a, double b) => a * b;
    public double Sum(double a, double b) => a + b;
}
