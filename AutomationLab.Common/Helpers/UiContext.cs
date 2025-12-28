using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationLab.Common.Helpers
{
    /// <summary>
    /// Scenario level context store (Thread & Async safe)
    /// Used for sharing data between steps, domains and pages.
    /// </summary>
    public static class UiContext
    {
        private static readonly AsyncLocal<ConcurrentDictionary<string, object>> _data
            = new AsyncLocal<ConcurrentDictionary<string, object>>();

        private static ConcurrentDictionary<string, object> Data
            => _data.Value ??= new ConcurrentDictionary<string, object>();

        public static void Set<T>(String key, T value)
        {
            Data[key] = value!;
        }

        public static T Get<T>(string key)
        {
            if (Data.TryGetValue(key, out var value))
                return (T)value;

            throw new KeyNotFoundException($"Key as {key} not found");
        }

        public static bool TryGet<T>(string key, out T value)
        {
            if (Data.TryGetValue(key, out var obj) && obj is T casted)
            {
                value = casted;
                return true;
            }

            value = default!;
            return false;
        }

        public static void Clear() {
            Data.Clear();
        }
    }
}
