using UnityEngine;


namespace Shop
{
    [CreateAssetMenu(menuName = "Shop/ShopConfig")]
    public class ShopConfig : ScriptableObject
    {
        [SerializeField] private ShopBundle[] bundles;

        public ShopBundle[] Bundles => bundles;
    }
}