using Microsoft.AspNetCore.Components;


namespace Daemon.RazorUI.Components;

public abstract class DaemonComponentBase : ComponentBase {

    [Parameter]
    public string? Class { get; set; }

    protected string DefaultClass { get; set; } = "";
}