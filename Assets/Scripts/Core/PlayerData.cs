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

        private readonly Dictionary<ResourceId, ResourceValue> _store = new();

        public void SetResource(ResourceId id, ResourceValue value) => _store[id] = value;

        public int GetInt(ResourceId id) => _store.TryGetValue(id, out var v) ? v.IntValue : 0;
        public void SetInt(ResourceId id, int value) => _store[id] = new ResourceValue(value, GetFloat(id), GetString(id));

        public void ModifyInt(ResourceId id, int delta)
        {
            var cur = GetInt(id);
            SetInt(id, cur + delta);
        }

        public float GetFloat(ResourceId id) => _store.TryGetValue(id, out var v) ? v.FloatValue : 0f;
        public void SetFloat(ResourceId id, float value) => _store[id] = new ResourceValue(GetInt(id), value, GetString(id));

        public void ModifyFloat(ResourceId id, float delta)
        {
            var cur = GetFloat(id);
            SetFloat(id, cur + delta);
        }

        public string GetString(ResourceId id) => _store.TryGetValue(id, out var v) ? v.StringValue : null;
        public void SetString(ResourceId id, string value) => _store[id] = new ResourceValue(GetInt(id), GetFloat(id), value);
    }
}