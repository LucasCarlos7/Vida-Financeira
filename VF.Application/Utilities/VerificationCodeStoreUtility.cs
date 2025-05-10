using System.Collections.Concurrent;

namespace VF.Application.Utilities;

public static class VerificationCodeStoreUtility
{
    private static readonly ConcurrentDictionary<string, (string Code, DateTime Expiry)> _store = new();
    private static readonly TimeSpan _expiryTime = TimeSpan.FromMinutes(5);

    public static void StoreCode(string key, string code)
    {
        _store[key] = (code, DateTime.Now.Add(_expiryTime));
    }

    public static bool ValidateCode(string key, string code)
    {
        if (_store.TryGetValue(key, out var entry))
        {
            if (entry.Code == code && DateTime.Now <= entry.Expiry)
            {
                _store.TryRemove(key, out _);
                
                return true;
            }
        }

        return false;
    }
}
