using MediatR;

namespace OmegaFY.Blog.Maui.App.ViewModels.Base;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    [ObservableProperty]
    private string viewTitle;

    public bool IsNotBusy => !IsBusy;

    protected readonly IMediator _mediator;

    protected BaseViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
}