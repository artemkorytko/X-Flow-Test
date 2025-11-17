using Core;
using UnityEngine;


namespace Gold
{
    [CreateAssetMenu(menuName = "Gold/SpendGoldAction")]
    public class SpendGoldAction : ScriptableObject, IShopAction
    {
        [SerializeField] private int amount = 100;

        public bool CanExecute(PlayerData data)
        {
            var raw = data.GetInt(GoldIds.Current);
            var current = raw is int i ? i : 0;
            return current >= amount;
        }

        public void Execute(PlayerData data)
        {
            var raw = data.GetInt(GoldIds.Current);
            var current = raw is int i ? i : 0;
            current -= amount;
            data.SetInt(GoldIds.Current, current);
        }
    }
}