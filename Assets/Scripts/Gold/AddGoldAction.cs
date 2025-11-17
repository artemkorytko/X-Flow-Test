using Core;
using UnityEngine;


namespace Gold
{
    [CreateAssetMenu(menuName = "Gold/AddGoldAction")]
    public class AddGoldAction : ScriptableObject, IShopAction
    {
        [SerializeField] private int amount = 50;

        public bool CanExecute(PlayerData data) => true;

        public void Execute(PlayerData data)
        {
            var raw = data.GetInt(GoldIds.Current);
            var current = raw is int i ? i : 0;
            current += amount;
            data.SetInt(GoldIds.Current, current);
        }
    }
}