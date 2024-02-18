using OmegaFY.Blog.Maui.App.Infra.Models;

namespace OmegaFY.Blog.Maui.App.Infra.Dialogs;

public interface IDialogProvider
{
    public Task<string> DisplayActionSheetAsync(DisplayActionSheetOptions options);

    public Task<bool> DisplayAlertAsync(DisplayAlertOptions options);

    public Task<bool> DisplayAlertAsync(DisplayAlertOptions options, Func<Task<bool>> funcDisplayDialog);

    public Task<bool> DisplayAlertAsync(DisplayAlertOptions options, Func<bool> funcDisplayDialog);

    public Task<string> DisplayPromptAsync(DisplayPromptOptions options);
}