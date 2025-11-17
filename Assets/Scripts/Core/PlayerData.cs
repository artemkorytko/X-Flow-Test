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
                if (_instance == null) throw new InvalidOperationException("PlayerData not initialized. Run GameBootstrapper.");

                return _instance;
            }
        }

        public static void Initialize(PlayerData pd)
        {
            if (_instance != null) throw new InvalidOperationException("PlayerData already initialized");

            _instance = pd ?? throw new ArgumentNullException(nameof(pd));
        }

        private readonly Dictionary<ResourceId, ResourceValue> _store = new Dictionary<ResourceId, ResourceValue>();

        // used by bootstrapper to seed resource with default value
        public void SetResource(ResourceId id, ResourceValue value)
        {
            _store[id] = value;
        }

        public bool TryGetInt(ResourceId id, out int value)
        {
            if (_store.TryGetValue(id, out var rv))
            {
                value = rv.IntValue;
                return true;
            }

            value = 0;
            return false;
        }

        public int GetInt(ResourceId id)
        {
            return _store.TryGetValue(id, out var rv) ? rv.IntValue : 0;
        }

        public void SetInt(ResourceId id, int newVal)
        {
            if (!_store.TryGetValue(id, out var rv))
            {
                rv = new ResourceValue();
                _store[id] = rv;
            }

            rv.IntValue = newVal;
        }

        public void ModifyInt(ResourceId id, int delta)
        {
            if (!_store.TryGetValue(id, out var rv))
            {
                rv = new ResourceValue();
                _store[id] = rv;
            }

            rv.IntValue += delta;
        }

        // Float API
        public float GetFloat(ResourceId id)
        {
            return _store.TryGetValue(id, out var rv) ? rv.FloatValue : 0f;
        }

        public void SetFloat(ResourceId id, float newVal)
        {
            if (!_store.TryGetValue(id, out var rv))
            {
                rv = new ResourceValue();
                _store[id] = rv;
            }

            rv.FloatValue = newVal;
        }

        public void ModifyFloat(ResourceId id, float delta)
        {
            if (!_store.TryGetValue(id, out var rv))
            {
                rv = new ResourceValue();
                _store[id] = rv;
            }

            rv.FloatValue += delta;
        }

        // String API
        public string GetString(ResourceId id)
        {
            return _store.TryGetValue(id, out var rv) ? rv.StringValue : null;
        }

        public void SetString(ResourceId id, string value)
        {
            if (!_store.TryGetValue(id, out var rv))
            {
                rv = new ResourceValue();
                _store[id] = rv;
            }

            rv.StringValue = value;
        }
    }
}