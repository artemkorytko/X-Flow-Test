using Core;
using UnityEngine;
using UnityEngine.UI;


namespace Shop
{
    public class ShopBundleDetailView : MonoBehaviour
    {
        [SerializeField] private ShopBundleView bundleView;
        [SerializeField] private Button backButton;

        private void Awake()
        {
            if (backButton)
                backButton.onClick.AddListener(OnBack);
            else
                Debug.LogError("BackButton is not assigned in ShopBundleDetailView.");
        }

        private void OnDestroy()
        {
            if (backButton)
                backButton.onClick.RemoveListener(OnBack);
        }

        private void Start()
        {
            var bundle = DataBus.Pull(ShopDataKeys.SelectedBundle);

            if (bundle == null)
            {
                Debug.LogError("Bundle not found");
                OnBack();
                return;
            }

            bundleView.Setup(bundle, ShopBundleViewMode.InDetail);
        }

        public void OnBack()
        {
            NavigationService.Close("ShopBundleScene");
        }
    }
}