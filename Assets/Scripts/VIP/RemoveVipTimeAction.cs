using Core;
using UnityEngine;


namespace VIP
{
    [CreateAssetMenu(menuName = "VIP/RemoveVipTimeAction")]
    public class RemoveVipTimeAction : ScriptableObject, IShopAction
    {
        [SerializeField] private float seconds = 60f;

        public bool CanExecute(PlayerData data)
        {
            var cur = data.GetFloat(VipIds.DurationSeconds);
            return cur >= seconds;
        }

        public void Execute(PlayerData data)
        {
            data.ModifyFloat(VipIds.DurationSeconds, -seconds);
        }
    }
}