public class Spot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double? Accuracy { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Label { get; set; }
    public string? Address { get; set; }
    public int? Number { get; set; }
}