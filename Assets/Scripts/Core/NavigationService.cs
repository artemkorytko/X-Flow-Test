using UnityEngine.SceneManagement;


namespace Core
{
    public static class NavigationService
    {
        public static void OpenAdditive(string scene)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }

        public static void Close(string scene)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}