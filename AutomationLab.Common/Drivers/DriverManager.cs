using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationLab.Common.Drivers
{
    /// <summary>
    /// Central Thread-Safe Driver Hub
    /// Stores and serves all technology drivers (UI / API / Mobile)
    /// </summary>
    public static class DriverManager
    {
        private static readonly AsyncLocal<ConcurrentDictionary<Type, object>> _context = new AsyncLocal<ConcurrentDictionary<Type, object>>();
        private static ConcurrentDictionary<Type, object> Context => _context.Value ??= new ConcurrentDictionary<Type, object>();

        public static void Set<T>(T driver) {
            Context[typeof(T)] = driver!;
        }

        public static T Get<T>()
        {
            if (Context.TryGetValue(typeof(T), out var driver))
                return (T)driver;
            throw new InvalidOperationException($"Driver of type {typeof(T).Name} is not initialized");
        }

        public static void Clear()
        { 
            Context.Clear();
        }
    }
}
