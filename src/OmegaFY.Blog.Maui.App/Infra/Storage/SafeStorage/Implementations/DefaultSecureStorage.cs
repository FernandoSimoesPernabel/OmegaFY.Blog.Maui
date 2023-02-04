using OmegaFY.Blog.Maui.App.Common.Serializers;
using OmegaFY.Blog.Maui.App.Infra.Enums;

namespace OmegaFY.Blog.Maui.App.Infra.Storage.SafeStorage.Implementations;

internal class DefaultSecureStorage : ISafeStorageProvider
{
    private readonly ISecureStorage _secureStorage;

    public DefaultSecureStorage(ISecureStorage secureStorage) => _secureStorage = secureStorage;

    public void ClearStorage() => _secureStorage.RemoveAll();

    public async Task<T> GetAsync<T>(SafeStorageKey storageKey) => JsonStaticSerializer.Deserialize<T>(await GetAsync(storageKey));

    public async Task<string> GetAsync(SafeStorageKey storageKey) => await _secureStorage.GetAsync(storageKey.ToString());

    public void Remove(SafeStorageKey storageKey) => _secureStorage.Remove(storageKey.ToString());

    public async Task SetAsync<T>(SafeStorageKey storageKey, T value) => await SetAsync(storageKey, JsonStaticSerializer.Serialize(value));

    public async Task SetAsync(SafeStorageKey storageKey, string value) => await _secureStorage.SetAsync(storageKey.ToString(), value);
}