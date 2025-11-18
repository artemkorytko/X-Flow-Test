using UnityEngine;


namespace Core
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private ResourceDefinitionContainer _resourceDefinitions;

        private void Awake()
        {
            ResourceRegistry.Register(_resourceDefinitions.ResourceDefinitions);

            var pd = new PlayerData();

            foreach (var def in ResourceRegistry.All)
            {
                switch (def.type)
                {
                    case ResourceType.Int:
                        pd.SetResource(def.Id, new ResourceValue(def.defaultInt, 0, null));
                        break;

                    case ResourceType.Float:
                        pd.SetResource(def.Id, new ResourceValue(0, def.defaultFloat, null));
                        break;

                    case ResourceType.String:
                        pd.SetResource(def.Id, new ResourceValue(0, 0, def.defaultString));
                        break;
                }
            }

            PlayerData.Initialize(pd);
        }
    }
}