using Core;
using UnityEngine;


namespace VIP
{
    [CreateAssetMenu(menuName = "VIP/RemoveVipTimeAction")]
    public class RemoveVipTimeAction : CostAction
    {
        [SerializeField] private ResourceDefinition resource;
        [SerializeField] private float removeSeconds;

        public override bool CanExecute(PlayerData pd)
        {
            if (resource == null) return false;

            var current = pd.GetFloat(resource.Id);
            return current >= removeSeconds;
        }

        public override void Execute(PlayerData pd)
        {
            if (resource == null) return;

            pd.ModifyFloat(resource.Id, -removeSeconds);
        }
    }
}