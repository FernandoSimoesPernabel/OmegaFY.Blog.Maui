namespace OmegaFY.Blog.Maui.App.ViewModels.Base;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    [ObservableProperty]
    private string viewTitle;

    public bool IsNotBusy => !IsBusy;
}