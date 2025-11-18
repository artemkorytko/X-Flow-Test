using System;
using UnityEngine;


namespace Core
{
    public abstract class RewardAction : ScriptableObject, IShopAction
    {
        /// <summary>
        /// Проверка, можно ли выполнить награду для текущего состояния PlayerData.
        /// По умолчанию награду всегда можно выдать, но домен может переопределить это поведение.
        /// </summary>
        public virtual bool CanExecute(PlayerData pd) => true;

        /// <summary>
        /// Применение награды к PlayerData.
        /// Конкретная логика применения реализуется в доменах.
        /// </summary>
        public abstract void Execute(PlayerData pd);
    }
}