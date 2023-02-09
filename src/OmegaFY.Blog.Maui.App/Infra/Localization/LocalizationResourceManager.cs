using OmegaFY.Blog.Maui.App.Resources.Localization;
using System.ComponentModel;
using System.Globalization;

namespace OmegaFY.Blog.Maui.App.Infra.Localization;

public class LocalizationResourceManager : INotifyPropertyChanged
{
    public static LocalizationResourceManager Instance { get; } = new();

    public event PropertyChangedEventHandler PropertyChanged;

    private LocalizationResourceManager() => AppLocalizationResources.Culture = CultureInfo.CurrentCulture;

    public void SetCulture(CultureInfo culture)
    {
        AppLocalizationResources.Culture = culture;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }

    public object this[string resourceKey] => AppLocalizationResources.ResourceManager.GetObject(resourceKey, AppLocalizationResources.Culture);
}