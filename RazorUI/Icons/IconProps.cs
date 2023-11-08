using Daemon.RazorUI.Color;

namespace Daemon.RazorUI.Icons;


public struct IconProps {
    public TailwindColor? Color { get; set; }
    public TailwindColor? HoverColor { get; set; }
    public string? Transition { get; set; }

    public IconProps() {}

    public string ToClass() 
    {
        return $"{(Color != null ? $"stroke-{Color?.Name}-{Color?.Intensity}" : string.Empty)} {(HoverColor != null ? $"hover:stroke-{HoverColor?.Name}-{HoverColor?.Intensity}" : string.Empty)} {(Transition != null ? Transition : string.Empty)}".Trim();
    }
}