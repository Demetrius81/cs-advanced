namespace Lesson3;

public record struct Point(int coordX, int coordY, int coordZ)
{
    public override readonly string? ToString() => $"X: {coordX}, Y: {coordY}, Z: {coordZ}";
}
