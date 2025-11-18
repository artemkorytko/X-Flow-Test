using Core;
using UnityEngine;


namespace Health
{
    [CreateAssetMenu(menuName = "Health/AddHealthAction")]
    public class AddHealthAction : RewardAction
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