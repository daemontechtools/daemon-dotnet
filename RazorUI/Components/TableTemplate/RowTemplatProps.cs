namespace Daemon.RazorUI.Components;


public struct RowTemplateProps {
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public string? MainImgSrc { get; set; }
    public bool IsMainImgRounded { get; set; } = false;

    public RowTemplateProps() {}
}
