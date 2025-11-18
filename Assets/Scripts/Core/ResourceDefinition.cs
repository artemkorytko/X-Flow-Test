using UnityEngine;


namespace Core
{
    [CreateAssetMenu(menuName = "Core/Resource Definition")]
    public class ResourceDefinition : ScriptableObject
    {
        public string id;

        public ResourceType type;

        public int defaultInt;
        public float defaultFloat;
        public string defaultString;
        public ResourceId Id => new ResourceId(id);
    }
}