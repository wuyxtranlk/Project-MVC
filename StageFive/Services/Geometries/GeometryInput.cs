namespace StageFive.Services.Geometries;

public record GeometryInput
{
    public double? Side { get; init; } // cạnh hình vuông
    public double? Length { get; init; } // chiều dài hình chữ nhật
    public double? Width { get; init; } // chiều rộng hình chữ nhật
    public double? Radius { get; init; } // bán kính hình tròn
}
