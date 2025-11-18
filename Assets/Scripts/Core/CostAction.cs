using System;
using UnityEngine;


namespace Core
{
    public abstract class CostAction : ScriptableObject, IShopAction
    {
        /// <summary>
        /// Проверка, можно ли выполнить действие для текущего состояния PlayerData.
        /// Конкретная логика проверки реализуется в доменах.
        /// </summary>
        public abstract bool CanExecute(PlayerData pd);

        /// <summary>
        /// Применение действия к PlayerData.
        /// Конкретная логика применения реализуется в доменах.
        /// </summary>
        public abstract void Execute(PlayerData pd);
    }
}