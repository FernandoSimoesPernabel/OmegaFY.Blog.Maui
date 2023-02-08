using OmegaFY.Blog.Maui.App.Infra.Models;

namespace OmegaFY.Blog.Maui.App.Infra.Dialog.Implementations;

internal class MainPageDialog : IDialogProvider
{
    public async Task<string> DisplayActionSheetAsync(DisplayActionSheetOptions options)
    {
        return await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayActionSheet(
            options.Title,
            options.Cancel,
            options.Destruction,
            options.FlowDirection,
            options.Buttons);
    }

    public async Task<bool> DisplayAlertAsync(DisplayAlertOptions options)
    {
        return await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(
            options.Title,
            options.Message,
            options.Ok,
            options.Cancel);
    }

    public async Task<bool> DisplayAlertAsync(DisplayAlertOptions options, Func<Task<bool>> funcDisplayAlertDialog)
    {
        bool shouldDisplayAlertDialog = await funcDisplayAlertDialog();

        while (shouldDisplayAlertDialog)
        {
            if (!await DisplayAlertAsync(options))
                return false;

            shouldDisplayAlertDialog = await funcDisplayAlertDialog();
        }

        return true;
    }

    public async Task<bool> DisplayAlertAsync(DisplayAlertOptions options, Func<bool> funcDisplayAlertDialog)
    {
        bool shouldDisplayAlertDialog = funcDisplayAlertDialog();

        while (shouldDisplayAlertDialog)
        {
            if (!await DisplayAlertAsync(options))
                return false;

            shouldDisplayAlertDialog = funcDisplayAlertDialog();
        }

        return true;
    }

    public async Task<string> DisplayPromptAsync(DisplayPromptOptions options)
    {
        return await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayPromptAsync(
            options.Title,
            options.Message,
            options.Accept,
            options.Cancel,
            options.Placeholder,
            options.MaxLenght,
            options.Keyboard,
            options.InitialValue);
    }
}