namespace Daemon.RazorUI.Color;

public struct TailwindColor {
    public string Name { get; set; } = "black";
    public int Intensity { get; set; } = 500;

    public TailwindColor(string name)
    {
        Name = name;
    }

    public TailwindColor(string name, int intensity)
    {
        Name = name;
        Intensity = intensity;
    }

    public override string ToString()
    {
        return $"{Name}-{Intensity}";
    }
}