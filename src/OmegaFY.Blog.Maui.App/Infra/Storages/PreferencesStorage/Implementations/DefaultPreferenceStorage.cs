using OmegaFY.Blog.Maui.App.Infra.Enums;

namespace OmegaFY.Blog.Maui.App.Infra.Storages.PreferencesStorage.Implementations;

internal class DefaultPreferenceStorage : IUserPreferencesProvider
{
    private readonly IPreferences _preferencesStorage;

    private readonly Dictionary<PreferencesKey, object> _preferencesCache = new();

    public DefaultPreferenceStorage(IPreferences preferencesStorage) => _preferencesStorage = preferencesStorage;

    public void ClearAll()
    {
        _preferencesStorage.Clear();
        _preferencesCache.Clear();
    }

    public bool Contains(PreferencesKey preference)
    {
        if (_preferencesCache.ContainsKey(preference)) return true;

        return _preferencesStorage.ContainsKey(preference.ToString());
    }

    public T Get<T>(PreferencesKey preference)
    {
        if (_preferencesCache.TryGetValue(preference, out object value))
            return (T)value;

        return _preferencesStorage.Get<T>(preference.ToString(), default);
    }

    public void Remove(PreferencesKey preference)
    {
        _preferencesStorage.Remove(preference.ToString());
        _preferencesCache.Remove(preference);
    }

    public void Set<T>(PreferencesKey preference, T value)
    {
        _preferencesStorage.Set(preference.ToString(), value.ToString());
        _preferencesCache.TryAdd(preference, value);
    }
}