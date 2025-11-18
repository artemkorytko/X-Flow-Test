using System;
using System.Collections.Generic;


namespace Core
{
    public sealed class PlayerData
    {
        private static PlayerData _instance;

        public static PlayerData Instance
        {
            get
            {
                if (_instance == null) throw new InvalidOperationException("PlayerData not initialized");

                return _instance;
            }
        }

        public static void Initialize(PlayerData pd)
        {
            if (_instance != null) throw new InvalidOperationException("Already initialized");

            _instance = pd ?? throw new ArgumentNullException(nameof(pd));
        }

        private readonly Dictionary<ResourceId, object> _store = new();

        /// <summary>
        /// Установить значение произвольного типа для указанного ресурса.
        /// </summary>
        public void Set<T>(ResourceId id, T value) => _store[id] = value;

        /// <summary>
        /// Установить значение по типобезопасному ключу.
        /// </summary>
        public void Set<T>(PlayerDataKey<T> key, T value) => Set(key.Id, value);

        /// <summary>
        /// Получить значение произвольного типа для указанного ресурса.
        /// Если тип не совпадает или значение отсутствует, возвращается defaultValue.
        /// </summary>
        public T Get<T>(ResourceId id, T defaultValue = default)
        {
            if (_store.TryGetValue(id, out var obj) && obj is T typed)
                return typed;

            return defaultValue;
        }

        /// <summary>
        /// Получить значение по типобезопасному ключу.
        /// </summary>
        public T Get<T>(PlayerDataKey<T> key, T defaultValue = default) => Get(key.Id, defaultValue);

        /// <summary>
        /// Модифицировать значение произвольного типа через делегат.
        /// Если значения нет, используется defaultValue.
        /// </summary>
        public void Modify<T>(ResourceId id, Func<T, T> update, T defaultValue = default)
        {
            var current = Get(id, defaultValue);
            var next = update(current);
            Set(id, next);
        }

        /// <summary>
        /// Модифицировать значение по типобезопасному ключу.
        /// </summary>
        public void Modify<T>(PlayerDataKey<T> key, Func<T, T> update, T defaultValue = default) =>
            Modify(key.Id, update, defaultValue);

        // Специализированные helper-методы для int/float/string

        public int GetInt(ResourceId id) => Get<int>(id, 0);
        public void SetInt(ResourceId id, int value) => Set<int>(id, value);

        public void ModifyInt(ResourceId id, int delta)
        {
            Modify<int>(id, cur => cur + delta, 0);
        }

        public float GetFloat(ResourceId id) => Get<float>(id, 0f);
        public void SetFloat(ResourceId id, float value) => Set<float>(id, value);

        public void ModifyFloat(ResourceId id, float delta)
        {
            Modify<float>(id, cur => cur + delta, 0f);
        }

        public string GetString(ResourceId id) => Get<string>(id, null);
        public void SetString(ResourceId id, string value) => Set<string>(id, value);
    }
}