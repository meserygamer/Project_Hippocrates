using System;
using System.Collections.Generic;
using System.IO;

namespace Project_Hippocrates_AvaloniaUI;

public class Bundle
{
    private readonly Dictionary<string, object?> _dataVault = new();

    public Bundle() { }

    public Bundle(Dictionary<string, object?> initValues)
        => _dataVault = initValues;

    public T GetData<T>(string key)
    {
        if (!_dataVault.TryGetValue(key, out object? value))
            throw new IndexOutOfRangeException($"object with key - \"{key}\" in the bundle is not");
        try
        {
            return (T)value!;
        }
        catch (Exception e)
        {
            throw new InvalidDataException(
                $"invalid object type.\n" +
                $"Your type - {typeof(T).FullName}" +
                $"Type of object in bundle - {value?.GetType().FullName}", 
                e
            );
        }
    }

    public bool AddData(string key, object? value)
    {
        return _dataVault.TryAdd(key, value);
    }
}