using OmegaFY.Blog.Maui.App.ViewModels.Base;

namespace OmegaFY.Blog.Maui.App.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    public MainPageViewModel()
    {
        ViewTitle = "Main Page";
    }

    [RelayCommand]
    public Task LoginAsync()
    {
        return Task.CompletedTask;
    }

    [RelayCommand]
    public Task RegisterNewUserAsync()
    {
        return Task.CompletedTask;
    }
}
