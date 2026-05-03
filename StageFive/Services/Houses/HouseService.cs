using StageFive.Services.Calcs;

namespace StageFive.Services.Houses;

public class HouseService(ICalcService calcService) : IHouseService
{
    public double Area(double x, double y) => calcService.Multi(x, y);
    public double Perimeter(double x, double y) => calcService.Sum(x, y) * 2;
}
