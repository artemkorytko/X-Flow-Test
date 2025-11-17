using Core;
using UnityEngine;


namespace Health
{
    [CreateAssetMenu(menuName = "Health/SpendHealthAction")]
    public class SpendHealthAction : ScriptableObject, IShopAction
    {
        [SerializeField] private int amount = 1;

        public bool CanExecute(PlayerData data)
        {
            var current = data.GetInt(HealthIds.Current);
            return current >= amount;
        }

        public void Execute(PlayerData data)
        {
            data.ModifyInt(HealthIds.Current, -amount);
        }
    }
}