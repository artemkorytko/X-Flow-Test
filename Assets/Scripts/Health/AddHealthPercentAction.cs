using Core;
using UnityEngine;


namespace Health
{
    /// <summary>
    /// Добавление процентного количества здоровья от текущего.
    /// </summary>
    [CreateAssetMenu(menuName = "Health/AddHealthPercentAction")]
    public class AddHealthPercentAction : RewardAction
    {
        [SerializeField] private ResourceDefinition resource;
        [SerializeField, Range(0f, 1f)] private float percent;

        public override void Execute(PlayerData pd)
        {
            if (resource == null) return;

            var current = pd.GetInt(resource.Id);
            var delta = Mathf.FloorToInt(current * percent);
            pd.ModifyInt(resource.Id, delta);
        }
    }
}


