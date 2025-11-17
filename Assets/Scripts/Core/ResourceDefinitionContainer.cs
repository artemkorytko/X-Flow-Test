using UnityEngine;


namespace Core
{
    [CreateAssetMenu(menuName = "Core/Resource ResourceDefinition Container")]
    public class ResourceDefinitionContainer : ScriptableObject
    {
        [SerializeField] private ResourceDefinition[] _resourceDefinitions;

        public ResourceDefinition[] ResourceDefinitions => _resourceDefinitions;
    }
}