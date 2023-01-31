using OmegaFY.Blog.Maui.App.Infra.Enums;

namespace OmegaFY.Blog.Maui.App.Infra.Storage.SafeStorage;

public interface ISafeStorageProvider
{
    public void ClearStorage();

    public Task<T> GetAsync<T>(SafeStorageKey storageKey);

    public void Remove(SafeStorageKey storageKey);

    public Task SetAsync<T>(SafeStorageKey storageKey, T value);
}