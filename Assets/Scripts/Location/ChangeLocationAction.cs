using Core;
using UnityEngine;


namespace Location
{
    [CreateAssetMenu(menuName = "Location/ChangeLocationAction")]
    public class ChangeLocationAction : RewardAction
    {
        [SerializeField] private ResourceDefinition resource;
        [SerializeField] private string targetLocation;

        public override void Execute(PlayerData pd)
        {
            if (resource == null) return;

            pd.SetString(resource.Id, targetLocation);
        }
    }
}