using OmegaFY.Blog.Maui.App.Infra.Enums;
using OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage;

namespace OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage.Implementations;

internal class DefaultPreferenceStorage : IUserPreferencesProvider
{
    private readonly IPreferences _preferencesStorage;

    private readonly Dictionary<PreferencesKey, object> _preferencesCache = new();

    public DefaultPreferenceStorage(IPreferences preferencesStorage) => _preferencesStorage = preferencesStorage;

    public void ClearPreferences()
    {
        _preferencesStorage.Clear();
        _preferencesCache.Clear();
    }

    public bool ContainsPreference(PreferencesKey preference)
    {
        if (_preferencesCache.ContainsKey(preference)) return true;

        return _preferencesStorage.ContainsKey(preference.ToString());
    }

    public T GetPreference<T>(PreferencesKey preference)
    {
        if (_preferencesCache.TryGetValue(preference, out var value))
            return (T)value;

        return _preferencesStorage.Get<T>(preference.ToString(), default);
    }

    public void RemovePreference(PreferencesKey preference)
    {
        _preferencesStorage.Remove(preference.ToString());
        _preferencesCache.Remove(preference);
    }

    public void SetPreference<T>(PreferencesKey preference, T value)
    {
        _preferencesStorage.Set(preference.ToString(), value);
        _preferencesCache.TryAdd(preference, value);
    }
}