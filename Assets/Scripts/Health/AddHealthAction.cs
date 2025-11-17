using Core;
using UnityEngine;


namespace Health
{
    [CreateAssetMenu(menuName = "Health/AddHealthAction")]
    public class AddHealthAction : ScriptableObject, IShopAction
    {
        [SerializeField] private int amount = 1;

        public bool CanExecute(PlayerData data) => true;

        public void Execute(PlayerData data)
        {
            data.ModifyInt(HealthIds.Current, amount);
        }
    }
}