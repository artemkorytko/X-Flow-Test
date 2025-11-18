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
                        pd.SetInt(def.Id, def.defaultInt);
                        break;

                    case ResourceType.Float:
                        pd.SetFloat(def.Id, def.defaultFloat);
                        break;

                    case ResourceType.String:
                        pd.SetString(def.Id, def.defaultString);
                        break;
                }
            }

            PlayerData.Initialize(pd);
        }
    }
}