namespace StageFive.Services.Geometries;

public class SquareService : IGeometryServices
{
    public double GetArea(GeometryInput input)
    {
        var s = input.Side.GetValueOrDefault();
        return s * s;
    }
}

