using Core;
using UnityEngine;


namespace Gold
{
    [CreateAssetMenu(menuName = "Gold/AddGoldAction")]
    public class AddGoldAction : RewardAction
    {
        [SerializeField] private ResourceDefinition resource;
        [SerializeField] private int addAmount;

        public override void Execute(PlayerData pd)
        {
            if (resource == null) return;

            pd.ModifyInt(resource.Id, addAmount);
        }
    }
}