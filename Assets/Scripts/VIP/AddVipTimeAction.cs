using Core;
using UnityEngine;


namespace VIP
{
    [CreateAssetMenu(menuName = "VIP/AddVipTimeAction")]
    public class AddVipTimeAction : ScriptableObject, IShopAction
    {
        [SerializeField] private float seconds = 60f;

        public bool CanExecute(PlayerData data) => true;

        public void Execute(PlayerData data)
        {
            data.ModifyFloat(VipIds.DurationSeconds, seconds);
        }
    }
}