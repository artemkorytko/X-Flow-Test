using UnityEngine;


namespace Shop
{
    public class ShopBundleDetailView : MonoBehaviour
    {
        [SerializeField] private ShopBundleView bundleView; // на сцене полный экран

        private void Start()
        {
            var bundle = ShopSceneRouter.SelectedBundle;
            if (bundle == null)
            {
                Debug.LogError("No bundle selected");
                return;
            }

            bundleView.Setup(bundle);
        }

        public void OnBack()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ShopListScene");
        }
    }
}