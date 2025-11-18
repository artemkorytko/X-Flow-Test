using Core;
using UnityEngine;


namespace Health
{
    /// <summary>
    /// Трата процентного количества здоровья от текущего.
    /// </summary>
    [CreateAssetMenu(menuName = "Health/SpendHealthPercentAction")]
    public class SpendHealthPercentAction : CostAction
    {
        [SerializeField] private ResourceDefinition resource;
        [SerializeField, Range(0f, 1f)] private float percent;

        public override bool CanExecute(PlayerData pd)
        {
            if (resource == null) return false;

            var current = pd.GetInt(resource.Id);
            var cost = Mathf.FloorToInt(current * percent);
            return current >= cost;
        }

        public override void Execute(PlayerData pd)
        {
            if (resource == null) return;

            var current = pd.GetInt(resource.Id);
            var cost = Mathf.FloorToInt(current * percent);
            pd.ModifyInt(resource.Id, -cost);
        }
    }
}


