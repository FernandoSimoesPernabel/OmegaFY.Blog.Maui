using OmegaFY.Blog.Maui.App.Infra.Enums;

namespace OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage;

public interface IUserPreferencesProvider
{
    public void ClearAll();

    public bool Contains(PreferencesKey preference);

    public T Get<T>(PreferencesKey preference);

    public void Remove(PreferencesKey preference);

    public void Set<T>(PreferencesKey preference, T value);
}