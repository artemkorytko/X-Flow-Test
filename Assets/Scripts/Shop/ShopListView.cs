using System.Collections.Generic;
using UnityEngine;


namespace Shop
{
    public class ShopListView : MonoBehaviour
    {
        [SerializeField] private ShopConfig shopConfig;
        [SerializeField] private Transform contentParent;
        [SerializeField] private GameObject bundleViewPrefab;

        private readonly List<ShopBundleView> views = new();

        private void Start()
        {
            foreach (var b in shopConfig.Bundles)
            {
                var go = Instantiate(bundleViewPrefab, contentParent);
                var view = go.GetComponent<ShopBundleView>();
                view.Setup(b, ShopBundleViewMode.InShopList);
                views.Add(view);
            }

            ShopUIEvents.OnPlayerDataChanged += OnPlayerDataChanged;
        }

        private void OnDestroy()
        {
            ShopUIEvents.OnPlayerDataChanged -= OnPlayerDataChanged;
        }

        private void OnPlayerDataChanged()
        {
            foreach (var v in views)
                v.UpdateInteractable();
        }
    }
}