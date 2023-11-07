using Microsoft.AspNetCore.Components;


namespace Daemon.RazorUI.Modal;


public struct ModalContentInput
{

    //TODO: set defaults?
    public string? Color { get; set; }
    public Type? IconType { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Func<bool, Task> OnConfirm { get; set; }
}
