using System.Collections.Generic;


namespace Core
{
    public static class DataBus
    {
        private static readonly Dictionary<string, object> data = new();

        public static void Push<T>(string key, T value)
        {
            data[key] = value;
        }

        public static T Pull<T>(string key)
        {
            if (data.TryGetValue(key, out var value) && value is T typed)
                return typed;

            return default;
        }

        public static void Clear(string key)
        {
            if (data.ContainsKey(key))
                data.Remove(key);
        }
    }
}