using MediatR;
using OmegaFY.Blog.Maui.App.Infra.Navigation;

namespace OmegaFY.Blog.Maui.App.ViewModels.Base;

public abstract partial class BaseViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    [ObservableProperty]
    private string viewTitle;

    public bool IsNotBusy => !IsBusy;

    protected readonly INavigationProvider _navigationProvider;

    protected BaseViewModel(INavigationProvider navigationProvider, string viewTitle)
    {
        ViewTitle = viewTitle;

        _navigationProvider = navigationProvider;
    }

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query) { }

    public virtual async Task InitializeAsync()
    {
        IsBusy = true;

        await InternalInitializeAsync();

        IsBusy = false;
    }

    protected virtual Task InternalInitializeAsync() => Task.CompletedTask;
}