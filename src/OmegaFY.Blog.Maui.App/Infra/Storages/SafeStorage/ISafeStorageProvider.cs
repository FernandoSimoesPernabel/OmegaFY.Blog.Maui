﻿using OmegaFY.Blog.Maui.App.Infra.Enums;

namespace OmegaFY.Blog.Maui.App.Infra.Storages.SafeStorage;

public interface ISafeStorageProvider
{
    public void ClearStorage();

    public Task<T> GetAsync<T>(SafeStorageKey storageKey);

    public Task<string> GetAsync(SafeStorageKey storageKey);

    public void Remove(SafeStorageKey storageKey);

    public Task SetAsync<T>(SafeStorageKey storageKey, T value);

    public Task SetAsync(SafeStorageKey storageKey, string value);
}