using UnityEngine;


namespace Core
{
    [CreateAssetMenu(menuName = "Core/Resource Definition")]
    public class ResourceDefinition : ScriptableObject
    {
        public string domain; // e.g. "Health", "Gold", "Location", "VIP"
        public string key;    // e.g. "Current", "DurationSeconds", "Name"
        public ResourceType type;

        // default values (only one used depending on type)
        public int defaultInt;
        public float defaultFloat;
        public string defaultString;

        public ResourceId Id => new ResourceId(domain, key);
    }
}