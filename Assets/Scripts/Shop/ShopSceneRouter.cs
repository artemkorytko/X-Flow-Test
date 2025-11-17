using UnityEngine;
using UnityEngine.SceneManagement;


namespace Shop
{
    public static class ShopSceneRouter
    {
        public static ShopBundle SelectedBundle;

        public static void OpenBundleDetail(ShopBundle b)
        {
            SelectedBundle = b;
            SceneManager.LoadScene("ShopBundleScene"); // имя сцены детали
        }
    }
}