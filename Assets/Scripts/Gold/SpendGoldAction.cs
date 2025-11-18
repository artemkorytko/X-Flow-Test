using Core;
using UnityEngine;


namespace Gold
{
    [CreateAssetMenu(menuName = "Gold/SpendGoldAction")]
    public class SpendGoldAction : CostAction
    {
        [SerializeField] private ResourceDefinition resource;
        [SerializeField] private int spendAmount;

        public override bool CanExecute(PlayerData pd)
        {
            if (resource == null) return false;

            var current = pd.GetInt(resource.Id);
            return current >= spendAmount;
        }

        public override void Execute(PlayerData pd)
        {
            if (resource == null) return;

            pd.ModifyInt(resource.Id, -spendAmount);
        }
    }
}