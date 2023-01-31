using OmegaFY.Blog.Maui.App.Infra.Enums;

namespace OmegaFY.Blog.Maui.App.Infra.Storage.PreferencesStorage;

public interface IUserPreferencesProvider
{
    public void ClearPreferences();

    public bool ContainsPreference(PreferencesKey preference);

    public T GetPreference<T>(PreferencesKey preference);

    public void RemovePreference(PreferencesKey preference);

    public void SetPreference<T>(PreferencesKey preference, T value);
}