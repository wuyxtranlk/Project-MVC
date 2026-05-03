namespace StageFive.Services.Geometries;

public class CircleService : IGeometryServices
{
    public double GetArea(GeometryInput input)
    {
        var r = input.Radius;
        return r.HasValue ? Math.PI * r.Value : 0;
    }
}
