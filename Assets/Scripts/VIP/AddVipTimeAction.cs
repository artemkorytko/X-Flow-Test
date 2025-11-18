using Core;
using UnityEngine;


namespace VIP
{
    [CreateAssetMenu(menuName = "VIP/AddVipTimeAction")]
    public class AddVipTimeAction : RewardAction
    {
        [SerializeField] private ResourceDefinition resource;
        [SerializeField] private float addSeconds;

        public override void Execute(PlayerData pd)
        {
            if (resource == null) return;

            pd.ModifyFloat(resource.Id, addSeconds);
        }
    }
}