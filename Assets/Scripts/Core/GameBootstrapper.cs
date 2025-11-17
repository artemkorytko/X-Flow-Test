using UnityEngine;


namespace Core
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private ResourceDefinitionContainer _resourceDefinitions;

        private void Awake()
        {
            var pd = new PlayerData();

            foreach (var def in _resourceDefinitions.ResourceDefinitions)
            {
                switch (def.type)
                {
                    case ResourceType.Int:
                        pd.SetResource(def.Id, new ResourceValue(def.defaultInt, 0f, null));
                        break;
                    case ResourceType.Float:
                        pd.SetResource(def.Id, new ResourceValue(0, def.defaultFloat, null));
                        break;
                    case ResourceType.String:
                        pd.SetResource(def.Id, new ResourceValue(0, 0f, def.defaultString));
                        break;
                }
            }

            PlayerData.Initialize(pd);
        }
    }
}