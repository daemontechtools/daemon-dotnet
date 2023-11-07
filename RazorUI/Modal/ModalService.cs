using Microsoft.AspNetCore.Components;


namespace Daemon.RazorUI.Modal;

// Show needs to be set AFTER animations are finished
// We need to know from the implementation of ModalContent (Delete Confirmation)
// how long the delay will be
public class ModalService
{
    public ModalContentInput? ContentInput { get; set; }
    private bool _show = false;

    private void SetShow(bool show, ModalContentInput? contentInput = null)
    {
        ContentInput = contentInput;
        _show = show;
        if(OnStateChange != null) OnStateChange.Invoke(this, show);
    }
    public bool Visible { get => _show; }

    public EventHandler<bool>? OnStateChange;

    public void Show(ModalContentInput contentInput)
    {
        SetShow(true, contentInput);
    }

    public void Hide()
    {
        SetShow(false);
    }
}

