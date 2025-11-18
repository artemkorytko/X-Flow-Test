using System.Collections.Generic;
using System.Linq;


namespace Core
{
    public static class ResourceRegistry
    {
        private static readonly Dictionary<ResourceId, ResourceDefinition> _map = new();

        public static void Register(IEnumerable<ResourceDefinition> defs)
        {
            _map.Clear();
            foreach (var d in defs ?? Enumerable.Empty<ResourceDefinition>())
            {
                if (d == null) continue;

                _map[d.Id] = d;
            }
        }

        public static ResourceDefinition Get(ResourceId id) => _map.TryGetValue(id, out var def) ? def : null;

        public static IEnumerable<ResourceDefinition> All => _map.Values;
    }
}