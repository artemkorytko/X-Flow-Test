using Core;
using UnityEngine;


namespace Health
{
    [CreateAssetMenu(menuName = "Health/SpendHealthAction")]
    public class SpendHealthAction : CostAction
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