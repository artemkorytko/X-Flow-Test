using UnityEngine;


namespace UI
{
    [CreateAssetMenu(menuName = "UI/TopHUDConfig")]
    public class TopRowConfig : ScriptableObject
    {
        public TopRowEntry[] entries;
    }
}