using Core;
using UnityEngine;


namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/Bundle")]
    public class ShopBundle : ScriptableObject
    {
        public string Title;

        public CostAction[] Costs;
        public RewardAction[] Rewards;

        public bool CanBuy(PlayerData pd)
        {
            foreach (var cost in Costs)
                if (!cost.CanExecute(pd))
                    return false;

            return true;
        }

        public void ApplyCosts(PlayerData pd)
        {
            foreach (var cost in Costs)
                cost.Execute(pd);
        }

        public void ApplyRewards(PlayerData pd)
        {
            foreach (var r in Rewards)
                r.Execute(pd);
        }

        public void Buy(PlayerData pd)
        {
            ApplyCosts(pd);
            ApplyRewards(pd);
        }
    }
}