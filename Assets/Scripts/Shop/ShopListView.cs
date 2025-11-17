using System.Collections.Generic;
using UnityEngine;


namespace Shop
{
    public class ShopListView : MonoBehaviour
    {
        [SerializeField] private Transform contentParent;
        [SerializeField] private GameObject bundleViewPrefab;
        [SerializeField] private List<ShopBundle> bundles;

        private List<ShopBundleView> views = new List<ShopBundleView>();

        private void Start()
        {
            foreach (var b in bundles)
            {
                var go = Instantiate(bundleViewPrefab, contentParent);
                var view = go.GetComponent<ShopBundleView>();
                view.Setup(b);
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
            foreach (var v in views) v.UpdateInteractable();
        }
    }
}