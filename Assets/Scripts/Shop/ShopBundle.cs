using System.Collections.Generic;
using Core;
using UnityEngine;


namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/Bundle")]
    public class ShopBundle : ScriptableObject
    {
        public string Title;
        public List<ScriptableObject> Costs = new List<ScriptableObject>();   // each must implement IShopAction
        public List<ScriptableObject> Rewards = new List<ScriptableObject>();

        public bool CanBuy(PlayerData pd)
        {
            foreach (var so in Costs)
            {
                if (!(so is IShopAction action)) return false;
                if (!action.CanExecute(pd)) return false;
            }
            return true;
        }

        public void ApplyCosts(PlayerData pd)
        {
            foreach (var so in Costs)
            {
                (so as IShopAction)?.Execute(pd);
            }
        }

        public void ApplyRewards(PlayerData pd)
        {
            foreach (var so in Rewards)
            {
                (so as IShopAction)?.Execute(pd);
            }
        }

        // Комбинированная покупка (локально)
        public void Buy(PlayerData pd)
        {
            ApplyCosts(pd);
            ApplyRewards(pd);
        }
    }
}