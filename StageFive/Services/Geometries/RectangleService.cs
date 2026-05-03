namespace StageFive.Services.Geometries;

public class RectangleService : IGeometryServices
{
    public double GetArea(GeometryInput input) => (input.Length ?? 0) * (input.Width ?? 0);
}
