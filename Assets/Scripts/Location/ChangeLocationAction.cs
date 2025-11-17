using Core;
using UnityEngine;


namespace Location
{
    [CreateAssetMenu(menuName = "Location/ChangeLocationAction")]
    public class ChangeLocationAction : ScriptableObject, IShopAction
    {
        [SerializeField] private string newLocation = "Unknown";

        public bool CanExecute(PlayerData data) => true;

        public void Execute(PlayerData data)
        {
            data.SetString(LocationIds.Current, newLocation);
        }
    }
}